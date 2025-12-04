using System;
using Autofac;
using TutorialDI.Core;
using TutorialDI.Instrument;

namespace TutorialDI.App
{
    public static class RunContainerDI
    {
        public static void Run(string essayTopic)
        {
            // 1. Create the container
            var builder = new ContainerBuilder();

            // 2. Register dependencies
            // builder.RegisterType<FountainPen>().As<IWritingInstrument>();
            // builder.RegisterType<BallPen>().As<IWritingInstrument>();
            // builder.RegisterType<Pencil>().As<IWritingInstrument>();
            builder.RegisterType<GelPen>().As<IWritingInstrument>();

            // 3. Build the container
            var container = builder.Build();

            // 4. Resolve dependencies
            using (var scope = container.BeginLifetimeScope())
            {
                var writingInstrument = scope.Resolve<IWritingInstrument>();
                writingInstrument.WriteEssay($"Injected via AutoFac! {essayTopic}");
            }
        }
    }
}
