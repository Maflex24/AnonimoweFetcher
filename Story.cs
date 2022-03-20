using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AnonimoweFetcher
{
    internal class Story
    {
        public string Content { get; set; }

        public Story(string content) => Content = content;

        public static List<Story> RemoveDuplicates(List<Story> list)
        {
            Console.WriteLine("Started removing duplicates");
            int beforeCount = list.Count;
            if (list.Count > 2)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 1; j < list.Count; j++)
                    {
                        if (i != j && list[i].Content == list[j].Content)
                        {
                            list.Remove(list[j]);
                        }
                    }
                }
            }

            Console.WriteLine($"Removing duplicates is finished. We had {beforeCount} stories, now we have {list.Count}. We removed {beforeCount - list.Count} duplicates");
            return list;
        }
    }
}







