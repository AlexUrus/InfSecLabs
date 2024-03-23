using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfSecLabs.Ciphers
{
    public class CaesarCipher : ICipher
    {
        public int? Shift { get; set; }

        public CaesarCipher(int shift)
        {
            Shift = shift;
        }

        public string Encrypt(string text)
        {
            return Encrypt(text, Shift.Value);
        }

        public string Decrypt(string text)
        {
            return Encrypt(text, 32 - Shift.Value);
        }

        private string Encrypt(string text, int shift)
        {
            char[] result = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (char.IsLetter(ch))
                {
                    char offset = char.IsUpper(ch) ? 'А' : 'а';
                    result[i] = (char)(((ch + shift - offset) % 32) + offset);
                }
                else
                {
                    result[i] = ch;
                }
            }
            return new string(result);
        }
    }
}
