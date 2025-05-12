using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int>numbers = new List<int>();
        int sum = 0;
        int cnt = 0;
        int largest = 0;
        while(true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                break;
            }else{
                numbers.Add(number);
                sum+=number;
                cnt++;
                if(number>largest)largest = number;
            }

        }
        int smallest = largest;
        foreach (int num in numbers)
        {
            if(num<=smallest && num>0)smallest=num;
        }
        double average  = (double)sum/cnt;
        numbers.Sort();
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"Thea average is: {average}");
        Console.WriteLine($"The largest unmber is: {largest}");
        Console.WriteLine($"The smallest positive bumber is: {smallest}");
        Console.WriteLine($"The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine($"{num}");
        }
    }
}