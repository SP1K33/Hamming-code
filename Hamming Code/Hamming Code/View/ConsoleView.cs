using System.Drawing;
using System.Runtime.CompilerServices;
using Console = Colorful.Console;

namespace HammingCode.View
{
	public class ConsoleView : IConsoleView
	{
		private Color _purpleColor => ColorTranslator.FromHtml("#FF9332A8");
		private Color _defaultOutColor => ColorTranslator.FromHtml("#B8DBFF");

		public void DrawTitle()
		{
			Console.WriteAscii("   Hamming code", _purpleColor);
			Console.WriteAscii("   by SP1K3", _purpleColor);
			Console.WriteLine();
		}

		public void ShowInputError()
		{
			Console.WriteLine("Введенная строка не является двоичным кодом", Color.MediumVioletRed);
		}

		public void ShowInput(string input)
		{
			Console.WriteLine($"Введенный код: {input}", Color.ForestGreen);
		}

		public string GetInput()
		{
			Console.Write("Введите двоичный код: ", _defaultOutColor);
			return Console.ReadLine();
		}
	}
}