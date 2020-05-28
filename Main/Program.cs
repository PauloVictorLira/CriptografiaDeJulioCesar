using System;

namespace Main
{
	class Program
	{
		static void Main(string[] args)
		{
			var cesarCypher = new Codenation.Challenge.CesarCypher();

			Console.WriteLine("Insira a mensagem à criptografar:");
			string message = Console.ReadLine();

			//string message = "the quick brown fox jumps over the lazy dog";

			string cryptedMessage = cesarCypher.Crypt(message);
			
			Console.WriteLine(cryptedMessage);

			string decryptedMessage = cesarCypher.Decrypt(cryptedMessage);

			Console.WriteLine(decryptedMessage);
		}
	}
}
