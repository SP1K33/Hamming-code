using HammingCode.Model;
using HammingCode.Presenter;
using HammingCode.View;
using System;

namespace HammingCode
{
	public static class Program
	{
		private static void Main()
		{
			IConsoleView consoleView = new ConsoleView();
			IHammingModel model = new HammingModel();
			var presenter = new Presenter.Presenter(consoleView, model);
			presenter.Start();
			Console.Read();
		}
	}
}
