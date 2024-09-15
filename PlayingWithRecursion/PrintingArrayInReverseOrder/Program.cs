namespace PrintingArrayInReverseOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = [1, 2, 3, 4, 5];

            Print(numbers, numbers.Length - 1);
        }

        static void Print(int[] numbers, int i)
        {
            if (i < 0)
            {
                return;
            }

            Console.WriteLine(numbers[i]);
            Print(numbers, i - 1);
        }
    }
}
