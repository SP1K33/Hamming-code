namespace HammingCode.Model
{
	public class HammingModel : IHammingModel
	{
		private byte[] _source;

		public void Encode(byte[] source)
		{
			_source = source;


		}

		public byte[] GetSourceBytes()
		{
			return _source;
		}
	}
}