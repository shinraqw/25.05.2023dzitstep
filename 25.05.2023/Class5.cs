using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._05._2023
{
    internal class cs5
    {
        public static void task_5()
        {
            SaveNumbersToFile(GenerateNumbers(100000), "Numbers.txt");
            Console.WriteLine("Введіть шлях до файлу з цілими числами:");
            string filePath = Console.ReadLine();

            try
            {
                int positiveCount = 0;
                int negativeCount = 0;
                int twoDigitCount = 0;
                int fiveDigitCount = 0;



                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        int number = int.Parse(reader.ReadLine());

                        if (number > 0)
                        {
                            positiveCount++;
                            AppendToFile("positive_numbers.txt", number);
                        }
                        else if (number < 0)
                        {
                            negativeCount++;
                            AppendToFile("negative_numbers.txt", number);
                        }

                        if (number >= 10 && number <= 99)
                        {
                            twoDigitCount++;
                            AppendToFile("two_digit_numbers.txt", number);
                        }
                        else if (number >= 10000 && number <= 99999)
                        {
                            fiveDigitCount++;
                            AppendToFile("five_digit_numbers.txt", number);
                        }
                    }
                }

                Console.WriteLine("Статистика:");
                Console.WriteLine("Кількість додатних чисел: " + positiveCount);
                Console.WriteLine("Кількість від'ємних чисел: " + negativeCount);
                Console.WriteLine("Кількість двозначних чисел: " + twoDigitCount);
                Console.WriteLine("Кількість п'ятизначних чисел: " + fiveDigitCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка під час аналізу файлу: " + ex.Message);
            }

        }
        static List<int> GenerateNumbers(int count)
        {
            List<int> numbers = new List<int>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                numbers.Add(random.Next(-100000, 100000));
            }

            return numbers;
        }
        static void AppendToFile(string filePath, int number)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(number);
            }
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