using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._05._2023
{
    internal class cs3
    {
        public static void task_3()
        {
            Console.WriteLine("Введіть шлях до файлу з текстом:");
            string textFilePath = Console.ReadLine();

            Console.WriteLine("Введіть шлях до файлу зі словами для модерації:");
            string moderationWordsFilePath = Console.ReadLine();

            try
            {
                string[] moderationWords = File.ReadAllLines(moderationWordsFilePath);
                ModerateTextFile(textFilePath, moderationWords);
                Console.WriteLine("Модерація завершена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка під час модерації: " + ex.Message);
            }

        }
        static void ModerateTextFile(string filePath, string[] moderationWords)
        {
            string fileContent = File.ReadAllText(filePath);

            foreach (string moderationWord in moderationWords)
            {
                string replacement = new string('*', moderationWord.Length);
                fileContent = fileContent.Replace(moderationWord, replacement);
            }

            File.WriteAllText(filePath, fileContent);
        }
    }
}