namespace EndLess.Domain.Helpeers
{
    public static class StringHelpers
    {
        // c# extensio methods
        public static string Encrypt(this string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return "";

            texto += "|ef8f15a7-5a68-4184-9636-843097a51c66";
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(System.Text.Encoding.GetEncoding(0).GetBytes(texto));
            var sbString = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));
            return sbString.ToString();
        }
    }
}
