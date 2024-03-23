using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfSecLabs.Ciphers
{
    public interface ICipher
    {
        public int? Shift { get; set; }
        public string Encrypt(string text);
        public string Decrypt(string text);
    }
}
