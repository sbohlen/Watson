using System;
using System.Diagnostics;
using System.Speech.Synthesis;

namespace WinnerSelector
{
    public class FemaleVoiceSynthesizer : ICanTalk
    {
        private readonly SpeechSynthesizer _engine;

        public FemaleVoiceSynthesizer()
        {
            _engine = new SpeechSynthesizer();
            _engine.Rate = -3;
        }

        public void Speak(string message)
        {
            _engine.SpeakAsync(message);
        }
    }
}