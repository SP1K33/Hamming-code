using System;
using System.Linq;
using System.Text.RegularExpressions;
using HammingCode.Model;
using HammingCode.Utility;
using HammingCode.View;

namespace HammingCode.Presenter
{
	public class Presenter
	{
		public Presenter(IConsoleView view, IHammingModel model)
		{
			_model = model;
			_view = view;
		}

		private readonly IHammingModel _model;
		private readonly IConsoleView _view;

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

			var infoBits = ProcessInput();

			var controlBitsCount = _model.GetControlBitsCount(infoBits.Length);
			_view.ShowControlBitCount(controlBitsCount);

			var controlBitsIndexes = _model.GetControlBitsIndexes(controlBitsCount);
			var temporaryBitArray = new byte[infoBits.Length + controlBitsCount];
			_model.InsertInfoBits(infoBits, controlBitsIndexes, ref temporaryBitArray);
			_view.ShowTemporaryArray(temporaryBitArray, controlBitsIndexes);

			var controlBits = _model.CalculateControlBits(temporaryBitArray, controlBitsCount, controlBitsIndexes);
			_model.InsertControlBits(controlBits.Item1, controlBitsIndexes, ref temporaryBitArray);
			_view.ShowControlBitsCalculation(controlBits.Item1, controlBits.Item2, temporaryBitArray);
			_view.ShowEncodedArray(temporaryBitArray, controlBitsIndexes);


			var mistakeIndex = ProcessMistakeInput(temporaryBitArray.Length);
			_model.MakeMistake(ref temporaryBitArray, mistakeIndex);
			_view.ShowArrayWithMistake(temporaryBitArray, mistakeIndex);

			controlBits = _model.CalculateControlBits(temporaryBitArray, controlBitsCount, controlBitsIndexes);
			_view.ShowControlBitsCalculation(controlBits.Item1, controlBits.Item2, temporaryBitArray);
			var mistakeNumber = Utils.BitArrayToInt(controlBits.Item1.Reverse().ToArray());
			_view.ShowMistakeNumber(mistakeNumber);
			_model.MakeMistake(ref temporaryBitArray, mistakeNumber - 1);
			_view.ShowMistakeFix(temporaryBitArray, mistakeIndex);
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

		private int ProcessMistakeInput(int arrayLength)
		{
			InputResult inputResult;
			int result = 0;
			while ((inputResult = TryGetMistakeInput(arrayLength)).State != InputResult.InputState.Incorrect)
			{
				var enteredText = inputResult.EnteredText;
				result = int.Parse(enteredText);
				break;
			}
			_view.ShowMistakeInput(inputResult.EnteredText);
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

		private InputResult TryGetMistakeInput(int arrayLength)
		{
			var input = string.Empty;
			var state = InputResult.InputState.Incorrect;

			while (state == InputResult.InputState.Incorrect)
			{
				input = _view.GetMistakeInput();

				if (!string.IsNullOrEmpty(input)
				    && !string.IsNullOrWhiteSpace(input)
				    && !Regex.IsMatch(input, "[^0-9]+")
				    && input.Length == 1
				    && int.Parse(input) < arrayLength)
				{
					state = InputResult.InputState.Success;
				}
				else
				{
					_view.ShowMistakeInputError();
				}
			}

			return new InputResult(state, input);
		}
	}
}