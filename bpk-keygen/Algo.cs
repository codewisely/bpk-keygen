using System;

namespace bpk_keygen
{
    sealed internal class Algo : Form1
    {
        public Algo()
        {
            throw new Exception("No parameters!");
        }

        public Algo(string p)
        {
            user = p;
            if (user.Length < 1 || user.Length > 16 || user.Contains("_") || user.Contains("/") || user.Contains(":"))
            {
                IsSerial = false;
                serial = "Invalid name!";
                return;
            }
            char userChar, curChar;

            foreach (char magicChar in magic)
            {
                userChar = user[count % user.Length];
                curChar = (char)(magicChar ^ userChar);
                curChar %= (char)0x19;
                curChar += (char)0x41;

                serial += curChar;
                count += 1;
            }
            IsSerial = true;
            count = 0;
        }

        internal string showSerial()
        {
            return serial;
        }

        internal bool IsSerial = false;
        private string user;
        private string serial;
        private int count = 0;
        private string magic = "_r <()<1-Z2[l5,^";
    }
}
