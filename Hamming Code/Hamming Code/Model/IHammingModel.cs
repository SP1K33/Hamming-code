using System;

namespace HammingCode.Model
{
	public interface IHammingModel
	{
		byte[] GetSourceBytes();
		void Encode(byte[] source);
	}
}