using System;
using TutorialDI.Core;

namespace TutorialDI.Instrument
{
    public class FountainPen : IWritingInstrument
    {
        public void WriteEssay(string essayTopic) => 
            Console.WriteLine($"Writing an essay on \"{essayTopic}\" using a fountain pen.");
    }
}