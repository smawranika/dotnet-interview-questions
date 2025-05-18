class Program
{
    public static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
        Span<int> slice = new Span<int>(numbers, 1, 3);

        foreach (var number in slice)
            Console.WriteLine(number);

        // Stack Allocation
        Span<int> stackSpan = stackalloc int[3] { 1, 2, 3 };
        stackSpan[0] = 10;

        foreach (var number in stackSpan)
            Console.WriteLine(number);
    }
}