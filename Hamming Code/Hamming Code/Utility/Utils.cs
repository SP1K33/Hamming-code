using System;

namespace HammingCode.Utility
{
	public static class Utils
	{
		public static byte[] StringToByteArray(string source)
		{
			byte[] result = new byte[source.Length];
			for (int i = 0; i < source.Length; ++i)
			{
				result[i] = (byte)char.GetNumericValue(source[i]);
			}
			return result;
		}

		public static int BitArrayToInt(byte[] array)
		{
			int multiplier = 1;
			int bin = 0;
			for (int i = array.Length - 1; i >= 0; --i)
			{
				bin += (multiplier * array[i]);
				multiplier *= 10;
			}

			return Convert.ToInt32(bin.ToString(), 2);
		}
	}
}
