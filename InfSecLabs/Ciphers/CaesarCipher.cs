using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfSecLabs.Ciphers
{
    public class CaesarCipher : ICipher
    {
        private int _shift;

        public int Shift
        {
            get => _shift;
            set => _shift = value;
        }

        public CaesarCipher(int shift)
        {
            Shift = shift;
        }

        public string Encrypt(string text)
        {
            return Encrypt(text, Shift);
        }

        public string Decrypt(string text)
        {
            return Encrypt(text, 32 - Shift);
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
