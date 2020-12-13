using System.Collections.Generic;

namespace HammingCode.Model
{
	public interface IHammingModel
	{
		int GetControlBitsCount(int bitArrayLength);
		int[] GetControlBitsIndexes(int bitsCount);
		void InsertInfoBits(byte[] infoBits, int[] controlBitsIndexes, ref byte[] temporaryBitArray);
		void InsertControlBits(byte[] controlBits, int[] controlBitsIndexes, ref byte[] temporaryBitArray);
		(byte[], List<int[]>) CalculateControlBits(byte[] temporaryBitArray, int controlBitsCount, int[] controlBitsIndexes);
		void MakeMistake(ref byte[] temporaryBitArray, int mistakeIndex);
		byte[] CalculateCheckSum(byte[] temporaryBitArray);
	}
}