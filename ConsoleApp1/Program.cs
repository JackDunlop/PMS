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
            // Call TopologicalSort to get the sorted list of job IDs

            //Console.WriteLine("Topological Order:");
            //foreach (string jobId in topologicalOrder)
            //{
            //    Console.WriteLine(jobId);
            //}
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Add Job");
                Console.WriteLine("2) Remove Job");
                Console.WriteLine("3) Update Time");
                Console.WriteLine("4) Find Sequence");
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
                            Console.WriteLine($"{string.Join(", ", jobSequence)}");
                        }
                        fileManager.UpdateSequence(jobSequence);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}