using System;
using TutorialDI.Core;

namespace TutorialDI.Instrument
{
    public class Pencil : IWritingInstrument
    {
        public void WriteEssay(string essayTopic) => 
            Console.WriteLine($"Writing an essay on \"{essayTopic}\" using a pencil.");
    }
}