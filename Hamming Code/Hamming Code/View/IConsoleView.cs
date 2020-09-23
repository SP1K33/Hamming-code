using System;

namespace HammingCode.View
{
	public interface IConsoleView
	{
		void DrawTitle();
		string GetInput();
		void ShowInputError();
		void ShowInput(string input);
	}
}