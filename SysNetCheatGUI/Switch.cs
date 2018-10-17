using System;
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
        
        public bool IsConnected = false;
        public bool IsNewSearch = true;
        public bool ReadDisplay = true;
        public bool ClickedSearch = false;
        //Default port for the Switch
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
        private StringBuilder _sbAddresses = new StringBuilder();
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
            if (IsConnected == false)
            {
                //Check for Valid IP Address
                try
                {
                    IpAddress = IPAddress.Parse(ip);
                    //Connect Client
                    SwitchSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    SwitchSocket.Connect(IpAddress, SwitchPort);
                    //Set IsConnected
                    IsConnected = SwitchSocket.IsConnected();
                    //create stream
                    _stream = new NetworkStream(SwitchSocket);
                    _bw = new BinaryWriter(_stream);
                    _br = new BinaryReader(_stream);
                    //create thread and start it.
                    _listen = new Thread(ReceiveMessages) {IsBackground = true};
                    _listen.Start();
                    //ReceiveMessages();
                }
                catch
                {
                    MessageBox.Show("Could Not Connect");
                    _mainForm.MySwitch = null;
                    //IsConnected = false;
                }
            }
            //MessageBox.Show(SocketClient.IsConnected == true ? "Switch is IsConnected!" : "Switch is Not IsConnected!");
        }
        /// <summary>
        /// Will receive messages from console.
        /// </summary>
        public void ReceiveMessages()
        {   
            try
            {
                //while still IsConnected
                while (IsConnected)
                {
                    byte[] buffer = new byte[255];
                    if (ReadDisplay)
                    {
                        int rec = _stream.Read(buffer, 0, buffer.Length);
                        if (rec <= 0)
                        {
                            throw new SocketException();
                        }
                        Array.Resize(ref buffer, rec);
                        _sbAddresses.Append(Encoding.Default.GetString(buffer));
                        _sbAddresses.Replace("\0", "");
                        if (_mainForm.txtConsole.InvokeRequired)
                        {
                            _mainForm.txtConsole.Invoke(new Action(() =>
                            {
                                _mainForm.txtConsole.Text =_sbAddresses.ToString();
                            }));
                        }   
                    }
                    GetAddressesFromConsole(buffer);
                    GetAddressResultCount();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Disconnected! Please Reconnect.");
                IsConnected = false;
                Disconnect();
            }
        }

        private void GetAddressResultCount()
        {
            if (_mainForm.lvAddress.InvokeRequired)
            {
                _mainForm.lvAddress.Invoke(new Action(() =>
                {
                    _mainForm.lblCountFound.Text =
                        (_mainForm.lvAddress.Items.Count < 0)
                            ? "0"
                            : _mainForm.lvAddress.Items.Count.ToString();
                }));
            }
        }

        /// <summary>
        /// Get Addresses from console
        /// </summary>
        /// <param name="buffer">Read display from console</param>
        private void GetAddressesFromConsole(byte[] buffer)
        {
            //Get Searched Value
            string searchValue = _mainForm.txtValue.Text;
            //If character ">" is found in buffer it means end of console display.
            if (IndexOf(buffer, new byte[] {0x3e}, 0) > -1)
            {
                //Turn off reading of Console.
                ReadDisplay = false;
                //If Search button was presses
                if (ClickedSearch)
                {
                    //Get string read for regex
                    _sbAddresses.Replace("at ", "at 0x");
                    //Regex address format
                    Regex r = new Regex(@"\b0x[0-9A-Fa-f]+\b");
                    //Get Matches
                    MatchCollection matchList = r.Matches(_sbAddresses.ToString());
                    //Loop thru matches
                    foreach (var value in matchList)
                    {
                        //Because this in a different thread must invoke lvAddress from main thread.
                        if (_mainForm.lvAddress.InvokeRequired)
                        {
                            _mainForm.lvAddress.Invoke(new Action(() =>
                            {
                                //Removing 0x from Address
                                string replaceAddress = value.ToString();
                                replaceAddress = replaceAddress.Replace("0x", "");
                                //Make New ListViewItem
                                ListViewItem item = new ListViewItem(replaceAddress);
                                item.SubItems.Add(searchValue);
                                //Add ListViewItem to ListView
                                _mainForm.lvAddress.Items.Add(item);
                            }));
                        }
                    }

                    ClickedSearch = false;
                }
            }
        }

        /// <summary>
        /// Clear Addresses in String Builder
        /// </summary>
        public void ClearAddresses()
        {
            _sbAddresses.Clear();
        }

        /// <summary>
        /// Create string command to be sent to server.
        /// </summary>
        /// <param name="commands">Command Enum: Command Indicator</param>
        /// <param name="index">string: Freeze Index - Can be empty but not null</param>
        /// <param name="address">string: Address - Can be empty but not null</param>
        /// <param name="valueSize">string: Value Size - Can be empty but not null</param>
        /// <param name="value">string: Value - Can be empty but not null</param>
        /// <returns></returns>
        public string MakeCommandString(Commands commands, string index,string address,string valueSize,string value)
        {
            switch (commands)
            {
                case Commands.StartSearch:
                    return $"ssearch {valueSize} {value}";
                case Commands.ContinueSearch:
                    return $"csearch {value}";
                case Commands.PokeAddress:
                    return $"poke {address} {valueSize} {value}";
                case Commands.FreezeAddress:
                    return $"afreeze {address} {valueSize} {value}";
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

        /// <summary>
        /// Determine if this is a New Search or Continue Search
        /// </summary>
        /// <returns>Command Enum: Command.StartSearch or Command.ContinueSearch</returns>
        public Commands SearchString()
        {
            if (IsNewSearch)
            {
                IsNewSearch = false;
                return Commands.StartSearch;
            }
            return Commands.ContinueSearch; 
        }

        /// <summary>
        /// Disconnect the Client
        /// </summary>
        public void Disconnect()
        {
            _mainForm.EnableForm(false,true);
            _br?.Close();
            _bw?.Close();
            _stream?.Close();
            try
            {
                SwitchSocket?.Shutdown(SocketShutdown.Both);
                SwitchSocket?.Close();
            }
            catch
            {
                //ignore
            }
            _mainForm.MySwitch = null;

            //last to close
            _listen?.Abort();
        }

        public void SendPacket(byte[] command)
        {
            List<byte> listbytecommand = new List<byte>();
            foreach (byte value in command)
            {
                listbytecommand.Add(value);
            }
            listbytecommand.Add(0x0a);//add to complete command.
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
        /// <param name="commands">Enum MakeCommandString</param>
        /// <param name="id">String:ID</param>
        /// <param name="address">String:Address</param>
        /// <param name="valueSize">String:ValueSize</param>
        /// <param name="value">String:Value</param>
        public void SendCommand(Commands commands, string id, string address, string valueSize,string value)
        {
            try
            {
                ReadDisplay = true;
                byte[] byteCommand = Encoding.Default.GetBytes(MakeCommandString(commands, id, address, valueSize, value));
                SendPacket(byteCommand);
                ClearWriteBuffer();
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Unable to send to sys-netcheat!");
                Disconnect();
            }
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
