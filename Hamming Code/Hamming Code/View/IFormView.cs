using System;

namespace HammingCode.View
{
	public interface IFormView
	{
		event Action<string> SourceTextChangeEvent;
		void SetSourceText(string source);
	}
}