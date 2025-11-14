# Advent of Code 2025 Solver CLI

A command-line tool written in C# to solve [Advent of Code 2025](https://adventofcode.com/2025) puzzles.

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

## Installation

1. Clone the repository:
   ```bash
   git clone git@github.com:realemx/AOC2025.git
   cd AOC
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

## Configuration

Before running the tool, you need to set up your Advent of Code session cookie to fetch puzzle inputs automatically.

1. Log in to [adventofcode.com](https://adventofcode.com).
2. Open browser developer tools (F12).
3. Go to Application > Cookies > adventofcode.com.
4. Copy the value of the 'session' cookie.
5. Set the `AOC_SESSION` environment variable to this value, or add it to `config.json` as `"SessionCookie"`.

The `config.json` file should look like:
```json
{
    "SessionCookie": "your-session-cookie-here",
    "Year": 2025
}
```

## Usage

### Run a specific day's solution
```bash
dotnet run solve <day>
```
Replace `<day>` with the day number (1-25).

### Run all available solutions
```bash
dotnet run run-all
```

### Create a new solver for a day
```bash
dotnet run create <day>
```
This command fetches the input for the day, creates the solver class, and saves the input file.

## Project Structure

- `Commands/`: Contains CLI command definitions.
- `IO/`: Input reading utilities.
- `Scaffolding/`: Tools for automatically creating new solvers and fetching inputs.
- `Solvers/`: Contains solver implementations for each day.
  - `Factories/`: Factory for creating solver instances.
  - `Interfaces/`: Puzzle solver interface definitions.
- `inputs/`: Input files for each day's puzzle (e.g., `day1.txt`).
- `config.json`: Configuration file for session cookie and year.

## Contributing

Add new solvers in the `Solvers/` directory implementing the `IPuzzleSolver` interface.

## License

This project is open source.
