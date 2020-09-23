using System;
using System.Windows.Forms;
using HammingCode.Model;
using HammingCode.Presenter;
using HammingCode.View;

namespace HammingCode
{
	public static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			IFormView formView = new MainForm();
			IConsoleView consoleView = new ConsoleView();

			IHammingModel model = new HammingModel();

			var formPresenter = new FormPresenter(formView, model);
			var consolePresenter = new ConsolePresenter(consoleView, model);

			Application.Run((MainForm)formView);
		}
	}
}
