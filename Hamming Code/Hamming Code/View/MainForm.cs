using System;
using System.Windows.Forms;

namespace HammingCode.View
{
	public partial class MainForm : Form, IFormView
	{
		public MainForm()
		{
			InitializeComponent();
		}

		public event Action<string> EncodeButtonClickEvent;

		private void OnEncodeButtonClicked(object sender, EventArgs e)
		{
			EncodeButtonClickEvent?.Invoke(SourceTextBox.Text);
		}

		public void ShowEncodeResult(string result)
		{
			ResultTextBox.Text = result;
		}

		public void ShowError(string error)
		{
			MessageBox.Show(error, "", MessageBoxButtons.OK);
		}
	}
}
