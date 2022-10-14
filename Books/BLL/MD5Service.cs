using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace BLL
{
	public static class MD5Service
	{
		private static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

		/// <summary>
		/// 加密
		/// </summary>
		/// <param name="n_text">明文</param>
		/// <returns>密文</returns>
		public static string GetMD5CodeToString(string n_text)
		{
			byte[] u_byte = Encoding.Default.GetBytes(n_text);
			byte[] u_code = md5.ComputeHash(u_byte);
			var s = BitConverter.ToString(u_code);
			return BitConverter.ToString(u_code);
		}
		/// <summary>
		/// 解密
		/// </summary>
		/// <param name="n_path">密文</param>
		/// <returns>明文</returns>
		public static string GetMD5CodeToFile(string n_path)
		{
			FileStream u_stream = File.OpenRead(n_path);
			byte[] u_code = md5.ComputeHash(u_stream);
			return BitConverter.ToString(u_code);
		}
	}
}
