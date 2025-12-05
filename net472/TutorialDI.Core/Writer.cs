using System;

namespace TutorialDI.Core
{
    public sealed class Writer
    {
        private IWritingInstrument WritingInstrument { get; }

        public Writer(IWritingInstrument writingInstrument)
        {
            WritingInstrument = writingInstrument ?? throw new ArgumentNullException(nameof(writingInstrument));
        }

        public void WriteEssay(string message) =>
            WritingInstrument.WriteEssay(message);
    }
}