using System;
namespace ptj_server.Helpers
{
	public class GuidHelper
	{
        public string GenerateOrderCode()
        {
            string orderCode = GenerateUniqueCode(6);
            return orderCode;
        }

        private string GenerateUniqueCode(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] codeChars = new char[length];
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                codeChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(codeChars);
        }
    }
}

