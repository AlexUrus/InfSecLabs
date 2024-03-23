using InfSecLabs.Ciphers;
using InfSecLabs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InfSecLabs.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public ICommand EncryptTextCommand { get; protected set; }
        public ICommand DecryptTextCommand { get; protected set; }

        protected CipherModel _cipherModel;
        protected ICipher _cipher;
    }
}
