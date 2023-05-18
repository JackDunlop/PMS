using System;

namespace Ass3
{
    class Program
    {// updated
        static void Main(string[] args)
        {
            string path;
          //  HashSet<Job> jobs = new HashSet<Job>();
            FileManager fileManager = new FileManager();
            Job jobManager = new Job();
          //  Graph gmanager = new Graph();
            Dictionary<string, Job> jobs = new Dictionary<string, Job>();
            while (true)
            {
                Console.Write("Please enter file name: ");
                string readPathLine = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(readPathLine) && readPathLine.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    path = readPathLine;
                    fileManager.CreateFile(jobs, path);
                    break;
                }
                else { Console.WriteLine("Please enter a non-null name or must have txt on the end."); continue; }

            }
          
            while (true)
            {
                Console.WriteLine("Choose an option, enter exit if you goto the wrong menu:");
                Console.WriteLine("If you enter the wrong input for a menu type 'back' and you will go back to the main menu, this can be done anywhere in the program ");
                Console.WriteLine("1) Add Job");
                Console.WriteLine("2) Remove Job");
                Console.WriteLine("3) Update Time");
                Console.WriteLine("4) Find Sequence");
                Console.WriteLine("5) Find Earliest Time to complete");
                Console.WriteLine("6) Exit Program");
                Console.Write("\nSelect an option: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        jobManager.AddJob(jobs);
                        fileManager.UpdateFile(path, jobs);
                        break;
                    case "2":
                        jobManager.RemoveJob(jobs);
                        fileManager.UpdateFile(path, jobs);
                        break;
                    case "3":
                        jobManager.UpdateJob(jobs);
                        fileManager.UpdateFile(path, jobs);
                        break;
                    case "4":
                        LinkedList<string> jobSequence = jobManager.FindJobSequence(jobs);
                        if (jobSequence != null)
                        {
                            Console.WriteLine($"{string.Join(",", jobSequence)}");
                        }
                        fileManager.UpdateSequence(jobSequence);
                        break;

                    case "5":
                        LinkedList<string> jobearliest = jobManager.FindEarliestTime(jobs);
                        if (jobearliest != null)
                        {
                            Console.WriteLine($"{string.Join("", jobearliest)}");
                        }
                        fileManager.UpdateEarilestTimes(jobearliest);
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}
