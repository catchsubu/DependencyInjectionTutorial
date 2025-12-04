# Project Tutorial

## Overview

This repository contains a .NET Framework 4.7.2 solution. This README provides a quick-start tutorial to build, test, and contribute.

## Prerequisites

- Visual Studio 2026 with .NET Framework 4.7.2 targeting packs installed.
- Git (2.30+)
- Optional: preferred test runner (MSTest, NUnit, or xUnit)

## Build

1. Open the solution in Visual Studio 2026.
2. Restore NuGet packages: __Project > Restore NuGet Packages__ (or run `nuget restore`).
3. Build the solution: __Build > Build Solution__.

From the command line:

## Run Tests

- Use Test Explorer in Visual Studio or run via command line with the chosen test runner.
- Example with vstest.console:

## Contributing

Please see `CONTRIBUTING.md` for contribution guidelines, branch and PR workflows, coding standards, and testing requirements.

## Common Visual Studio Settings

Check or set recommended editor preferences:

- __Tools > Options > Text Editor > C# > Code Style__
- __Tools > Options > Text Editor > C# > Formatting__
- __Tools > Options > Environment > Documents__

## Additional Notes

- This repo targets .NET Framework 4.7.2; if you need to upgrade or modernize, open an Issue first.
- Add `.editorconfig` to enforce project formatting rules if not already present.

# Dependency Injection Tutorial for .NET Framework

Welcome! This is a **beginner-friendly tutorial project** demonstrating **Dependency Injection (DI)** concepts in C# and .NET Framework. This repository is designed to accompany my YouTube tutorial series.

## 🎯 What is Dependency Injection?

**Dependency Injection** is a design pattern that helps you write cleaner, more maintainable, and testable code. Instead of objects creating their own dependencies, you "inject" them from the outside.

### Why Learn DI?
- ✅ **Loose Coupling** - Components are less dependent on each other
- ✅ **Easy Testing** - Mock dependencies for unit tests
- ✅ **Maintainability** - Easier to modify and extend code
- ✅ **Flexibility** - Swap implementations without changing code

---

## 📁 Project Structure

This solution demonstrates DI with a real-world analogy: **Writers using different Writing Instruments** (Pens, Pencils, etc.)

```
DependencyInjectionTutorial/
├── TutorialDI.Core/                # Core abstractions & interfaces
│   ├── IWritingInstrument.cs       # Interface for all writing instruments
│   └── Writer.cs                   # Writer class that uses an instrument
│
├── TutorialDI.Instrument/          # Concrete implementations
│   ├── Pencil.cs
│   ├── BallPen.cs
│   ├── FountainPen.cs
│   └── GelPen.cs
│
└── TutorialDI.App/                 # Console application (entry point)
    ├── Program.cs                  # Main entry point
    ├── RunManualDI.cs              # Example 1: Manual DI
    └── RunContainerDI.cs           # Example 2: Using Autofac container
```

---

## 🚀 Getting Started

