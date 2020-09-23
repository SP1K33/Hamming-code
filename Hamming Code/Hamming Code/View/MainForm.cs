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

		public event Action<string> SourceTextChangeEvent;

		public void SetSourceText(string source)
		{
			SourceTextBox.Text = source;
			SourceTextBox.SelectionStart = SourceTextBox.Text.Length;
			SourceTextBox.SelectionLength = 0;
		}

		private void OnSourceTextBoxChanged(object sender, EventArgs e)
		{
			SourceTextChangeEvent?.Invoke(SourceTextBox.Text);
		}
	}
}
