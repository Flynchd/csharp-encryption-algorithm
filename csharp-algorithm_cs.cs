using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AesEncryption
{
    private static readonly string Key = "abcdefghijklmnopqrstuvwx"; // 24 bytes for AES256
    private static readonly string IV = "abcdefgh"; // 8 bytes for AES

    public static string EncryptString(string plainText)
    {
        byte[] key = Encoding.UTF8.GetBytes(Key);
        byte[] iv = Encoding.UTF8.GetBytes(IV);
        byte[] encrypted;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        return Convert.ToBase64String(encrypted);
    }
}
