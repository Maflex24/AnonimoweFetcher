using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonimoweFetcher
{
    internal class HTMLGenerator
    {
        public static void GenerateHTMLPage(List<Story> list)
        {
            var random = new Random();


            for (int i = 0; i < list.Count; i++)
            {
                string pageContent = $"<!DOCTYPE html> <html lang=\"pl\"><head> <meta charset=\"UTF-8\"> <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"> <link rel=\"stylesheet\" href=\"style.css\"> <title>Story #{i}</title></head> <body onload=\"randomStory()\"> <div class=\"container\"> <div class=\"story\">Story #{i} <br>{list[i].Content}</div> <div id=\"nextStoryButton\"><button type=\"button\"><a href=\"Story{i - 1}.html\">Previous Story</a></button> <span id=\"randomButton\" onclick=\"randomStory\"></span> <button type=\"button\"><a href=\"Story{i + 1}.html\">Next Story</a></button></div> </div> <script> let StoryNumber = {i}; let totalStories = {list.Count};</script> <script type=\"text/javascript\" src=\"script.js\"></script></body></html>";

                //Console.WriteLine(pageContent);
                FileHandler.SaveHTMLPage(pageContent, i);
            }
        }


    }
}
