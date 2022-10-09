namespace FindJob.Models.Helper
{
	public static class StringHelper
	{
		public static string IfIsNullorEmpty(this string str1, string str2)
		{
			if (string.IsNullOrEmpty(str1))
				return str2;
			return str1;
		}
	}
}
