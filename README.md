# Dependency Injection Tutorial for .NET

Welcome! This is a **beginner-friendly tutorial project** demonstrating **Dependency Injection (DI)** concepts in C# across multiple .NET platforms. This repository is designed to accompany my YouTube tutorial series.

## 🎯 What is Dependency Injection?

**Dependency Injection** is a design pattern that helps you write cleaner, more maintainable, and testable code. Instead of objects creating their own dependencies, you "inject" them from the outside.

### Why Learn DI?
- ✅ **Loose Coupling** - Components are less dependent on each other
- ✅ **Easy Testing** - Mock dependencies for unit tests
- ✅ **Maintainability** - Easier to modify and extend code
- ✅ **Flexibility** - Swap implementations without changing code

---

## 📁 Project Structure

This solution demonstrates DI with a real-world analogy: **Writers using different Writing Instruments** (Pens, Pencils, etc.) across two different .NET platforms.

```
DependencyInjectionTutorial/
│
├── net472/                              # .NET Framework 4.7.2 Examples
│   ├── TutorialDI.App/                  # Console application (entry point)
│   │   ├── Program.cs
│   │   ├── RunManualDI.cs               # Example 1: Manual DI
│   │   ├── RunContainerDI.cs            # Example 2: Using Autofac container
│   │   ├── App.config
│   │   └── TutorialDI.App.csproj
│   │
│   ├── TutorialDI.Core/                 # Core abstractions & interfaces
│   │   ├── IWritingInstrument.cs        # Interface for writing instruments
│   │   ├── Writer.cs                    # Writer class that uses an instrument
│   │   └── TutorialDI.Core.csproj
│   │
│   └── TutorialDI.Instrument/           # Concrete implementations
│       ├── Pencil.cs
│       ├── BallPen.cs
│       ├── FountainPen.cs
│       ├── GelPen.cs
│       └── TutorialDI.Instrument.csproj
│
├── netcore/                             # .NET Core (Modern .NET) Examples
│   └── TutorialDI.NetCore.Example/      # Single project with all examples
│       ├── Program.cs                   # Entry point (console app)
│       ├── TutorialDI.NetCore.Example.csproj
│       ├── Core/                        # Core abstractions
│       │   ├── IWritingInstrument.cs
│       │   └── Writer.cs
│       └── Instrument/                  # Concrete implementations
│           ├── Pencil.cs
│           └── FountainPen.cs
│
└── Shared Documentation/
    ├── README.md                        # This file
    ├── CONTRIBUTING.md                  # Contribution guidelines
    ├── LICENSE.txt                      # MIT License
    └── .gitattributes                   # Git line ending config
```

---

## 🚀 Getting Started

### Prerequisites
- **Visual Studio 2019+** or **Visual Studio Code**
- **.NET Framework 4.7.2+** (for .NET Framework examples)
- **.NET 10.0+** (for .NET Core examples)
- Basic understanding of C# and OOP concepts

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/YourUsername/DependencyInjectionTutorial.git
   cd DependencyInjectionTutorial
   ```

2. **Open in Visual Studio:**
   - Open `DependencyInjectionTutorial.slnx` in Visual Studio
   - Or open individual projects in VS Code

3. **Restore NuGet Packages:**
   - Visual Studio will auto-restore
   - Or run:
   ```bash
   nuget restore
   ```

4. **Build the Solution:**
   - Press `Ctrl + Shift + B` or go to **Build > Build Solution**

5. **Run Applications:**

   **For .NET Framework (net472):**
   - Set `TutorialDI.App` as the startup project
   - Press `F5` or click **Start**

   **For .NET Core (netcore):**
   - Set `TutorialDI.NetCore.Example` as the startup project
   - Press `F5` or click **Start**

---

## 💡 Key Concepts Explained

### The Problem (Without DI)
```csharp
// ❌ BAD: Writer is tightly coupled to Pencil
public class Writer
{
    private Pencil pencil = new Pencil();  // Hard-coded dependency
    
    public void Write()
    {
        pencil.DrawMark();
    }
}
```

**Issues:**
- Can't use a different instrument without changing the code
- Hard to test (can't mock the Pencil)
- Not flexible for future changes

### The Solution (With DI)
```csharp
// ✅ GOOD: Writer depends on abstraction, not concrete class
public class Writer
{
    private IWritingInstrument instrument;
    
