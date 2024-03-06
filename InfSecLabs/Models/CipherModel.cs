using InfSecLabs.Ciphers;
using InfSecLabs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfSecLabs.Models
{
    public class CipherModel
    {
        public string InputText { get; set; }
        public string СipherText { get; set; }

        private ICipher _cipher;

        public CipherModel(ICipher cipher)
        {
            _cipher = cipher;
        }

        public string EncryptInputText()
        {
            return _cipher.Encrypt(InputText);
        }

        public string DecryptText()
        {
            return _cipher.Decrypt(СipherText);
        }
    }
}
