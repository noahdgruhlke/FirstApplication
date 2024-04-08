using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    public class PersonalFileManager
    {
        private readonly string folderPath;

        public PersonalFileManager(string folderPath)
        {
            this.folderPath = folderPath;
        }

        public void AddNumberToPersonalFile(string fileName, int number)
        {
            try
            {
                string filePath = Path.Combine(folderPath, $"{fileName}.txt");
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(number);
                }
                Console.WriteLine($"Number '{number}' added to personal file '{fileName}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding number to personal file: {ex.Message}");
            }
        }

        public void RemoveNumberFromPersonalFile(string fileName, int number)
        {
            try
            {
                string filePath = Path.Combine(folderPath, $"{fileName}.txt");
                List<string> lines = new List<string>(File.ReadAllLines(filePath));
                lines.Remove(number.ToString());
                File.WriteAllLines(filePath, lines);
                Console.WriteLine($"Number '{number}' removed from personal file '{fileName}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing number from personal file: {ex.Message}");
            }
        }

        public List<int> GetAllNumbersFromPersonalFile(string fileName)
        {
            List<int> numbers = new List<int>();
            try
            {
                string filePath = Path.Combine(folderPath, $"{fileName}.txt");
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (int.TryParse(line, out int number))
                    {
                        numbers.Add(number);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting numbers from personal file: {ex.Message}");
            }
            return numbers;
        }
    }
}
