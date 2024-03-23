using InfSecLabs.Ciphers;
using InfSecLabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InfSecLabs.ViewModels
{
    public class ByteCodingViewModel : BaseViewModel
    {
        public ByteCodingViewModel()
        {
            _cipher = new ByteCodingCipher();
            _cipherModel = new CipherModel(_cipher);
            EncryptTextCommand = new Command(() =>
            {
                EncryptedText = InputText != null ? _cipherModel.EncryptInputText(InputText) : string.Empty;
            });
            DecryptTextCommand = new Command(() =>
            {
                DecryptedText = DecryptedText != null ? _cipherModel.DecryptText(EncryptedText) : string.Empty;
            });
        }
    }
}
