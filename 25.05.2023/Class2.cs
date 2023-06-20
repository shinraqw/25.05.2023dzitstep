using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._05._2023
{
    internal class cs2
    {
        public static void task_2()
        {
            Console.WriteLine("Введіть шлях до файлу:");
            string filePath = Console.ReadLine();

            Console.WriteLine("Введіть слово для пошуку:");
            string searchWord = Console.ReadLine();

            Console.WriteLine("Введіть слово для заміни:");
            string replaceWord = Console.ReadLine();

            try
            {
                int replacementsCount = ReplaceWordInFile(filePath, searchWord, replaceWord);
                Console.WriteLine("Замінено входжень слова: " + replacementsCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка під час заміни: " + ex.Message);
            }


        }
        static int ReplaceWordInFile(string filePath, string searchWord, string replaceWord)
        {
            string fileContent = File.ReadAllText(filePath);
            string modifiedContent = fileContent.Replace(searchWord, replaceWord);
            File.WriteAllText(filePath, modifiedContent);

            int replacementsCount = CountOccurrences(modifiedContent, replaceWord);
            return replacementsCount;
        }

        static int CountOccurrences(string content, string word)
        {
            int count = 0;
            int startIndex = 0;

            while ((startIndex = content.IndexOf(word, startIndex)) != -1)
            {
                count++;
                startIndex += word.Length;
            }

            return count;
        }
    }
}