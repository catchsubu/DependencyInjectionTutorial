using TutorialDI.Core;
using TutorialDI.Instrument;

namespace TutorialDI.App
{
    public static class RunManualDI
    {
        public static void Run(string essayTopic)
        {
            // IWritingInstrument writingInstrument = new FountainPen();
            // IWritingInstrument writingInstrument = new BallPen();
            // IWritingInstrument writingInstrument = new Pencil();
            IWritingInstrument writingInstrument = new GelPen();

            writingInstrument.WriteEssay($"Injected via ManualDI! {essayTopic}");
        }
    }
}