### Prerequisites
- **Visual Studio 2019+** (or Visual Studio Code)
- **.NET Framework 4.7.2+**
- Basic understanding of C# and OOP concepts

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/YourUsername/DependencyInjectionTutorial.git
   cd DependencyInjectionTutorial
   ```

2. **Open in Visual Studio:**
   - Open `DependencyInjectionTutorial.slnx` in Visual Studio

3. **Restore NuGet Packages:**
   - Visual Studio will auto-restore, or run:
   ```bash
   nuget restore
   ```

4. **Build the Solution:**
   - Press `Ctrl + Shift + B` or go to **Build > Build Solution**

5. **Run the Application:**
   - Set `TutorialDI.App` as the startup project
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

### 1️⃣ Manual Dependency Injection (`RunManualDI.cs`)

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

### 2️⃣ DI Container (`RunContainerDI.cs`)

Using **Autofac** - a popular DI container:

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

**Pros:** Scalable, automatic dependency resolution, easy to manage  
**Cons:** Additional dependency (Autofac), slightly more complex setup

---

## 🎬 YouTube Tutorial Videos

Follow along with these videos:

1. **Part 1:** Introduction to Dependency Injection
2. **Part 2:** Understanding the Problem (Tight Coupling)
3. **Part 3:** Manual Dependency Injection
4. **Part 4:** Using DI Containers (Autofac)
5. **Part 5:** Best Practices & Common Mistakes

> 📌 Each video corresponds to the code in this repository

---

## 🏗️ Project Components

### `TutorialDI.Core`
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

### `TutorialDI.Instrument`
**Purpose:** Concrete implementations of `IWritingInstrument`

- **`Pencil.cs`** - Implements `IWritingInstrument`
- **`BallPen.cs`** - Implements `IWritingInstrument`
- **`FountainPen.cs`** - Implements `IWritingInstrument`
- **`GelPen.cs`** - Implements `IWritingInstrument`

Each class implements the interface differently, showing how DI allows you to swap implementations.

### `TutorialDI.App`
**Purpose:** Console application demonstrating both approaches

- **`Program.cs`** - Entry point, menu to choose which example to run
- **`RunManualDI.cs`** - Example: Manual dependency injection
- **`RunContainerDI.cs`** - Example: Using Autofac DI container

---

## 🔧 Technologies Used

| Technology | Version | Purpose |
|---|---|---|
| .NET Framework | 4.7.2 | Application framework |
| C# | 7.3+ | Programming language |
| Autofac | 9.0.0 | DI Container |
| Visual Studio | 2019+ | IDE |

---

## 📖 Learning Outcomes

After completing this tutorial, you will:

- ✅ Understand the concept of Dependency Injection
- ✅ Recognize tight coupling problems in code
- ✅ Implement manual dependency injection
- ✅ Use a DI container (Autofac) for automatic resolution
- ✅ Know when and how to apply DI in your projects
- ✅ Write more testable and maintainable code

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

## 🤝 Contributing

Contributions are welcome! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

---

## 📄 License

This project is licensed under the MIT License - see [LICENSE.txt](LICENSE.txt) for details.

---

## ❓ FAQ

### Q: Do I need to know Autofac before starting?
**A:** No! This tutorial starts from scratch and explains everything. Autofac is introduced in the second approach.

### Q: Can I use this in production?
**A:** This is a tutorial project for learning. For production, use industry-standard DI containers like Autofac, Ninject, or the built-in .NET Core DI.

### Q: Why use `.NET Framework` instead of `.NET Core`?
**A:** This tutorial covers `.NET Framework 4.7.2` for educational purposes. The concepts apply to all .NET versions.

### Q: What if I get compilation errors?
**A:** Make sure all NuGet packages are restored. Run `nuget restore` in the Package Manager Console.

---

## 🎓 Further Learning

- [Microsoft Docs: Dependency Injection](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [Autofac Documentation](https://autofac.readthedocs.io/)
- [SOLID Principles](https://en.wikipedia.org/wiki/SOLID)

---

## 👤 About the Author

**Subrata Mohanta**

A passionate software developer and educator dedicated to making complex concepts simple and understandable. This tutorial series is designed to help developers at all levels master Dependency Injection.

### Connect with Me:
- 🔗 **LinkedIn:** [linkedin.com/in/subratamohanta](https://www.linkedin.com/in/subratamohanta)
- 📺 **YouTube:** [Channel Link - Coming Soon]
- 💻 **GitHub:** [@subratamohanta](https://github.com/subratamohanta)

---

## 📧 Questions or Feedback?

- **Issues:** Open an issue on GitHub
- **Discussions:** Use GitHub Discussions
- **YouTube:** Comment on the tutorial videos
- **LinkedIn:** Connect with me on [LinkedIn](https://www.linkedin.com/in/subratamohanta)

Happy Learning! 🚀

---

**Last Updated:** December 5, 2025  
**Author:** Subrata Mohanta
