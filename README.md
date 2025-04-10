# Memory Game – C# WPF Application

This is a WPF-based implementation of the classic **Memory Game**, developed in C# (.NET 8). The game supports user profiles, configurable game settings, and progress saving through JSON-based storage.

## Features

- Match-the-pairs gameplay with customizable board size
- User profile support and avatar handling
- Game state saving and loading (`gamestate.json`)
- Track player statistics (`statistics.json`)
- Configurable gameplay via `GameConfiguration.cs`
- Persistent data stored locally in JSON format
- Smooth and modern UI using WPF

## Technologies Used

- C# with .NET 8
- WPF (XAML) for UI
- JSON (manual parsing and storage)
- Visual Studio 2022


## How to Run

1. Open `MemoryGame.sln` in Visual Studio 2022.
2. Build the solution.
3. Run the app – you can create a user, choose a board size, and start matching cards!

## Learning Outcomes

- Real-world WPF application structure
- JSON-based persistence for user and game data
- GUI event handling and game logic in C#
- Use of static configuration classes (`GameConfiguration.cs`)
