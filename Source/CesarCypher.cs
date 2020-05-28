using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        private readonly char[] _alfabeto = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i).ToArray();
        private readonly int _numeroCasas = 3;

        private void CheckExceptions(string mensagem)
        {
            string pattern = @"[^a-zA-Z0-9 ]";
            if (string.IsNullOrEmpty(mensagem))
            {
                throw new ArgumentNullException();
            }
            else if (Regex.IsMatch(mensagem, pattern))
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public string Crypt(string message)
        {
            CheckExceptions(message);

            message = message.ToLower();

            char[] messageArray = message.ToCharArray();

            for (int i = 0; i < messageArray.Length; i++)
            {
                for (int j = 0; j < _alfabeto.Length; j++)
                {
                    if (messageArray[i].Equals(_alfabeto[j]))
                    {
                        if ((_alfabeto[j] + _numeroCasas) > _alfabeto.Length)
                        {
                            var letra = j + _numeroCasas;
                            messageArray[i] = _alfabeto[(letra) % _alfabeto.Length];
                            break;

                        }
                        else
                        {                            
                            messageArray[i] = _alfabeto[j + _numeroCasas];
                            break;
                        }
                    }
                }
            }
            string messageCrypted = new string(messageArray);

            return messageCrypted;
        }

        public string Decrypt(string cryptedMessage)
        {
            CheckExceptions(cryptedMessage);

            cryptedMessage = cryptedMessage.ToLower();

            char[] messageArray = cryptedMessage.ToCharArray();

            for (int i = 0; i < messageArray.Length; i++)
            {
                for (int j = 0; j < _alfabeto.Length; j++)
                {
                    if (messageArray[i].Equals(_alfabeto[j]))
                    {
                        if ((j - _numeroCasas) < 0)
                        {
                            var letra = j - _numeroCasas;
                            messageArray[i] = _alfabeto[_alfabeto.Length + (letra)];
                            break;
                        }
                        else
                        {
                            messageArray[i] = _alfabeto[j - _numeroCasas];
                            break;
                        }
                    }
                }
            }
            string messageDecrypted = new string(messageArray);

            return messageDecrypted;
        }
    }
}