    // Dependencies are injected through constructor
    public Writer(IWritingInstrument instrument)
    {
        this.instrument = instrument;
    }
    
    public void Write()
    {
        instrument.DrawMark();
    }
}

// Now you can use any writing instrument:
var pencil = new Pencil();
var writer = new Writer(pencil);
writer.Write();

var pen = new BallPen();
var writer2 = new Writer(pen);
writer2.Write();
```

---

## 📚 Two Approaches Demonstrated

### 1️⃣ Manual Dependency Injection

Manually creating and passing dependencies:

```csharp
// Create dependencies
IWritingInstrument pencil = new Pencil();
IWritingInstrument ballPen = new BallPen();

// Inject into Writer
Writer writer1 = new Writer(pencil);
Writer writer2 = new Writer(ballPen);

// Use them
writer1.Write();
writer2.Write();
```

**Pros:** Simple, no external dependencies  
**Cons:** Manual management, gets complex with many dependencies

### 2️⃣ DI Container

#### .NET Framework: Using Autofac

```csharp
// Configure container
var builder = new ContainerBuilder();
builder.RegisterType<Pencil>().As<IWritingInstrument>();
builder.RegisterType<Writer>();

using (var container = builder.Build())
{
    // Resolve dependencies automatically
    var writer = container.Resolve<Writer>();
    writer.Write();
}
```

#### .NET Core: Using Microsoft.Extensions.DependencyInjection

```csharp
// Configure services
var services = new ServiceCollection();
services.AddScoped<IWritingInstrument, Pencil>();
services.AddScoped<Writer>();

var serviceProvider = services.BuildServiceProvider();

// Resolve dependencies automatically
var writer = serviceProvider.GetRequiredService<Writer>();
writer.Write();
```

**Pros:** Scalable, automatic dependency resolution, easy to manage  
**Cons:** Additional dependencies, slightly more complex setup

---

## 🎯 Platform Comparison

| Feature | .NET Framework 4.7.2 | .NET Core 10.0 |
|---------|----------------------|----------------|
| DI Container | Autofac | Microsoft.Extensions.DI |
| Project Structure | Multi-project | Single project |
| Configuration | App.config | appsettings.json (if added) |
| Execution | Console app (.exe) | Console app (.exe/.dll) |
| Performance | Good | Excellent |
| Cross-platform | Windows only | Windows, Mac, Linux |
| Use Case | Legacy/Enterprise | Modern/Cloud |

---

## 📖 Project Components

### `TutorialDI.Core` (.NET Framework) / `Core/` (.NET Core)
**Purpose:** Contains abstractions (interfaces) and core classes

- **`IWritingInstrument.cs`** - Interface defining what a writing instrument can do
  ```csharp
  public interface IWritingInstrument
  {
      void DrawMark();
  }
  ```

- **`Writer.cs`** - Class that depends on `IWritingInstrument`
  ```csharp
  public class Writer
  {
      private readonly IWritingInstrument instrument;
      
      public Writer(IWritingInstrument instrument)
      {
          this.instrument = instrument;
      }
      
      public void Write()
      {
          // Calls the injected instrument
          instrument.DrawMark();
      }
  }
  ```

### `TutorialDI.Instrument` (.NET Framework) / `Instrument/` (.NET Core)
**Purpose:** Concrete implementations of `IWritingInstrument`

- **`Pencil.cs`** - Implements `IWritingInstrument`
- **`BallPen.cs`** - Implements `IWritingInstrument` (Framework only)
- **`FountainPen.cs`** - Implements `IWritingInstrument`
- **`GelPen.cs`** - Implements `IWritingInstrument` (Framework only)

Each class implements the interface differently, showing how DI allows you to swap implementations.

### `TutorialDI.App` (.NET Framework)
**Purpose:** Console application demonstrating both approaches

- **`Program.cs`** - Entry point, menu to choose which example to run
- **`RunManualDI.cs`** - Example: Manual dependency injection
- **`RunContainerDI.cs`** - Example: Using Autofac DI container

### `TutorialDI.NetCore.Example` (.NET Core)
**Purpose:** Console application demonstrating .NET Core built-in DI

- **`Program.cs`** - Entry point with integrated DI setup using Microsoft.Extensions.DependencyInjection

---

## 🔧 Technologies Used

| Technology | Version | Purpose | Platform |
|---|---|---|---|
| .NET Framework | 4.7.2 | Application framework | net472 |
| .NET Core | 10.0 | Modern framework | netcore |
| C# | 7.3+ | Programming language | Both |
| Autofac | 9.0.0 | DI Container | net472 |
| Microsoft.Extensions.DI | Latest | Built-in DI | netcore |
| Visual Studio | 2019+ | IDE | Both |

---

## 📖 Learning Outcomes

After completing this tutorial, you will:

- ✅ Understand the concept of Dependency Injection
- ✅ Recognize tight coupling problems in code
- ✅ Implement manual dependency injection
- ✅ Use DI containers (Autofac & Microsoft.Extensions.DI)
- ✅ Know the differences between .NET Framework and .NET Core DI
- ✅ Know when and how to apply DI in your projects
- ✅ Write more testable and maintainable code
- ✅ Understand modern .NET development practices

---

## 🧪 Testing DI Code

One major benefit of DI is testability. Here's how you'd test the `Writer` class:

```csharp
// Mock implementation for testing
public class MockPen : IWritingInstrument
{
    public void DrawMark()
    {
        // Test behavior
    }
}

