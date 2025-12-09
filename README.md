# Advent of Code Solver CLI

A command-line tool written in C# to solve [Advent of Code](https://adventofcode.com) puzzles for multiple years.

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
    "SessionCookie": "your-session-cookie-here"
}
```

## Usage

### Run a specific day's solution
```bash
dotnet run solve <day> [--year <year>]
```
Replace `<day>` with the day number (1-25). The `--year` option specifies the year (defaults to current year).

### Run all available solutions for a year
```bash
dotnet run run-all [--year <year>]
```
Runs all solved days for the specified year (defaults to current year).

### Create a new solver for a day
```bash
dotnet run create <day> [--year <year>]
```
This command fetches the input for the day, creates the solver class, and saves the input file. The `--year` option specifies the year (defaults to current year).

## Project Structure

- `Commands/`: Contains CLI command definitions.
- `IO/`: Input reading utilities.
- `Scaffolding/`: Tools for automatically creating new solvers and fetching inputs.
- `Solvers/`: Contains solver implementations organized by year.
  - `{year}/`: Year-specific solver classes (e.g., `2024/Day1Solver.cs`).
  - `Factories/`: Factory for creating solver instances.
  - `Interfaces/`: Puzzle solver interface definitions.
- `inputs/`: Input files organized by year (e.g., `2024/day1.txt`).
- `config.json`: Configuration file for session cookie.

## Contributing

Add new solvers in the `Solvers/{year}/` directory implementing the `IPuzzleSolver` interface. Use the `create` command to scaffold new solvers automatically.

## License

This project is open source.
