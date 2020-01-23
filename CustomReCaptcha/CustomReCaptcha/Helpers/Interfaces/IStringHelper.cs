namespace CustomReCaptcha.Helpers.Interfaces
{
    public interface IStringHelper
    {
        string FromSafeBase64(string text);

        string ToSafeBase64(string text);

        string RandomString(int length, int lengthEx = 0);

        string RandomNumber(int length);

        string Encrypt(string plainText, string sharedSecret);

        string Decrypt(string cipherText, string sharedSecret);
    }
}