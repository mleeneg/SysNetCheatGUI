﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SysNetCheatGUI
{
    public enum Commands
    {
        StartSearch = 0,
        ContinueSearch = 1,
        PokeAddress = 2,
        FreezeAddress = 3,
        ListAddress = 4,
        ReleaseFreeze = 5,
        UnFreezeAddress = 6
    }

    public class Switch
    {
        //Enable the Creation of the TCPClient
        public bool Connected;
        public bool IsNewSearch = true;
        public bool ReadDisplay = true;
        public bool ClickedSearch = false;
        //Default port for the Swith
        public int SwitchPort = 5555;
        //Ip Address
        public IPAddress IpAddress;
        //Create TCPClient
        public Socket SwitchSocket;
        //Get Client Stream for Reading and Writing
        private NetworkStream _stream;
        private BinaryReader _br;
        private BinaryWriter _bw;

        private Thread _listen;
        private FrmMain _mainForm;
        private string _sConsole;
        public Switch(FrmMain mainForm)
        {
            _mainForm = mainForm;
        }

        /// <summary>
        /// Connect to Switch IP Address
        /// </summary>
        /// <param name="ip">127.0.0.1 as Example</param>
        public void Connect(string ip)
        {
            //If Socket is false create client
            if (Connected == false)
            {
                //Check for Valid IP Address
                try
                {
                    IpAddress = IPAddress.Parse(ip);
                    //Connect Client
                    SwitchSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    SwitchSocket.Connect(IpAddress, SwitchPort);
                    //Set Connected
                    Connected = SwitchSocket.Connected;
                    //create stream
                    _stream = new NetworkStream(SwitchSocket);
                    _bw = new BinaryWriter(_stream);
                    _br = new BinaryReader(_stream);
                    //create thread and start it.
                    _listen = new Thread(RecieveMessages) {IsBackground = true};
                    _listen.Start();
                    //RecieveMessages();
                }
                catch
                {
                    MessageBox.Show("Could Not Connect");
                    _mainForm.MySwitch = null;
                    //Connected = false;
                }
            }
            //MessageBox.Show(SocketClient.Connected == true ? "Switch is Connected!" : "Switch is Not Connected!");
        }

        public void RecieveMessages()
        {
            try
            {
                
                while (Connected)
                {
                    
                    byte[] buffer = new byte[1024];
                    if (ReadDisplay)
                    {
                        
                        _stream.Read(buffer, 0, buffer.Length);
                        if (_mainForm.txtConsole.InvokeRequired)
                        {
                            _mainForm.txtConsole.Invoke(new Action(() =>
                            {
                                _mainForm.txtConsole.AppendText(Encoding.Default.GetString(buffer));

                            }));
                        }
                    }
                    

                    if (IndexOf(buffer, new byte[] {0x3e}, 0) > -1)
                    {
                        ReadDisplay = false;
                        if (ClickedSearch)
                        {
                            _sConsole = _mainForm.txtConsole.Text;
                            _sConsole = _sConsole.Replace("at ", "at 0x");
                            Regex r = new Regex(@"\b0x[0-9A-Fa-f]+\b");
                            MatchCollection matchList = r.Matches(_sConsole);

                            foreach (var value in matchList)
                            {
                                if (_mainForm.lvAddress.InvokeRequired)
                                {
                                    _mainForm.lvAddress.Invoke(new Action(() =>
                                    {
                                        string replaceAddress = value.ToString();
                                        replaceAddress = replaceAddress.Replace("0x", "");
                                        ListViewItem item = new ListViewItem(replaceAddress);
                                        item.SubItems.Add(_mainForm.txtValue.Text);
                                        _mainForm.lvAddress.Items.Add(item);

                                        _mainForm.lblCountFound.Text =
                                            (_mainForm.lvAddress.Items.Count < 0)
                                            ? "0"
                                            : _mainForm.lvAddress.Items.Count.ToString();
                                    }));
                                }
                            }
                            ClickedSearch = false;
                        }
                        
                    }
                    
                }
            }
            catch (Exception e)
            {
                
                Connected = false;
                Disconnect();
                MessageBox.Show(e.ToString());

            }
        }
       

        public string CommandString(Commands commands, string index,string address,string datatype,string value)
        {
            switch (commands)
            {
                case Commands.StartSearch:
                    return $"ssearch {datatype} {value}";
                case Commands.ContinueSearch:
                    return $"csearch {value}";
                case Commands.PokeAddress:
                    return $"poke {address} {datatype} {value}";
                case Commands.FreezeAddress:
                    return $"afreeze {address} {datatype} {value}";
                case Commands.ListAddress:
                    return $"lfreeze";
                case Commands.ReleaseFreeze:
                    return $"rfreeze {address}";
                case Commands.UnFreezeAddress:
                    return $"dfreeze {index}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(commands), commands, null);
            }
            
        }

        public Commands SearchString()
        {
            //Create Search String
            
            if (IsNewSearch)
            {
                //Set isNewSearch to false
                IsNewSearch = false;
                //CommandString to start New Search
                return Commands.StartSearch; //CommandString(Commands.StartSearch, "","", searchSize, value);  
            }
            //CommandString to Continue Search
            return Commands.ContinueSearch; //CommandString(Commands.ContinueSearch, "", "","", value);
        }

        /// <summary>
        /// Disconnect the Client
        /// </summary>
        public void Disconnect()
        {
            _listen?.Abort();
            _stream?.Close();
            _br?.Close();
            _bw?.Close();
            try
            {
                SwitchSocket?.Shutdown(SocketShutdown.Both);
                SwitchSocket?.Close();
            }
            catch
            {
            }
            

            _mainForm.EnableForm(false);
            _mainForm.MySwitch = null;

        }

        public void SendPacket(byte[] command)
        {
            List<byte> listbytecommand = new List<byte>();
            foreach (byte value in command)
            {
                listbytecommand.Add(value);
            }
            listbytecommand.Add(0x0a);
            command = listbytecommand.ToArray();
            _bw.Write(command);
        }

        public void ClearWriteBuffer()
        {
            _bw.Flush();
        }

        /// <summary>
        /// Sends command to sys-netcheat
        /// </summary>
        /// <param name="commands">Enum CommandString</param>
        /// <param name="id">String:ID</param>
        /// <param name="address">String:Address</param>
        /// <param name="valueType">String:ValueSize</param>
        /// <param name="value">String:Value</param>
        public void SendCommand(Commands commands, string id, string address, string valueType,string value)
        {
            ReadDisplay = true;
            string command = CommandString(commands,id,address,valueType,value);
            byte[] byteCommand = Encoding.Default.GetBytes(command);
            SendPacket(byteCommand);
            ClearWriteBuffer();
        }

        /// <summary>
        /// Search for Byte in Byte array
        /// </summary>
        /// <param name="array">Collection of bytes to look into</param>
        /// <param name="pattern">Byte to look for</param>
        /// <param name="offset">Where to Start</param>
        /// <returns></returns>
        public static int IndexOf(byte[] array, byte[] pattern, int offset)
        {
            int success = 0;
            for (int i = offset; i < array.Length; i++)
            {
                if (array[i] == pattern[success])
                {
                    success++;
                }
                else
                {
                    success = 0;
                }

                if (pattern.Length == success)
                {
                    return i - pattern.Length + 1;
                }
            }
            return -1;
        }
    }

}
