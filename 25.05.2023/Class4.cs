using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._05._2023
{
    internal class cs4
    {
        public static void task_4()
        {
            Console.WriteLine("Введіть шлях до файлу:");
            string filePath = Console.ReadLine();

            try
            {
                string reversedContent = ReverseFileContent(filePath);
                string newFilePath = Path.Combine(Path.GetDirectoryName(filePath), "reversed_" + Path.GetFileName(filePath));
                SaveToFile(newFilePath, reversedContent);
                Console.WriteLine("Перевернутий вміст файлу збережено у новому файлі: " + newFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка під час перевертання файлу: " + ex.Message);
            }

        }
        static string ReverseFileContent(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            char[] contentArray = fileContent.ToCharArray();
            Array.Reverse(contentArray);
            return new string(contentArray);
        }

        static void SaveToFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}