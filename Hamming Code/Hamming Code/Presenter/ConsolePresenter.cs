using System;
using HammingCode.Model;
using HammingCode.Utility;
using HammingCode.View;

namespace HammingCode.Presenter
{
	public class ConsolePresenter
	{
		public ConsolePresenter(IConsoleView view, IHammingModel model)
		{
			_model = model;
			_view = view;
		}

		private IHammingModel _model;
		private IConsoleView _view;
	}
}