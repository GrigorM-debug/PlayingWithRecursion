namespace DFSWithStack
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

            FindPaths(maze, 0, 0);
        }

        static void FindPaths(string[] maze, int startRow, int startCol)
        {

            bool[,] visitedCells = new bool[maze.Length, maze[0].Length];
            Stack<(int row, int col, string path)> stack = new Stack<(int, int, string)>();

            stack.Push((0, 0, ""));

            while (stack.Count > 0)
            {
                var (row, col, path) = stack.Pop();

                if (maze[row][col] == 'E')
                {
                    Console.WriteLine(path);
                    continue;
                }

                if (visitedCells[row, col] == true)
                {
                    continue;
                }

                visitedCells[row, col] = true;


                //UP
                if (IsValid(row - 1, col, maze, visitedCells))
                {
                    stack.Push((row - 1, col, path + "U"));
                }

                //Down
                if (IsValid(row + 1, col, maze, visitedCells))
                {
                    stack.Push((row + 1, col, path + "D"));
                }

                //Right
                if (IsValid(row, col + 1, maze, visitedCells))
                {
                    stack.Push((row, col + 1, path + "R"));
                }

                //Left
                if (IsValid(row, col - 1, maze, visitedCells))
                {
                    stack.Push((row, col - 1, path + "L"));
                }

                //visitedCells[row, col] = false;s
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
