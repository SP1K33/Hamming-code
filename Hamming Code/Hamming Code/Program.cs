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
			Application.Run(new MainForm());
		}
	}
}
