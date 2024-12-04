using System;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i <= 99; i++)
        {
            Console.Write(i < 99 ? $"{i:D2}, " : $"{i:D2}");
        }
        Console.Write("\n");
    }
}