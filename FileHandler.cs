using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AnonimoweFetcher
{
    internal static class FileHandler
    {
        public static readonly string MyDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AnonimoweStories");

        public static void ExportListToJson<T>(List<T> list, string path)
        {
            var serializedList = JsonConvert.SerializeObject(list);

            //using (var createDirectory = new FileStream(MyDirectory, FileMode.Open))
            //{
            if (!Directory.Exists(MyDirectory))
                Directory.CreateDirectory(MyDirectory);
            //}

            var myFile = Path.Combine(MyDirectory, path);

            using (var fileCreate = new FileStream(myFile, FileMode.Create))
            {
                if (!File.Exists(myFile))
                    File.Create(myFile);
            }

            File.AppendAllText(Path.Combine(MyDirectory, path), serializedList);
        }

        public static void SaveHTMLPage(string pageContent, int StoryNumber)
        {
            var filePath = Path.Combine(MyDirectory, $"Story{StoryNumber}.html");

            using (var fileCreate = new FileStream(filePath, FileMode.Create))
            {
                if (!File.Exists(filePath))
                    File.Create(filePath);
            }

            File.AppendAllText(filePath, pageContent);
        }

        public static List<Story> ImportStoriesList(string path)
        {
            List<Story> stories = new List<Story>();
            var filePath = Path.Combine(MyDirectory, path);

            string fileContent = String.Empty;
            using (var stream = File.OpenRead(filePath))
            {
                fileContent = File.ReadAllText(filePath);
            }

            //var fileContent = File.ReadAllText(filePath);
            if (fileContent.Length > 5)
                stories = JsonConvert.DeserializeObject<List<Story>>(fileContent);

            Console.WriteLine($"Imported {stories.Count} stories from json file");
            return stories;
        }
    }
}
