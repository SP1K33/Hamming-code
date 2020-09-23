using System;
using System.Text.RegularExpressions;
using HammingCode.Model;
using HammingCode.Utility;
using HammingCode.View;

namespace HammingCode.Presenter
{
	public class FormPresenter
	{
		public FormPresenter(IFormView view, IHammingModel model)
		{
			_view = view;
			_model = model;

			_view.SourceTextChangeEvent += OnSourceTextChanged;
		}

		private readonly IFormView _view;
		private readonly IHammingModel _model;

		private void OnSourceTextChanged(string source)
		{
			source = Regex.Replace(source, "[^0-1]+", string.Empty);
			source = source.TrimStart('0');
			_view.SetSourceText(source);
		}

	}
}