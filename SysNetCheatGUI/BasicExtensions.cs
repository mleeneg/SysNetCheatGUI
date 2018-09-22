using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
    }
}
