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
	}
}
