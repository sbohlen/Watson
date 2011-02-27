using NUnit.Framework;
using WinnerSelector;

namespace WinnerSelectorTests
{
    [TestFixture]
    public class Given_A_Message_To_Verbalize
    {
        [Test]
        public void Can_Talk()
        {
            TextToSpeech tts = new TextToSpeech();
            tts.Speak("this is a test.");
        }
    }
}