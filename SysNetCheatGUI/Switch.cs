using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
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

        public int DisplayAmount = 1000;
        //Regex address format
        private Regex _r = new Regex(@"[0-9a-fA-F]{8,}");
        //Default port for the Switch
        public int SwitchPort = 5555;
        //Ip Address
        public IPAddress IpAddress;
        //Create TCPClient
        //public Socket SwitchSocket;
        public TcpClient SwitchClient;

        //Get Client Stream for Reading and Writing
        private NetworkStream _stream;
        private BinaryReader _br;
        private BinaryWriter _bw;

        public Thread Listen;

        private FrmMain _mainForm;
        private StringBuilder _sbAddresses = new StringBuilder();

        private string _searchValue;

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
                    //SwitchSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //SwitchSocket.Connect(IpAddress, SwitchPort);
                    SwitchClient = new TcpClient();
                    SwitchClient.Connect(IpAddress,SwitchPort);
                    //Set IsConnected
                    //IsConnected = SwitchSocket.IsConnected();
                    IsConnected = SwitchClient.Connected;
                    //create stream
                    //_stream = new NetworkStream(SwitchSocket);
                    _stream = SwitchClient.GetStream();
                    _bw = new BinaryWriter(_stream);
                    _br = new BinaryReader(_stream);
                    //create thread and start it.
                    Listen = new Thread(ReceiveMessages) {IsBackground = true};
                    Listen.Start();
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
                byte[] buffer;
                int bufferSize = SwitchClient.ReceiveBufferSize;
                while (ReadDisplay)
                {
                    if (bufferSize <= 0) continue;
                    buffer = new byte[bufferSize];
                    int rec = _stream.Read(buffer, 0, bufferSize);
                    Array.Resize(ref buffer, rec);
                    string getBuffer = Encoding.Default.GetString(buffer);
                    _sbAddresses.Append(getBuffer);
                    if (!_sbAddresses.ToString().Contains("> ")) continue;
                    Debug.Write("EOF");
                    GetAddressesFromConsole();
                    //_shouldStop = true;
                    Listen.Join();
                }
            }
            catch
            {
                Disconnect(false);
            }

        }

        /// <summary>
        /// Get Addresses from console
        /// </summary>
        private void GetAddressesFromConsole()
        {
            //Get Searched Value
            _searchValue = _mainForm.txtValue.Text;
            int found = 0;
            //Turn off reading of Console.
            ReadDisplay = false;
            //If Search button was presses
            if (ClickedSearch)
            {
                //Get Matches
                MatchCollection matchList = _r.Matches(_sbAddresses.ToString());
                //Because this in a different thread must invoke lvAddress from main thread.
                found = matchList.Count;
                //Loop thru matches
                if (_mainForm.InvokeRequired)
                {
                    int i = 1;
                    foreach (var value in matchList)
                    {
                        if (i <= DisplayAmount)
                        {
                            //Make New ListViewItem
                            ListViewItem item = new ListViewItem(value.ToString());
                            item.SubItems.Add(_searchValue);
                            //Add ListViewItem to ListView
                            _mainForm.Invoke(new Action(() =>
                            {
                                _mainForm.lblCountFound.Text = $"Displaying {i}/{found}";
                                _mainForm.lvAddress.Items.Add(item);
                            }));
                            i++;
                        }
                    }
                

                }
                ClickedSearch = false;
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
                    return $"ssearch {valueSize} {value}\n";
                case Commands.ContinueSearch:
                    return $"csearch {value}\n";
                case Commands.PokeAddress:
                    return $"poke {address} {valueSize} {value}\n";
                case Commands.FreezeAddress:
                    return $"afreeze {address} {valueSize} {value}\n";
                case Commands.ListAddress:
                    return $"lfreeze\n";
                case Commands.ReleaseFreeze:
                    return $"rfreeze {address}\n";
                case Commands.UnFreezeAddress:
                    return $"dfreeze {index}\n";
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
        public void Disconnect(bool showMessage)
        {
            IsConnected = false;
            _mainForm.EnableForm(false,true);
            _br?.Close();
            _bw?.Close();
            _stream?.Close();
            try
            {
                //SwitchClient?.Shutdown(SocketShutdown.Both);
                SwitchClient?.Close();
            }
            catch
            {
                //ignore
            }
            //last to close
            _mainForm.MySwitch = null;
            Listen?.Abort();
            Listen = null;
        }

        public void SendPacket(byte[] command)
        {
            //_shouldStop = false;
            Listen = new Thread(ReceiveMessages) { IsBackground = true };
            Listen.Start();
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
                Disconnect(true);
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
