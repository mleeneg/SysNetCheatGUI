using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SysNetCheatGUI
{
    class AddressItem
    {
        private string _description = "No Description";
        private string _valueType = "0";
        private string _address = "0";
        private string _addressValue = "0";

        public string Description
        {
            get
            {
                string decoded = DecodeEncodedNonAsciiCharacters(_description);
                return decoded;
            }
            set
            {
                string encoded = EncodeNonAsciiCharacters(value);
                _description = encoded;
            }
        }

        public string ValueType
        {
            get
            {
                return _valueType;
            }

            set
            {
                // validate the input
                if (!string.IsNullOrEmpty(value))
                {
                    switch (value)
                    {
                        case "u8":
                            _valueType = value;
                            break;
                        case "u16":
                            _valueType = value;
                            break;
                        case "u32":
                            _valueType = value;
                            break;
                        case "u64":
                            _valueType = value;
                            break;
                        default:
                            _valueType = "u32";
                            break;
                    }
                }
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                try
                {
                    ulong hex = Convert.ToUInt64(value, 16);
                    _address = hex.ToString("X");
                }
                catch
                {
                    _address = "0";
                }  
            }

        }

        public string AddressValue
        {
            get { return _addressValue;}
            set
            {
                try
                {
                    long num = 0;
                    switch (this.ValueType)
                    {
                        case "u8":
                            num = int.Parse(value);
                            if (num >= 255)
                            {
                                num = 255;
                                _addressValue = num.ToString();
                            }
                            else
                            {
                                _addressValue = num.ToString();
                            }
                            break;
                        case "u16":
                            num = int.Parse(value);
                            if (num >= ushort.MaxValue)
                            {
                                num = ushort.MaxValue;
                                _addressValue = num.ToString();
                            }
                            else
                            {
                                _addressValue = num.ToString();
                            }
                            break;
                        case "u32":
                            num = Int32.Parse(value);
                            if (num >= uint.MaxValue)
                            {
                                num = uint.MaxValue;
                                _addressValue = num.ToString();
                            }
                            else
                            {
                                _addressValue = num.ToString();
                            }
                            break;
                        case "u64":
                            num = Int64.Parse(value);
                            if (num >= Convert.ToInt64(ulong.MaxValue))
                            {
                                num = Convert.ToInt64(ulong.MaxValue);
                                _addressValue = num.ToString();
                            }
                            else
                            {
                                _addressValue = num.ToString();
                            }
                            break;
                        default:
                            num = Int32.Parse(value);
                            if (num >= uint.MaxValue)
                            {
                                num = uint.MaxValue;
                                _addressValue = num.ToString();
                            }
                            else
                            {
                                _addressValue = num.ToString();
                            }
                            break;
                    }
                }
                catch
                {
                    _addressValue = "0";
                }
                
            }
        }
        static string EncodeNonAsciiCharacters(string value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in value)
            {
                if (c > 127)
                {
                    // This character is too big for ASCII
                    string encodedValue = "\\u" + ((int)c).ToString("x4");
                    sb.Append(encodedValue);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        static string DecodeEncodedNonAsciiCharacters(string value)
        {
            return Regex.Replace(
                value,
                @"\\u(?<AddressValue>[a-zA-Z0-9]{4})",
                m => {
                    return ((char)int.Parse(m.Groups["AddressValue"].Value, NumberStyles.HexNumber)).ToString();
                });
        }
    }
}
