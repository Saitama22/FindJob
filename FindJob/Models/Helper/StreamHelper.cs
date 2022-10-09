using System.IO;

namespace FindJob.Models.Helper
{
	public static class StreamHelper
	{
		public static byte[] GetBytes(this Stream stream)
		{
			using MemoryStream ms = new();
			stream.CopyTo(ms);
			return ms.ToArray();
		}
	}
}
