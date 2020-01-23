using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using CustomReCaptcha.Services.Interfaces;

namespace CustomReCaptcha.Services
{
    public class AudioService : IAudioService
    {
        private readonly IList<IPuzzleAlgorithm> puzzleAlgorithm;

        public AudioService(IPuzzleAlgorithm[] puzzleAlgorithm)
        {
            this.puzzleAlgorithm = puzzleAlgorithm.ToList();
        }

        public Stream Generate(string data, string lang)
        {
            Random random = new Random(data.Length);
            var alg = random.Next(0, puzzleAlgorithm.Count - 1);
            IPuzzleAlgorithm algorithm = puzzleAlgorithm[alg];

            data = algorithm.Generate(data, lang);

            MemoryStream ms = new MemoryStream();
            var path = Path.GetTempFileName();
            using (SpeechSynthesizer reader = new SpeechSynthesizer())
            {
                reader.Volume = 100;
                reader.Rate = 0;
                reader.SetOutputToWaveStream(ms);
                reader.Speak($"{data}");
            }

            ms.Position = 0;

            return ms;
        }
    }
}