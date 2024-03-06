using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfSecLabs.Services
{
    public static class Сryptanalysis
    {
        private static double[] _expectedFrequencies = { 0.0808, 0.0717, 0.0662, 0.048, 0.0473, 0.0454, 0.0434, 0.0349, 0.0321, 0.0298, 0.0281, 0.0262,
                                                         0.0253, 0.023, 0.0211, 0.0189, 0.017, 0.0165, 0.0159, 0.0144, 0.014, 0.0121, 0.0097,
                                                         0.0094, 0.0073, 0.0064, 0.0049, 0.0036, 0.0034, 0.0026, 0.002, 0.0016, 0.0004 };
        public static double ChiSquare(string text)
        {
            // Преобразуйте текст в нижний регистр и удалите все символы, кроме букв
            text = text.ToLower();
            text = new string(text.Where(char.IsLetter).ToArray());

            // Создайте словарь для подсчета фактической частоты букв
            Dictionary<char, int> actualFrequencies = new Dictionary<char, int>();
            foreach (char letter in text)
            {
                if (actualFrequencies.ContainsKey(letter))
                    actualFrequencies[letter]++;
                else
                    actualFrequencies[letter] = 1;
            }

            // Рассчитайте хи-квадрат Пирсона
            double chiSquare = 0;
            for (int i = 0; i < _expectedFrequencies.Length; i++)
            {
                char letter = (char)('а' + i); // буквы алфавита
                double expected = _expectedFrequencies[i] * text.Length;
                double observed = actualFrequencies.ContainsKey(letter) ? actualFrequencies[letter] : 0;
                chiSquare += Math.Pow(observed - expected, 2) / expected;
            }

            return chiSquare;
        }
    }
}
