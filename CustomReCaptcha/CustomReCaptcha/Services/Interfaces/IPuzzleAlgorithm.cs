namespace CustomReCaptcha.Services.Interfaces
{
    public interface IPuzzleAlgorithm
    {
        string Generate(string data, string lang);
    }
}