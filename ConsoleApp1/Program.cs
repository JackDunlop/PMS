using System;

namespace Ass3
{
    class Program
    {// updated
        static void Main(string[] args)
        {
          //  HashSet<Job> jobs = new HashSet<Job>();
            FileManager fileManager = new FileManager();
            Job jobManger = new Job();

            Dictionary<string, Job> jobs = new Dictionary<string, Job>();
            fileManager.CreateFile(jobs);
            jobManger.AddJobDependency(jobs);

        }
    }
}