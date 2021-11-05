using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorsEmail.Datastructures;
using System.IO;

namespace MorsEmail.Models
{
    public class MessageViewer
    {
        public static SimpleStack<string> GETMessages(string currEmail, string friendEmail, string type)
        {
            string directory = $@".\accounts\{currEmail}\{type}\{friendEmail}";
            var fileCount = (from file in Directory.EnumerateFiles(directory, "*.txt", SearchOption.AllDirectories)
                             select file).Count();
            var fileNames = (from file in Directory.GetFiles(directory) select file).ToArray();

            string[] sortedFiles = InsertionSort.SortFiles(fileNames);

            SimpleStack<string> messagesPath = new SimpleStack<string>();

            foreach(string path in sortedFiles)
            {
                messagesPath.Push(path);
            }
            return messagesPath;

        }


    }
}
