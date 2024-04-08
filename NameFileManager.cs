namespace FirstApplication
{
    public class NameFileManager
    {
        private readonly string filePath;
        private readonly string folderPath;

        public NameFileManager(string fileName, string folderPath)
        {
            // Set the file path and folder path
            this.filePath = fileName;
            this.folderPath = folderPath;
        }

        public void AddName(string name)
        {
            try
            {
                // Append the name to the file
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(name);
                }
                Console.WriteLine($"Name '{name}' added successfully.");

                // Create personal file for the name
                CreatePersonalFileForName(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding name: {ex.Message}");
            }
        }

        public List<string> GetNames()
        {
            List<string> names = new List<string>();
            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);
                names.AddRange(lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading names: {ex.Message}");
            }
            return names;
        }

        private void CreatePersonalFileForName(string name)
        {
            try
            {
                // Create a personal file for the name
                string personalFilePath = Path.Combine(folderPath, $"{name}.txt");
                File.WriteAllText(personalFilePath, $"Personal file for {name}");
                Console.WriteLine($"Personal file created for {name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating personal file for {name}: {ex.Message}");
            }
        }

        public List<string> GetNamesStartingWith(string prefix)
        {
            List<string> namesStartingWithPrefix = new List<string>();
            try
            {
                List<string> allNames = GetNames();
                foreach (string name in allNames)
                {
                    if (name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    {
                        namesStartingWithPrefix.Add(name);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving names starting with {prefix}: {ex.Message}");
            }
            return namesStartingWithPrefix;
        }

        public void CreatePersonalFiles()
        {
            List<string> names = GetNames();
            foreach (string name in names)
            {
                try
                {
                    // Create a personal file for each name
                    string personalFilePath = $"{name}.txt";
                    File.WriteAllText(personalFilePath, $"Personal file for {name}");
                    Console.WriteLine($"Personal file created for {name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating personal file for {name}: {ex.Message}");
                }
            }
        }

        public bool NameExists(string name)
        {
            try
            {
                List<string> names = GetNames();
                return names.Contains(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if name exists: {ex.Message}");
                return false;
            }
        }

    }
}
