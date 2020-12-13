using System;
using System.Collections.Generic;

namespace HammingCode.View
{
	public interface IConsoleView
	{
		void DrawTitle();
		string GetInput();
		string GetMistakeInput();
		void ShowInputError();
		void ShowInput(string input);
		void ShowMistakeInput(string input);
		void ShowControlBitCount(int bitsCount);
		void ShowTemporaryArray(byte[] temporaryArray, int[] controlBitsIndexes);
		void ShowEncodedArray(byte[] temporaryArray, int[] controlBitsIndexes);
		void ShowControlBitsCalculation(byte[] controlBitsResults, List<int[]> controlBitsIndexes, byte[] temporaryBitArray);
		void ShowMistakeInputError();
		void ShowArrayWithMistake(byte[] temporaryArray, int mistakeIndex);
	}
}