// In your test
[TestMethod]
public void Writer_ShouldUseInjectedInstrument()
{
    var mockPen = new MockPen();
    var writer = new Writer(mockPen);
    
    writer.Write();
    
    // Verify behavior
}
```

---

## 🎬 YouTube Tutorial Videos

Follow along with these videos:

1. **Part 1:** Introduction to Dependency Injection
2. **Part 2:** Understanding the Problem (Tight Coupling)
3. **Part 3:** Manual Dependency Injection (.NET Framework)
4. **Part 4:** Using Autofac DI Container (.NET Framework)
5. **Part 5:** Dependency Injection in .NET Core
6. **Part 6:** Built-in DI in Microsoft.Extensions
7. **Part 7:** Best Practices & Common Mistakes
8. **Bonus:** Framework vs Core Comparison

> 📌 Each video corresponds to the code in this repository

---

## 🤝 Contributing

Contributions are welcome! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

---

## 📄 License

This project is licensed under the MIT License - see [LICENSE.txt](LICENSE.txt) for details.

---

## ❓ FAQ

### Q: Which version should I start with?
**A:** Start with **.NET Framework** (net472) if you're learning DI basics. Then move to **.NET Core** to see modern practices.

### Q: Do I need to know Autofac before starting?
**A:** No! This tutorial starts from scratch and explains everything. Autofac is introduced in the second approach for Framework.

### Q: What's the difference between Autofac and Microsoft.Extensions.DI?
**A:** Autofac is a third-party container with advanced features. Microsoft.Extensions.DI is built-in and simpler, perfect for modern .NET Core apps.

### Q: Can I use this in production?
**A:** This is a tutorial project for learning. For production, use industry-standard practices with proper DI containers.

### Q: Why both .NET Framework and .NET Core?
**A:** To show you that DI concepts are universal, but implementations differ between platforms.

### Q: What if I get compilation errors?
**A:** Make sure all NuGet packages are restored. Run `nuget restore` in the Package Manager Console.

---

## 🎓 Further Learning

- [Microsoft Docs: Dependency Injection](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [Autofac Documentation](https://autofac.readthedocs.io/)
- [SOLID Principles](https://en.wikipedia.org/wiki/SOLID)
- [.NET Framework vs .NET Core](https://docs.microsoft.com/en-us/dotnet/standard/choosing-core-framework-your-app)

---

## 👤 About the Author

**Subrata Mohanta**

A passionate software developer and educator dedicated to making complex concepts simple and understandable. This tutorial series is designed to help developers at all levels master Dependency Injection across multiple .NET platforms.

### Connect with Me:
- 🔗 **LinkedIn:** [linkedin.com/in/subratamohanta](https://www.linkedin.com/in/subratamohanta)
- 📺 **YouTube:** [TechnicalOdiyaToka](https://www.youtube.com/@technicalodiyatoka)
- 💻 **GitHub:** [@subratamohanta](https://github.com/subratamohanta)

---

## 📧 Questions or Feedback?

- **Issues:** Open an issue on GitHub
- **Discussions:** Use GitHub Discussions
- **YouTube:** Comment on the tutorial videos
- **LinkedIn:** Connect with me on [LinkedIn](https://www.linkedin.com/in/subratamohanta)

Happy Learning! 🚀

---

**Last Updated:** December 6, 2025  
**Author:** Subrata Mohanta
