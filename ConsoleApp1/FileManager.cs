using System;
using System.IO;

namespace Ass3
{
    public class FileManager
    {
        public void CreateFile()
        {
            string path = GetValidFileName();

            if (File.Exists(path))
            {
                Console.WriteLine($"Opening existing file: {path}");
            }
            else
            {
                Console.WriteLine($"Creating new file: {path}");
                File.Create(path).Close();
            }
        }

        private static string GetValidFileName()
        {
            while (true)
            {
                Console.Write("Please enter file name: ");
                string readPathLine = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(readPathLine) && readPathLine.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    return readPathLine;
                }

                Console.WriteLine("Please enter a non-null name or must have txt on the end.");
            }
        }
    }
}
