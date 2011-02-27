using System;
using System.Speech.Synthesis;

namespace WinnerSelector
{
    public class TextToSpeech : ICanTalk
    {
        public void Speak(string message)
        {
            var synthesizer = new SpeechSynthesizer();

            synthesizer.Speak(message);
        }
    }
}