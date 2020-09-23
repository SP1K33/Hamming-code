namespace HammingCode.View
{
	public partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.InputSourceLabel = new System.Windows.Forms.Label();
			this.EncodeButton = new System.Windows.Forms.Button();
			this.EncodeResultLabel = new System.Windows.Forms.Label();
			this.SourceTextBox = new System.Windows.Forms.TextBox();
			this.ResultTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// InputSourceLabel
			// 
			this.InputSourceLabel.AutoSize = true;
			this.InputSourceLabel.Location = new System.Drawing.Point(9, 7);
			this.InputSourceLabel.Name = "InputSourceLabel";
			this.InputSourceLabel.Size = new System.Drawing.Size(134, 13);
			this.InputSourceLabel.TabIndex = 1;
			this.InputSourceLabel.Text = "Введите двоичное число:";
			// 
			// EncodeButton
			// 
			this.EncodeButton.Location = new System.Drawing.Point(12, 49);
			this.EncodeButton.Name = "EncodeButton";
			this.EncodeButton.Size = new System.Drawing.Size(490, 21);
			this.EncodeButton.TabIndex = 2;
			this.EncodeButton.Text = "Кодировать";
			this.EncodeButton.UseVisualStyleBackColor = true;
			// 
			// EncodeResultLabel
			// 
			this.EncodeResultLabel.AutoSize = true;
			this.EncodeResultLabel.Location = new System.Drawing.Point(9, 73);
			this.EncodeResultLabel.Name = "EncodeResultLabel";
			this.EncodeResultLabel.Size = new System.Drawing.Size(131, 13);
			this.EncodeResultLabel.TabIndex = 3;
			this.EncodeResultLabel.Text = "Результат кодирования:";
			// 
			// SourceTextBox
			// 
			this.SourceTextBox.Location = new System.Drawing.Point(12, 25);
			this.SourceTextBox.Name = "SourceTextBox";
			this.SourceTextBox.Size = new System.Drawing.Size(489, 20);
			this.SourceTextBox.TabIndex = 4;
			this.SourceTextBox.TextChanged += new System.EventHandler(this.OnSourceTextBoxChanged);
			// 
			// ResultTextBox
			// 
			this.ResultTextBox.Location = new System.Drawing.Point(12, 89);
			this.ResultTextBox.Name = "ResultTextBox";
			this.ResultTextBox.Size = new System.Drawing.Size(489, 20);
			this.ResultTextBox.TabIndex = 5;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 120);
			this.Controls.Add(this.ResultTextBox);
			this.Controls.Add(this.SourceTextBox);
			this.Controls.Add(this.EncodeResultLabel);
			this.Controls.Add(this.EncodeButton);
			this.Controls.Add(this.InputSourceLabel);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MainForm";
			this.Text = "Код Хэмминга";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label InputSourceLabel;
		private System.Windows.Forms.Button EncodeButton;
		private System.Windows.Forms.Label EncodeResultLabel;
		private System.Windows.Forms.TextBox SourceTextBox;
		private System.Windows.Forms.TextBox ResultTextBox;
	}
}

