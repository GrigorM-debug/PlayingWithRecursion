namespace BFS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] maze = new string[]
            {
                "000",
                "010",
                "00E"
            };

            //string[] maze = new string[]
            //{
            //    "010",
            //    "001",
            //    "10E"
            //};

            //string path = "";

            //bool[,] visitedCells = new bool[maze.Length, maze[0].Length];


            FindPaths(maze, 0, 0);
        }

        static void FindPaths(string[] maze, int startRow, int startCol)
        {

            bool[,] visitedCells = new bool[maze.Length, maze[0].Length];
            Queue<(int row, int col, string path)> queue = new Queue<(int, int, string)>();

            queue.Enqueue((0, 0, ""));

            while (queue.Count > 0) 
            {
                var (row, col, path) = queue.Dequeue();

                if (maze[row][col] == 'E')
                {
                    Console.WriteLine(path);
                    return;
                }

                visitedCells[row, col] = true;


                //UP
                if (IsValid(row - 1, col, maze, visitedCells))
                {
                    queue.Enqueue((row - 1, col, path + "U"));
                }

                //Down
                if (IsValid(row + 1, col, maze, visitedCells))
                {
                    queue.Enqueue((row + 1, col, path + "D"));
                }

                //Right
                if (IsValid(row, col + 1, maze, visitedCells))
                {
                    queue.Enqueue((row, col + 1, path + "R"));
                }

                //Left
                if (IsValid(row, col - 1, maze, visitedCells))
                {
                    queue.Enqueue((row, col - 1, path + "L"));
                }

                visitedCells[row, col] = false;
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
