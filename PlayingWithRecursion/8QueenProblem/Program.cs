using System.Diagnostics.CodeAnalysis;

namespace _8QueenProblem
{
    internal class Program
    {
        static bool IsSafe(int[,] board, int row, int col)
        {
            int n = board.GetLength(0);

            // Check the column
            for (int i = 0; i < row; i++)
            {
                if (board[i, col] == 1)
                {
                    return false;
                }
            }

            // Check the upper left diagonal
            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }

            // Check the upper right diagonal
            for (int i = row, j = col; i >= 0 && j < n; i--, j++)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        static void SolveNQueens(int[,] board, int row)
        {
            int n = board.GetLength(0);
            if (row >= n)
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (IsSafe(board, row, col))
                {
                    board[row, col] = 1;
                    SolveNQueens(board, row + 1);
                    board[row, col] = 0; // Backtrack
                }
            }
        }

        static void PrintBoard(int[,] board)
        {
            int n = board.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(board[i, j] == 1)
                    {
                        Console.Write("Q" + " ");
                    }

                    if (board[i, j] == 0)
                    {
                        Console.Write("_" + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine()); // Change this value for different board sizes
            int[,] board = new int[n, n];

            SolveNQueens(board, 0);
        }
    }
}
