using System;
using System.Text;

namespace AcidWallStudio.AcidUtilities;

public static class Encryptor
{
    private const string Key = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    
    public static string Encode(string plainText)
    {
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] keyBytes = Encoding.UTF8.GetBytes(Key);

        for (int i = 0; i < plainBytes.Length; i++)
        {
            plainBytes[i] = (byte)(plainBytes[i] ^ keyBytes[i % keyBytes.Length]);
        }

        return Convert.ToBase64String(plainBytes);
    }

    public static string Decode(string encryptedText)
    {
        try
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = Encoding.UTF8.GetBytes(Key);

            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                encryptedBytes[i] = (byte)(encryptedBytes[i] ^ keyBytes[i % keyBytes.Length]);
            }

            return Encoding.UTF8.GetString(encryptedBytes);
        }
        catch (Exception e)
        {
            return "";
        }
    }
}