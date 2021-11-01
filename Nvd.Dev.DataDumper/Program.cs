using System;
using Nvd.DataAccess;
using System.IO;

namespace Nvd.Dev.DataDumper
{
    class Program
    {
        private static NvdDataContext context;

        static void Main(string[] args)
        {
            context = new NvdDataContext();

            Console.Write("Enter the path to save the files to: ");
            var path = Console.ReadLine();

            foreach (var item in context.RawDownloads)
            {
                var fullPath = Path.Combine(path, item.ID + ".json");

                Console.WriteLine("Writing file {0}", fullPath.ToString());

                File.WriteAllText(fullPath.ToString(), item.result);
            }
        }
    }
}
