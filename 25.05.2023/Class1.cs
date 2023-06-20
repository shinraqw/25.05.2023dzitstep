using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._05._2023
{
    internal class cs1
    {
        public static void task_1()
        {
            List<int> numbers = GenerateNumbers(100);
            List<int> primeNumbers = GetPrimeNumbers(numbers);
            List<int> fibonacciNumbers = GetFibonacciNumbers(numbers);

            SaveNumbersToFile(primeNumbers, "prime_numbers.txt");
            SaveNumbersToFile(fibonacciNumbers, "fibonacci_numbers.txt");

            Console.WriteLine("Збережено прості числа у файлі prime_numbers.txt");
            Console.WriteLine("Збережено числа Фібоначчі у файлі fibonacci_numbers.txt");
            Console.WriteLine("Статистика роботи:");
            Console.WriteLine("Всього згенеровано чисел: " + numbers.Count);
            Console.WriteLine("Кількість простих чисел: " + primeNumbers.Count);
            Console.WriteLine("Кількість чисел Фібоначчі: " + fibonacciNumbers.Count);

        }
        static List<int> GenerateNumbers(int count)
        {
            List<int> numbers = new List<int>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                numbers.Add(random.Next(1, 1000));
            }

            return numbers;
        }

        static List<int> GetPrimeNumbers(List<int> numbers)
        {
            List<int> primeNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            }

            return primeNumbers;
        }

        static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static List<int> GetFibonacciNumbers(List<int> numbers)
        {
            List<int> fibonacciNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (IsFibonacci(number))
                {
                    fibonacciNumbers.Add(number);
                }
            }

            return fibonacciNumbers;
        }

        static bool IsFibonacci(int number)
        {
            int a = 0;
            int b = 1;

            while (b < number)
            {
                int temp = b;
                b = a + b;
                a = temp;
            }

            return b == number;
        }

        static void SaveNumbersToFile(List<int> numbers, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (int number in numbers)
                {
                    writer.WriteLine(number);
                }
            }
        }
    }
}