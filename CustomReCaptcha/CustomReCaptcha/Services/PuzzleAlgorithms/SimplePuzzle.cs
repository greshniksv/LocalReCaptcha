using CustomReCaptcha.Services.Interfaces;

namespace CustomReCaptcha.Services.PuzzleAlgorithms
{
    public class SimplePuzzle : IPuzzleAlgorithm
    {
        public string Generate(string data, string lang)
        {
            switch (lang)
            {
                case "en":
                    return $"Please write numbers: {data}";

                case "sw":
                    return $"Vänligen skriv siffror: {data}";

                default:
                    return $"Please write numbers: {data}";
            }
        }
    }
}