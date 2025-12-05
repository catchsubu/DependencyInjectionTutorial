namespace TutorialDI.NetCore.Example.Core
{
    public class Writer(IWritingInstrument writingInstrument)
    {
        public void WriteEssay(string essayTopic) =>
            writingInstrument?.WriteEssay(essayTopic);
    }
}
