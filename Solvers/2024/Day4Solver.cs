using System.ComponentModel.Design;
using System.IO.Pipelines;
using AOC.Solvers.Interfaces;

namespace AOC.Solvers.Y2024
{
    public class Day4Solver : IPuzzleSolver
    {
        private char[][] _grid = Array.Empty<char[]>();

        public string SolvePart1(List<string> input)
        {
            // parse to 2D grid
            _grid = input.Select(line => line.Select(c => c).ToArray()).ToArray();

            int result = 0;
            for (int x = 0; x < _grid.Length; x++)
            {
                for (int y = 0; y < _grid[x].Length; y++)
                {
                    // process each cell
                    char cell = _grid[x][y];
                    if (cell == 'X')
                    {
                        var matches = LookForXMAS(x, y);
                        result += matches;
                    }
                }
            }

            return result.ToString();

        }

        public string SolvePart2(List<string> input)
        {
            // parse to 2D grid
            _grid = input.Select(line => line.Select(c => c).ToArray()).ToArray();

            int result = 0;
            for (int x = 0; x < _grid.Length; x++)
            {
                for (int y = 0; y < _grid[x].Length; y++)
                {
                    // process each cell
                    char cell = _grid[x][y];
                    if (cell == 'A')
                    {
                        if (x >= 1 && x < _grid.Length - 1 && y >= 1 && y < _grid[x].Length - 1)
                        if (LookForCrossMas(x, y))
                        {
                            result++;
                        }
                    }
                }
            }

            return result.ToString();
        }

        private int LookForXMAS(int startX, int startY)
        {
            // Start position is 'X'
            // check in all directions for "MAS"
            // directions: right, down, left, up, diagonals
            int[] dx = { 0, 1, 0, -1, 1, 1, -1, -1 };
            int[] dy = { 1, 0, -1, 0, 1, -1, 1, -1 };

            int result = 0;

            for (int dir = 0; dir < 8; dir++)
            {
                string remaining = "XMAS";
                int x = startX;
                int y = startY;
                while (x >= 0 && x < _grid.Length && y >= 0 && y < _grid[x].Length)
                {
                    if (_grid[x][y] == remaining[0])
                    {
                        // found next character
                        remaining = remaining.Substring(1);
                        if (remaining.Length == 0)
                        {
                            // found all characters
                            result++;
                            break;
                        }
                        // move to next position
                        x += dx[dir];
                        y += dy[dir];
                    }
                    else
                    {
                        // found a different character, stop
                        break;
                    }
                }
            }
            return result;
        }

        private bool LookForCrossMas(int startX, int startY)
        {
            // start position is 'A'
            // check for crossing 'MAS'


            if (_grid[startX][startY] != 'A')
            {
                // Sanity check
                return false;
            }


            // M.S
            // .A.
            // M.s
            if (_grid[startX - 1][startY + 1] == 'M' &&
                _grid[startX + 1][startY + 1] == 'S' &&
                _grid[startX - 1][startY - 1] == 'M' &&
                _grid[startX + 1][startY - 1] == 'S')
            {
                return true;
            }

            // M.M
            // .A.
            // S.S
            if (_grid[startX - 1][startY + 1] == 'M' &&
                _grid[startX + 1][startY + 1] == 'M' &&
                _grid[startX - 1][startY - 1] == 'S' &&
                _grid[startX + 1][startY - 1] == 'S')
            {
                return true;
            }

            // S.S
            // .A.
            // M.M
            if (_grid[startX - 1][startY + 1] == 'S' &&
                _grid[startX + 1][startY + 1] == 'S' &&
                _grid[startX - 1][startY - 1] == 'M' &&
                _grid[startX + 1][startY - 1] == 'M')
            {
                return true;
            }

            // S.M
            // .A.
            // S.M
            if (_grid[startX - 1][startY + 1] == 'S' &&
                _grid[startX + 1][startY + 1] == 'M' &&
                _grid[startX - 1][startY - 1] == 'S' &&
                _grid[startX + 1][startY - 1] == 'M')
            {
                return true;
            }

            return false;
        }
    }
}
