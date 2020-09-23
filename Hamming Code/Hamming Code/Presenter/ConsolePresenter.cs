using System;
using System.Text.RegularExpressions;
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

		~ConsolePresenter()
		{

		}

		private IHammingModel _model;
		private IConsoleView _view;

		private struct InputResult
		{
			public InputResult(InputState state, string enteredText)
			{
				State = state;
				EnteredText = enteredText;
			}

			public enum InputState { Success = 0, Incorrect }

			public InputState State { get; private set; }
			public string EnteredText { get; private set; }
		}

		public void Start()
		{
			_view.DrawTitle();

			var bytes = ProcessInput();
			
		}

		private byte[] ProcessInput()
		{
			InputResult inputResult;
			byte[] result = null;
			while ((inputResult = TryGetInput()).State != InputResult.InputState.Incorrect)
			{
				var enteredText = inputResult.EnteredText;
				enteredText = enteredText.TrimStart('0');
				result = Utils.StringToByteArray(enteredText);
				break;
			}
			_view.ShowInput(inputResult.EnteredText);
			return result;
		}

		private InputResult TryGetInput()
		{
			var input = string.Empty;
			var state = InputResult.InputState.Incorrect;

			while (state == InputResult.InputState.Incorrect)
			{
				input = _view.GetInput();

				if (!string.IsNullOrEmpty(input)
					&& !string.IsNullOrWhiteSpace(input)
					&& !Regex.IsMatch(input, "[^0-1]+"))
				{
					state = InputResult.InputState.Success;
				}
				else
				{
					_view.ShowInputError();
				}
			}

			return new InputResult(state, input);
		}
	}
}