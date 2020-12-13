using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Console = Colorful.Console;

namespace HammingCode.View
{
	public class ConsoleView : IConsoleView
	{
		private Color _defaultOutColor => ColorTranslator.FromHtml("#B8DBFF");

		public void DrawTitle()
		{
			var purpleColor = ColorTranslator.FromHtml("#FF9332A8");
			Console.WriteAscii("   hamming code", purpleColor);
			Console.WriteAscii("   daniil solyanoy", purpleColor);
			Console.WriteLine();
		}

		public string GetMistakeInput()
		{
			Console.Write("Введите индекс элемента для допущения единичной ошибки: ", _defaultOutColor);
			return Console.ReadLine();
		}

		public void ShowInputError()
		{
			Console.WriteLine("Введенная строка не является двоичным кодом.", Color.MediumVioletRed);
		}

		public void ShowInput(string input)
		{
			Console.WriteLine($"Введенный код: {input}", Color.ForestGreen);
		}

		public void ShowMistakeInput(string input)
		{
			Console.WriteLine($"Введенный индекс: {input}", Color.ForestGreen);
		}

		public string GetInput()
		{
			Console.Write("Введите двоичный код: ", _defaultOutColor);
			return Console.ReadLine();
		}

		public void ShowControlBitCount(int bitsCount)
		{
			Console.WriteLine($"Количество контрольных битов: {bitsCount}", Color.ForestGreen);
		}

		public void ShowTemporaryArray(byte[] temporaryArray, int[] controlBitsIndexes)
		{
			Console.Write("Позиция контрольных битов, где ", Color.ForestGreen);
			Console.Write("X", Color.DarkGoldenrod);
			Console.Write(" -> контрольный бит: ", Color.ForestGreen);

			for (int i = 0; i < temporaryArray.Length; i++)
			{
				if (controlBitsIndexes.Contains(i))
				{
					Console.Write("X", Color.DarkGoldenrod);
				}
				else
				{
					Console.Write(temporaryArray[i], _defaultOutColor);
				}
			}

			Console.WriteLine();
		}

		public void ShowControlBitsCalculation(byte[] controlBitsResults, List<int[]> controlBitsIndexes, byte[] temporaryBitArray)
		{
			Console.WriteLine("Рассчет контрольных битов: ", Color.ForestGreen);

			for (int i = 0; i < controlBitsResults.Length; i++)
			{
				var bitResult = controlBitsResults[i];
				var bitIndexes = controlBitsIndexes[i];

				for (int j = 0; j < bitIndexes.Length; j++)
				{
					Console.Write($"a{bitIndexes[j]}" + 
						(j == 0 ? " = " 
							: $" ({temporaryBitArray[bitIndexes[j] - 1]})" + 
							  (j != bitIndexes.Length - 1 ? " + " : $" = {bitResult}")), _defaultOutColor);
				}

				Console.WriteLine();
			}
		}

		public void ShowMistakeInputError()
		{
			Console.WriteLine("Введите корректный индекс.", Color.MediumVioletRed);
		}

		public void ShowArrayWithMistake(byte[] temporaryArray, int mistakeIndex)
		{
			Console.Write("Код с допущенной ошибкой: ", Color.ForestGreen);
			for (int i = 0; i < temporaryArray.Length; i++)
			{
				Console.Write(temporaryArray[i],
					i == mistakeIndex ? Color.MediumVioletRed : _defaultOutColor);
			}
			Console.WriteLine();
		}

		public void ShowEncodedArray(byte[] temporaryArray, int[] controlBitsIndexes)
		{
			Console.Write("Зашифрованная последовательность: ", Color.ForestGreen);
			for (int i = 0; i < temporaryArray.Length; i++)
			{
				Console.Write(temporaryArray[i],
					controlBitsIndexes.Contains(i) ? Color.DarkGoldenrod : _defaultOutColor);
			}
			Console.WriteLine();
		}
	}
}