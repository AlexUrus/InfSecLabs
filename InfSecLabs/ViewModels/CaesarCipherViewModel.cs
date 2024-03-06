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
        public string InputText 
        {
            get => _cipherModel.InputText;
            set
            {
                _cipherModel.InputText = value;
                OnPropertyChanged();
            }
        }
        public string EncryptedText
        {
            get => _cipherModel.СipherText;
            set
            {
                _cipherModel.СipherText = value;
                OnPropertyChanged();
            }
        }

        private string _decryptedText;
        public string DecryptedText
        {
            get => _decryptedText;
            set
            {
                _decryptedText = value;
                OnPropertyChanged();
            }
        }

        private double _chiSquare;
        public double ChiSquare { 
            get => _chiSquare;
            set
            {
                _chiSquare = value;
                OnPropertyChanged();
            }
        }

        public ICommand EncryptTextCommand { get; private set; }
        public ICommand DecryptTextCommand { get; private set; }
        public ICommand OpenInputTextCommand { get; private set; }
        public ICommand SaveToFileCommand { get; private set; }
        

        private CipherModel _cipherModel;

        public CaesarCipherViewModel()
        {
            CaesarCipher cipher = new CaesarCipher(3);
            _cipherModel = new CipherModel(cipher);
            EncryptTextCommand = new Command(() => 
            {
                EncryptedText = _cipherModel.EncryptInputText();
                ChiSquare = Сryptanalysis.ChiSquare(EncryptedText);
            });
            DecryptTextCommand = new Command(() =>
            {
                DecryptedText = _cipherModel.DecryptText();
                
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
                    string _textToFile = $"{EncryptedText} ChiSquare = {ChiSquare}";
                    FileHandler.WriteToFile(_textToFile, filePath);
                }
            }
            catch (Exception ex)
            {
                InputText = $"Error reading file: {ex.Message}";
            }
        }

    }
}
