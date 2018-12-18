using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CRM.Extensions
{
    public static class StringExtensionMethods
    {
        public static string CamelCase(this String str)
        {
            string val = str;

            try
            {
                System.Globalization.TextInfo myTi = new System.Globalization.CultureInfo("en-GB", false).TextInfo;
                val = myTi.ToTitleCase(str);
            }
            catch (Exception)
            {
                //Unable to convert case...                
            }

            return val;
        }

        public static string DisplayCase(this String str)
        {
            StringBuilder sb = new StringBuilder();
            string[] val = str.Split(' ');

            if (val.Length > 0)
            {
                foreach (var x in val)
                {
                    string lowered = x.ToLower();
                    lowered = lowered.Substring(0, 1).ToUpper() + (lowered.Length > 1 ?
                        lowered.Substring(1, lowered.Length - 1) : "");
                    sb.Append(lowered);
                    sb.Append(" ");
                }
            }

            return sb.ToString().Trim();
        }

        /// <summary>
        /// If string value is Empty - Blank return True
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(this String str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static string ToCurrency(this String str)
        {
            string val = string.Empty;

            try
            {
                if (!str.Trim().IsEmpty())
                {
                    try
                    {
                        val = String.Format("{0:C}", decimal.Parse(str)).Replace("£", "");
                    }
                    catch (Exception)
                    {
                        val = string.Empty;
                    }
                }
            }
            catch
            {
            }

            return val;
        }

        private static string Encrypt(string str, string PARAMETER_NAME, string ENCRYPTION_KEY)
        {
            string value = str;

            if (!str.StartsWith(PARAMETER_NAME))
            {
                byte[] SALT = Encoding.ASCII.GetBytes(ENCRYPTION_KEY.Length.ToString());

                RijndaelManaged rijndaelCipher = new RijndaelManaged();
                byte[] plainText = Encoding.Unicode.GetBytes(str);
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(ENCRYPTION_KEY, SALT);

                using (ICryptoTransform encryptor = rijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16)))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(plainText, 0, plainText.Length);
                            cryptoStream.FlushFinalBlock();
                            value = PARAMETER_NAME + Convert.ToBase64String(memoryStream.ToArray());
                        }
                    }
                }
            }

            return value;
        }

        public static string Decrypt(string str, string PARAMETER_NAME, string ENCRYPTION_KEY)
        {
            string value = str;

            if (str.StartsWith(PARAMETER_NAME))
            {
                RijndaelManaged rijndaelCipher = new RijndaelManaged();
                byte[] encryptedData = Convert.FromBase64String(str.Replace(PARAMETER_NAME, string.Empty));
                byte[] SALT = Encoding.ASCII.GetBytes(ENCRYPTION_KEY.Length.ToString());
                PasswordDeriveBytes secretKey = new PasswordDeriveBytes(ENCRYPTION_KEY, SALT);

                using (ICryptoTransform decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
                {
                    using (MemoryStream memoryStream = new MemoryStream(encryptedData))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] plainText = new byte[encryptedData.Length];
                            int decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
                            value = Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                        }
                    }
                }
            }
            else
            {
                //Need to split the string into 2 parts, and decrypt as required...
            }

            return value;
        }

        public static string RemoveSpecialCharacters(this String str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }
    }
}
