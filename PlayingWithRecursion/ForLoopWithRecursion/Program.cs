namespace ForLoopWithRecursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 10;
            ForLoop(number);
        }

        static void ForLoop(int i) 
        {
            if (i == 0)
            {
                return;
            }

            Console.WriteLine(i);
            ForLoop(i - 1);
        }
    }
}
