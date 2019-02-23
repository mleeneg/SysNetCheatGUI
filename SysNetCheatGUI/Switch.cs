using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

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
        private BinaryReader _br;
        private BinaryWriter _bw;

        private Thread _listen;

        private readonly FrmMain _mainForm;

        //Regex address format: Get numbers and letters a-f that are 8 characters or higher
        private readonly Regex _r = new Regex(@"[0-9a-fA-F]{8,}");
        private readonly StringBuilder _sbAddresses = new StringBuilder();

        private string _searchValue;

        //Get Client Stream for Reading and Writing
        private NetworkStream _stream;
        public bool ClickedSearch;

        public int DisplayAmount = 1000;

        //Ip Address
        public IPAddress IpAddress;

        public bool IsConnected;
        public bool IsNewSearch = true;

        public bool ReadDisplay = true;

        //public Socket SwitchSocket;
        public TcpClient SwitchClient;

        //Default port for the Switch
        public int SwitchPort = 5555;

        public Switch(FrmMain mainForm)
        {
            _mainForm = mainForm;
        }

        /// <summary>
        ///     Connect to Switch IP Address
        /// </summary>
        /// <param name="ip">127.0.0.1 as Example</param>
        public void Connect(string ip)
        {
            //If Socket is false create client
            if (IsConnected == false)
                try
                {
                    IpAddress = IPAddress.Parse(ip);
                    //Connect Client
                    SwitchClient = new TcpClient();
                    SwitchClient.Connect(IpAddress, SwitchPort);
                    //Set IsConnected
                    IsConnected = SwitchClient.Connected;
                    //create stream
                    _stream = SwitchClient.GetStream();
                    _bw = new BinaryWriter(_stream);
                    _br = new BinaryReader(_stream);
                    //create thread and start it.
                    _listen = new Thread(ReceiveMessages) {IsBackground = true};
                    _listen.Start();
                }
                catch
                {
                    MessageBox.Show("Could Not Connect");
                    _mainForm.MySwitch = null;
                }
        }

        /// <summary>
        ///     Will receive messages from console.
        /// </summary>
        public void ReceiveMessages()
        {
            try
            {
                byte[] buffer;
                var bufferSize = SwitchClient.ReceiveBufferSize;
                while (ReadDisplay)
                {
                    if (bufferSize <= 0) continue;
                    buffer = new byte[bufferSize];
                    var rec = _stream.Read(buffer, 0, bufferSize);
                    Array.Resize(ref buffer, rec);
                    var getBuffer = Encoding.Default.GetString(buffer);
                    _sbAddresses.Append(getBuffer);
                    if (!_sbAddresses.ToString().Contains("> ")) continue;
                    Debug.Write("EOF");
                    GetAddressesFromConsole();
                    //_shouldStop = true;
                    //_listen.Join();
                }
            }
            catch
            {
                Disconnect(false);
            }
        }

        /// <summary>
        ///     Get Addresses from console
        /// </summary>
        private void GetAddressesFromConsole()
        {
            //Get Searched AddressValue
            _searchValue = _mainForm.txtValue.Text;
            int found;
            //Turn off reading of Console.
            ReadDisplay = false;
            //If Search button was presses
            if (ClickedSearch)
            {
                //Get Matches
                var matchList = _r.Matches(_sbAddresses.ToString());
                //Because this in a different thread must invoke lvAddress from main thread.
                found = matchList.Count;
                //Loop thru matches
                if (_mainForm.InvokeRequired)
                {
                    var displayCount = 1;
                    foreach (var value in matchList)
                        if (displayCount <= DisplayAmount)
                        {
                            //Make New ListViewItem
                            var item = new ListViewItem(value.ToString().ToUpper());
                            item.SubItems.Add(_searchValue);
                            //Add ListViewItem to ListView
                            _mainForm.Invoke(new Action(() =>
                            {
                                _mainForm.lblCountFound.Text = $"Displaying {displayCount}/{found}";
                                _mainForm.lvAddress.Items.Add(item);
                            }));
                            displayCount++;
                        }
                }

                ClickedSearch = false;
            }
        }

        /// <summary>
        ///     Clear Addresses in String Builder
        /// </summary>
        public void ClearAddresses()
        {
            _sbAddresses.Clear();
        }

        /// <summary>
        ///     Create string command to be sent to server.
        /// </summary>
        /// <param name="commands">Command Enum: Command Indicator</param>
        /// <param name="index">string: Freeze Index - Can be empty but not null</param>
        /// <param name="address">string: Address - Can be empty but not null</param>
        /// <param name="valueSize">string: AddressValue Size - Can be empty but not null</param>
        /// <param name="value">string: AddressValue - Can be empty but not null</param>
        /// <returns></returns>
        public string MakeCommandString(Commands commands, ListViewItem Item)
        {
            string valueType = Item.SubItems[_mainForm.GetColumnID(_mainForm.lvStoredAddresses,"cValueType")].Text;
            string value = Item.SubItems[_mainForm.GetColumnID(_mainForm.lvStoredAddresses, "cValue")].Text;
            string address = Item.SubItems[_mainForm.GetColumnID(_mainForm.lvStoredAddresses,"cAddress")].Text;
            string index = Item.SubItems[_mainForm.GetColumnID(_mainForm.lvStoredAddresses,"cID")].Text;

            switch (commands)
            {
                case Commands.StartSearch:
                    return $"ssearch {valueType} {value}\n";
                case Commands.ContinueSearch:
                    return $"csearch {value}\n";
                case Commands.PokeAddress:
                    return $"poke {address} {valueType} {value}\n";
                case Commands.FreezeAddress:
                    return $"afreeze {address} {valueType} {value}\n";
                case Commands.ListAddress:
                    return "lfreeze\n";
                case Commands.ReleaseFreeze:
                    return $"rfreeze {address}\n";
                case Commands.UnFreezeAddress:
                    return $"dfreeze {index}\n";
                default:
                    throw new ArgumentOutOfRangeException(nameof(commands), commands, null);
            }
        }
        public string MakeCommandString(Commands commands, string index, string address, string valueSize, string value)
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
        ///     Determine if this is a New Search or Continue Search
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
        ///     Disconnect the Client
        /// </summary>
        public void Disconnect(bool showMessage)
        {
            IsConnected = false;
            _mainForm.EnableForm(false, true);
            _br?.Close();
            _bw?.Close();
            _stream?.Close();
            try
            {
                SwitchClient?.Close();
            }
            catch
            {
                //ignore
            }

            //last to close
            _mainForm.MySwitch = null;
            _listen?.Abort();
            _listen = null;
        }

        public void SendPacket(byte[] command)
        {
            _listen = new Thread(ReceiveMessages) {IsBackground = true};
            _listen.Start();
            _bw.Write(command);
        }

        public void ClearWriteBuffer()
        {
            _bw.Flush();
        }

        /// <summary>
        ///     Sends command to sys-netcheat
        /// </summary>
        /// <param name="commands">Enum MakeCommandString</param>
        /// <param name="id">String:ID</param>
        /// <param name="address">String:Address</param>
        /// <param name="valueSize">String:ValueType</param>
        /// <param name="value">String:AddressValue</param>
        public void SendCommand(Commands commands, ListViewItem Item)
        {
            try
            {
                ReadDisplay = true;
                var byteCommand = Encoding.Default.GetBytes(MakeCommandString(commands, Item));
                SendPacket(byteCommand);
                ClearWriteBuffer();
            }
            catch (IOException)
            {
                Disconnect(true);
            }
        }
        public void SendCommand(Commands commands, string id, string address, string valueSize, string value)
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
        ///     Search for Byte in Byte array
        /// </summary>
        /// <param name="array">Collection of bytes to look into</param>
        /// <param name="pattern">Byte to look for</param>
        /// <param name="offset">Where to Start</param>
        /// <returns></returns>
        public static int IndexOf(byte[] array, byte[] pattern, int offset)
        {
            var success = 0;
            for (var i = offset; i < array.Length; i++)
            {
                if (array[i] == pattern[success])
                    success++;
                else
                    success = 0;

                if (pattern.Length == success) return i - pattern.Length + 1;
            }

            return -1;
        }
    }
}