using TutorialDI.NetCore.Example.Core;

namespace TutorialDI.NetCore.Example.Instrument
{
    public class Pencil : IWritingInstrument
    {
        public void WriteEssay(string essayTopic) =>
            Console.WriteLine($"Writing an essay on \"{essayTopic}\" using a pencil.");
    }
}
