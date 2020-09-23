using HammingCode.Model;
using HammingCode.Presenter;
using HammingCode.View;

namespace HammingCode
{
	public static class Program
	{
		private static void Main()
		{
			IConsoleView consoleView = new ConsoleView();
			IHammingModel model = new HammingModel();
			var presenter = new ConsolePresenter(consoleView, model);
			presenter.Start();
		}
	}
}
