using Microsoft.Extensions.DependencyInjection;
using TutorialDI.NetCore.Example.Core;
using TutorialDI.NetCore.Example.Instrument;

//1. Setup DI container
var service = new ServiceCollection();

//2. Register services
//service.AddTransient<IWritingInstrument, FountainPen>();
service.AddTransient<IWritingInstrument, Pencil>();
service.AddTransient<Writer>();

//3. Build service provider
var servicecProvider = service.BuildServiceProvider();

//4. Request service
var writer = servicecProvider.GetService<Writer>();

//5. Use service
writer?.WriteEssay("Dependency Injection in .NET Core");