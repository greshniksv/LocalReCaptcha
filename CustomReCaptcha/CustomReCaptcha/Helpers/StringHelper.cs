using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CustomReCaptcha.Helpers.Interfaces;

namespace CustomReCaptcha.Helpers
{
    public class StringHelper : IStringHelper
    {
        private static readonly byte[] Salt = Encoding.ASCII.GetBytes("<kmNJKVmlughnn!vkTBJ&*^56w4>");
        private const string Forbidden = "+/=";
        private const string Replace = "._-";

        public string ToSafeBase64(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Parameter 'text' should not be null or empty");
            }

            var data = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < Forbidden.Length; j++)
                {
                    if (data[i] == Forbidden[j])
                    {
                        data = ReplaceAtIndex(data, i, Replace[j]);
                    }
                }
            }

            return data;
        }

        public string FromSafeBase64(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Parameter 'text' should not be null or empty");
            }

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < Replace.Length; j++)
                {
                    if (text[i] == Replace[j])
                    {
                        text = ReplaceAtIndex(text, i, Forbidden[j]);
                    }
                }
            }

            var base64EncodedBytes = Convert.FromBase64String(text);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public string RandomString(int length, int lengthEx = 0)
        {
            Random random = new Random();
            if (lengthEx > 0)
            {
                length = random.Next(length, lengthEx);
            }

            const string chars =
                "qwertyuiopasdfghjklzxcvbnmABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string RandomNumber(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string Encrypt(string plainText, string sharedSecret)
        {
            if (plainText == null)
            {
                throw new ArgumentNullException(nameof(plainText));
            }

            if (string.IsNullOrEmpty(sharedSecret))
            {
                throw new ArgumentNullException(nameof(sharedSecret));
            }

            string outStr = null;                       // Encrypted string to return
            RijndaelManaged aesAlg = null;              // RijndaelManaged object used to encrypt the data.

            try
            {
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, Salt);
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream memoryEncrypt = new MemoryStream())
                {
                    memoryEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    memoryEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream cryptoEncrypt = new CryptoStream(memoryEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writerEncrypt = new StreamWriter(cryptoEncrypt))
                        {
                            writerEncrypt.Write(plainText);
                        }
                    }

                    outStr = Convert.ToBase64String(memoryEncrypt.ToArray());
                }
            }
            finally
            {
                aesAlg?.Clear();
            }

            return outStr;
        }

        public string Decrypt(string cipherText, string sharedSecret)
        {
            if (cipherText == null)
            {
                throw new ArgumentNullException(nameof(cipherText));
            }

            if (string.IsNullOrEmpty(sharedSecret))
            {
                throw new ArgumentNullException(nameof(sharedSecret));
            }

            RijndaelManaged aesAlg = null;
            string plaintext = null;

            try
            {
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, Salt);
                byte[] bytes = Convert.FromBase64String(cipherText);
                using (MemoryStream memoryDecrypt = new MemoryStream(bytes))
                {
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    aesAlg.IV = ReadByteArray(memoryDecrypt);

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream cryptoDecrypt =
                        new CryptoStream(memoryDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader readerDecrypt = new StreamReader(cryptoDecrypt))
                        {
                            plaintext = readerDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            finally
            {
                aesAlg?.Clear();
            }

            return plaintext;
        }

        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }

            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }

        private static string ReplaceAtIndex(string word, int i, char value)
        {
            char[] letters = word.ToCharArray();
            letters[i] = value;
            return string.Join(string.Empty, letters);
        }
    }
}