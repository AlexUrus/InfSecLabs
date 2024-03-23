using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfSecLabs.Models
{
    public class SymbolTableModel
    {
        public char Symbol { get; set; }
        public string SymbolCode10 { get => Convert.ToString(Symbol, 10); }
        public string SymbolCode2 { get => Convert.ToString(Symbol, 2); }
        public int LeftByte { get; set; }
        public int RightByte { get; set; }
        public int XORByte { get; set; }

        public SymbolTableModel(char symbol, int leftByte, int rightByte, int xORByte)
        {
            Symbol = symbol;
            LeftByte = leftByte;
            RightByte = rightByte;
            XORByte = xORByte;
        }
    }
}
