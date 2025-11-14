# Advent of Code 2025 Solver CLI

A command-line tool written in C# to solve [Advent of Code 2025](https://adventofcode.com/2025) puzzles.

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

## Installation

1. Clone the repository:
   ```bash
   git clone git@github.com:realemx/AOC2025.git
   cd aoc-2025-solver
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

## Usage

### Run a specific day's solution
```bash
dotnet run -- -d <day>
```
Replace `<day>` with the day number (1-25).

### Run all available solutions
```bash
dotnet run -- run-all
```

## Project Structure

- `Solvers/`: Contains solver implementations for each day.
- `inputs/`: Input files for each day's puzzle (e.g., `day1.txt`).
- `IO/`: Input reading utilities.

## Contributing

Add new solvers in the `Solvers/` directory implementing the `IPuzzleSolver` interface.

## License

This project is open source.
