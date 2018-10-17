using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysNetCheatGUI
{
    public static class Extensions
    {
        public static byte[] RemoveBytes(this byte[] bytes, int start, int count)
        {
            var list = bytes.ToList();
            list.RemoveRange(start, count);
            return list.ToArray();
        }

        public static bool Contains(this byte[] bytes, byte value)
        {
            return Array.IndexOf(bytes, value) > -1;
        }

        public static byte[] Truncate(this byte[] bytes, int count)
        {
            var array = new byte[count];
            Array.Copy(bytes, array, count);
            return array;
        }

        public static int SelectedIndex(this ListView listView)
        {
            if (listView.SelectedIndices.Count > 0)
                return listView.SelectedIndices[0];
            else
                return 0;
        }

        public static bool IsConnected(this Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectError) && socket.Available == 0);
            }
            catch (SocketException) { return false; }
        }
    }
}
