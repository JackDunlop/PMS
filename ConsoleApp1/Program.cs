using System;

namespace Ass3
{
    class Program
    {
        static void Main(string[] args)
        {
            Job jobA = new Job("A", 5);
            Job jobB = new Job("B", 3);
            Job jobC = new Job("C", 4);
            List<string> jobD_deps = new List<string> { "A" };
            Job jobD = new Job("D", 6, jobD_deps);
            List<string> jobE_deps = new List<string> { "B", "C" };
            Job jobE = new Job("E", 2, jobE_deps);
            List<string> jobF_deps = new List<string> { "D", "E" };
            Job jobF = new Job("F", 7, jobF_deps);
            List<Job> jobs = new List<Job> { jobA, jobB, jobC, jobD, jobE, jobF };
            foreach (Job job in jobs)
            {
                string dependencies = job.JobDependencies != null && job.JobDependencies.Any() ? $"{string.Join(",", job.JobDependencies)}" : "";
                Console.WriteLine($"{job.JobID}, {job.JobTime}, {dependencies}");
                Console.WriteLine();
            }


        }
    }
}