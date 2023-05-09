using System;

namespace Ass3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Job> jobs = new List<Job>();
            FileManager fileManager = new FileManager();
            fileManager.CreateFile(jobs);
            Console.WriteLine("---");
            foreach (Job job in jobs)
            {
                if (job.JobID == "T4") 
                {
                    string dependencies = job.JobDependencies != null && job.JobDependencies.Any() ? $"{string.Join(",", job.JobDependencies)}" : "";
                    Console.WriteLine($"{dependencies}");
                }
            }
            //Job jobA = new Job("T1", 5);gh
            //Job jobB = new Job("T2", 3);
            //Job jobC = new Job("T3", 4);
            //List<string> jobD_deps = new List<string> { "T1" };
            //Job jobD = new Job("T4", 6, jobD_deps);
            //List<string> jobE_deps = new List<string> { "T2", "T3" };
            //Job jobE = new Job("T5", 2, jobE_deps);
            //List<string> jobF_deps = new List<string> { "T4", "T5" };
            //Job jobF = new Job("T6", 7, jobF_deps);
            //List<Job> jobs = new List<Job> { jobA, jobB, jobC, jobD, jobE, jobF };
            //foreach (Job job in jobs)
            //{
            //    string dependencies = job.JobDependencies != null && job.JobDependencies.Any() ? $"{string.Join(",", job.JobDependencies)}" : "";
            //    Console.WriteLine($"{job.JobID}, {job.JobTime}, {dependencies}");
            //    Console.WriteLine();
            //}


        }
    }
}