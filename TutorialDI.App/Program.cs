using System;

namespace TutorialDI.App
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var essayTopic = "The Dependency Injection Pattern";

            Console.WriteLine(string.Empty);

            Console.WriteLine("--------------------------------");

            RunManualDI.Run(essayTopic);
            // RunContainerDI.Run(essayTopic);

            Console.WriteLine("--------------------------------");
        }
    }
}