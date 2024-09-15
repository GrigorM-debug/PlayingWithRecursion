namespace PrintingArrayInConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5};

            Print(numbers, 0);
        }

        static void Print(int[] numbers, int i)
        {
            if (i == numbers.Length)
            {
                return;
            }

            Console.WriteLine(numbers[i]);
            Print(numbers, i + 1);
        }
    }
}
