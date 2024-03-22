using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfSecLabs.Ciphers
{
    public class Trithemius : ICipher 
    {
        public int Shift { get; set; }

        private readonly int _alphabetSize = 32;

        public Trithemius(int shift)
        {
            Shift = shift;
        }


        public string Decrypt(string text)
        {
            return Decrypt(text, _alphabetSize - Shift);
        }

        public string Encrypt(string text)
        {
            return Encrypt(text, Shift);
        }

        public string Encrypt(string input, int shift)
        {
            input = input.Replace('Ё', 'Е');
            input = input.Replace('ё', 'е');

            char[] result = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                char originalChar = input[i];
                char encryptedChar = EncryptChar(originalChar, shift);
                result[i] = encryptedChar;
                shift++;
            }
            return new string(result);
        }

        public string Decrypt(string input, int shift)
        {

            char[] result = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                char originalChar = input[i];
                char encryptedChar = DecryptChar(originalChar, shift);
                result[i] = encryptedChar;
                shift--;
            }
            return new string(result);
        }

        private char EncryptChar(char c, int shift)
        {
            if (!char.IsLetterOrDigit(c))
                return c;

            char baseChar = char.IsUpper(c) ? 'А' : 'а';
            int alphabetIndex = c - baseChar;
            int shiftedIndex = (alphabetIndex + shift) % _alphabetSize; 
            char encryptedChar = (char)(baseChar + shiftedIndex);
            return encryptedChar;
        }

        private char DecryptChar(char c, int shift)
        {
            if (!char.IsLetterOrDigit(c))
                return c;

            char baseChar = char.IsUpper(c) ? 'А' : 'а'; 
            int alphabetIndex = c + baseChar;
            int shiftedIndex = (alphabetIndex + shift) % _alphabetSize;
            char encryptedChar = (char)(baseChar + (shiftedIndex % _alphabetSize));
            return encryptedChar;
        }
    }
}
