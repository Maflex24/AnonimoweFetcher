using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AnonimoweFetcher
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<Story> stories = new List<Story>();

            var storiesJSONPath = Path.Combine(FileHandler.MyDirectory, "stories.json");

            if (File.Exists(storiesJSONPath))
                stories = FileHandler.ImportStoriesList(storiesJSONPath);


            var newStories = await Fetcher.GetStories("https://anonimowe.pl/");

            string baseUrl = "https://anonimowe.pl/";
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Started fetching stories from webpage {i}");
                var currentUrlStories = await Fetcher.GetStories($"{baseUrl}{i}");

                foreach (var story in currentUrlStories)
                    stories.Add(story);
            }

            Console.WriteLine($"Now we have {stories.Count} stories");

            stories = Story.RemoveDuplicates(stories);

            Console.WriteLine($"There is {stories.Count} stories");

            FileHandler.ExportListToJson(stories, "stories.json");

            HTMLGenerator.GenerateHTMLPage(stories);
        }
    }
}
