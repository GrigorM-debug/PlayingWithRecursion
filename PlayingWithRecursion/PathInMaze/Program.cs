using System.Data;

namespace PathInMaze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] maze = new string[]
            //{
            //    "000",
            //    "010",
            //    "00E"
            //};

            string[] maze = new string[]
            {
                "010",
                "001",
                "10E"
            };

            string path = "";
            
            bool[,] visitedCells = new bool[maze.Length, maze[0].Length];

            FindPaths(maze, path, visitedCells, 0, 0);
        }

        static void FindPaths(string[] maze, string path, bool[,] visitedCells, int row, int col)
        {
            if (maze[row][col] == 'E')
            {
                Console.WriteLine(path);
                return;
            }

            visitedCells[row, col] = true;


            //UP
            if (IsValid(row - 1, col, maze, visitedCells))
            {
                FindPaths(maze, path + "U", visitedCells, row - 1, col);
            }

            //Down
            if (IsValid(row + 1, col, maze, visitedCells))
            {
                FindPaths(maze, path + "D", visitedCells, row + 1, col);
            }

            //Right
            if (IsValid(row, col + 1, maze, visitedCells))
            {
                FindPaths(maze, path + "R", visitedCells, row, col + 1);
            }

            //Left
            if (IsValid(row, col - 1, maze, visitedCells))
            {
                FindPaths(maze, path + "L", visitedCells, row, col - 1);
            }
        }

        static bool IsValid(int row, int col, string[] maze, bool[,] visited)
        {
            if (row < 0 || col < 0 || row >= maze.Length || col >= maze[0].Length)
            {
                return false;
            }

            if (visited[row, col] || maze[row][col] == '1')
            {
                return false;
            }

            return true;
        }
    }
}
