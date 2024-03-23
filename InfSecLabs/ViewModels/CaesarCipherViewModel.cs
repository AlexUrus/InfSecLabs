using InfSecLabs.Ciphers;
using InfSecLabs.Models;
using InfSecLabs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InfSecLabs.ViewModels
{
    public class CaesarCipherViewModel : BaseViewModel
    {

        private double _chiSquare;
        public double ChiSquare { 
            get => _chiSquare;
            set
            {
                _chiSquare = value;
                OnPropertyChanged();
            }
        }
        public int Shift
        {
            get => _cipher.Shift.GetValueOrDefault();
            set
            {
                _cipher.Shift = value;
                OnPropertyChanged();
            }
        }
        public ICommand OpenInputTextCommand { get; private set; }
        public ICommand SaveToFileCommand { get; private set; }
        
        public CaesarCipherViewModel()
        {
            _cipher = new CaesarCipher(3);
            _cipherModel = new CipherModel(_cipher);
            EncryptTextCommand = new Command(() => 
            {
                EncryptedText = InputText != null ? _cipherModel.EncryptInputText(InputText) : string.Empty;
            });
            DecryptTextCommand = new Command(() =>
            {
                DecryptedText = DecryptedText != null ? _cipherModel.DecryptText(EncryptedText) : string.Empty;
            });
            OpenInputTextCommand = new Command(ChooseFile);
            SaveToFileCommand = new Command(SaveToFile);
        }

        public async void ChooseFile()
        {
            try
            {
                var fileResult = await FilePicker.PickAsync();
                if (fileResult != null)
                {
                    string filePath = fileResult.FullPath;
                    InputText = FileHandler.ReadFromFile(filePath);
                }
            }
            catch (Exception ex)
            {
                InputText = $"Error reading file: {ex.Message}";
            }
        }

        public async void SaveToFile()
        {
            try
            {
                var fileResult = await FilePicker.PickAsync();
                if (fileResult != null)
                {
                    string filePath = fileResult.FullPath;
                    string _textToFile = $"{EncryptedText} \n" +
                        $"{GetCryptanalysis()}";
                    FileHandler.WriteToFile(_textToFile, filePath);
                }
            }
            catch (Exception ex)
            {
                InputText = $"Error reading file: {ex.Message}";
            }
        }

        private string GetCryptanalysis()
        {
            var sb = new StringBuilder();
            for (int shift = 0; shift < 32; shift++)
            {
                var cipher = new CaesarCipher(shift);
                var cipherModel = new CipherModel(cipher);
                var decryptedText = cipherModel.DecryptText(EncryptedText);
                string decryptedTextFormat;

                if (decryptedText.Length > 20)
                {
                    decryptedTextFormat = decryptedText.Remove(19);
                }
                else
                {
                    decryptedTextFormat = decryptedText;
                }

                var chiSquare = Сryptanalysis.ChiSquare(decryptedText);
                sb.AppendLine($"shift = {shift}, DecryptedText = {decryptedTextFormat}, ChiSquare = {chiSquare}");
            }
            return sb.ToString();
        }

    }
}
