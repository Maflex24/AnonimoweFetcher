using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace AnonimoweFetcher
{
    internal class Fetcher
    {
        private const string BaseUrl = "https://anonimowe.pl/";

        public static async Task<List<Story>> GetStories(string url)
        {
            List<Story> stories = new List<Story>();

            var web = new HtmlWeb();
            var document = web.Load(url);

            var articles = document.QuerySelectorAll("article > section");

            foreach (var article in articles)
            {
                String storyContent = article.InnerText.TrimStart();

                Story story = new Story(storyContent);
                stories.Add(story);
            }

            return stories;
        }
    }
}
