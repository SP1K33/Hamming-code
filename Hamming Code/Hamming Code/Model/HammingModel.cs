using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace HammingCode.Model
{
	public class HammingModel : IHammingModel
	{
		public int GetControlBitsCount(int bitArrayLength)
		{
			return (int)Math.Ceiling(Math.Log(bitArrayLength, 2)) + 1;
		}

		public int[] GetControlBitsIndexes(int bitsCount)
		{
			int[] result = new int[bitsCount];

			for (int i = 0; i < bitsCount; ++i)
			{
				result[i] = (int)Math.Pow(2, i) - 1;
			}

			return result;
		}

		private int[] CalculateControlIndexes(byte[] temporaryBitArray, int orderBitNumber)
		{
			var result = new List<int>();

			orderBitNumber++;

			for (int i = orderBitNumber; i <= temporaryBitArray.Length; i += orderBitNumber * 2)
			{
				for (int j = i; j < i + orderBitNumber; ++j)
				{
					if (j <= temporaryBitArray.Length)
					{
						result.Add(j);
					}
				}
			}

			return result.ToArray();
		}

		public (byte[], List<int[]>) CalculateControlBits(byte[] temporaryBitArray, int controlBitsCount, int[] controlBitsIndexes)
		{
			byte[] result = new byte[controlBitsCount];
			var controlIndexesList = new List<int[]>();
			for (int i = 0; i < controlBitsCount; ++i)
			{
				var controlIndexes = CalculateControlIndexes(temporaryBitArray, controlBitsIndexes[i]);
				controlIndexesList.Add(controlIndexes);

				for (var index = 0; index < controlIndexes.Length; ++index)
				{
					var idx = controlIndexes[index];
					if (idx <= temporaryBitArray.Length)
					{
						result[i] ^= temporaryBitArray[idx-1];
					}
				}
			}

			return (result, controlIndexesList);
		}

		public void MakeMistake(ref byte[] temporaryBitArray, int mistakeIndex)
		{
			var bit = temporaryBitArray[mistakeIndex];
			bit = bit == 0 ? (byte) 1 : (byte) 0;
			temporaryBitArray[mistakeIndex] = bit;
		}

		public void InsertControlBits(byte[] controlBits, int[] controlBitsIndexes, ref byte[] temporaryBitArray)
		{
			for (int i = 0, j = 0; i < temporaryBitArray.Length; i++)
			{
				if (controlBitsIndexes.Contains(i))
				{
					temporaryBitArray[i] = controlBits[j];
					++j;
				}
			}
		}

		public void InsertInfoBits(byte[] infoBits, int[] controlBitsIndexes, ref byte[] temporaryBitArray)
		{
			for (int i = 0, j = 0; i < temporaryBitArray.Length; i++)
			{
				if (!controlBitsIndexes.Contains(i) && j < infoBits.Length)
				{
					temporaryBitArray[i] = infoBits[j]; 
					++j;
				}
			}
		}
	}
}