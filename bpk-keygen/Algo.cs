using System;

namespace bpk_keygen {

    sealed internal class Algo : Form1 {

        public Algo() { throw new Exception("No parameters!"); }

        public Algo(string p) {

            user = p;
            
            if (user.Length < 1 || user.Length > 16 || 
                user.Contains("_") || user.Contains("/") || user.Contains(":")) {

                IsSerial = false;
                serial = "Invalid name!";
                return;

            }

            char current;
            foreach (char m in magic) {

                current = (char)(m ^ user[pos % user.Length]);
                current %= (char)0x19;
                current += (char)0x41;
                
                serial += current;
                pos += 1;

            }

            IsSerial = true;
            pos = 0;

        }

        internal string showSerial() { return serial; }

        internal bool IsSerial = false;
        private string user, serial, magic = "_r <()<1-Z2[l5,^";
        private int pos = 0;

    }

}
