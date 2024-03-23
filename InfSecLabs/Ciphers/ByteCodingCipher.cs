using InfSecLabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfSecLabs.Ciphers
{
    public class ByteCodingCipher : ICipher
    {
        public int? Shift { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<SymbolTableModel> symbolTableModels { get; set; } = new List<SymbolTableModel>();

        public string Decrypt(string text)
        {
            foreach (var c in text)
            {
                SwapBytes(c);
            }
            return text;
        }

        public string Encrypt(string text)
        {
            throw new NotImplementedException();
        }

        private static char SwapBytes(char symbol)
        {
            string hexRepresentation = ((int)symbol).ToString("X4");
            string swappedHex = string.Concat(hexRepresentation.AsSpan(2, 2), hexRepresentation.AsSpan()[..2]);
            char swappedSymbol = (char)Convert.ToInt32(swappedHex, 16);

            return swappedSymbol;
        }
    }
}
