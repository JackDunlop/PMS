using Ass3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Ass3
{// updated
    public class Job : IJob
    {
        public string JobID { get; set; }
        public uint JobTime { get; set; }
        public HashSet<string> JobDependencies { get; set; }


        public Job()
        {
         
        }
        public Job(string jobId, uint jobTime)
        {
            JobID = jobId;
            JobTime = jobTime;
        
        }

        public Job(string jobId, uint jobTime, HashSet<string> jobDependencies)
        {
            JobID = jobId;
            JobTime = jobTime;
            JobDependencies = new HashSet<string>(jobDependencies);
           
           
        }
        public void AddJobDependency(Dictionary<string, Job> jobs)
        {
            string readnewjobname;
            uint validtime = 0;

            while (true)
            {
                Console.WriteLine("Please enter the name of the new job: ");
                readnewjobname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(readnewjobname))
                {
                    Console.WriteLine("Invalid name please try again: ");
                    continue;
                }
                else if (jobs.ContainsKey(readnewjobname)) 
                {
                    Console.WriteLine("This job is already in our database.");
                    continue;
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Please enter the Time to complete for this new job: ");
                string readnewjobtime = Console.ReadLine();
                if (uint.TryParse(readnewjobtime, out validtime))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid input");
                    continue;
                }
            }

            HashSet<string> jobDependencies = new HashSet<string>();

            while (true)
            {
                Console.WriteLine("Please enter the number of dependencies this job will have: ");
                string readnewnumberofdep = Console.ReadLine();
                int numberofdep;
                if (int.TryParse(readnewnumberofdep, out numberofdep))
                {
                    for (int i = 0; i < numberofdep; i++)
                    {
                        Console.WriteLine($"Please enter the name of dependency {i + 1}: ");
                        string readnewjobdep = Console.ReadLine();
                        jobDependencies.Add(readnewjobdep);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid input");
                    continue;
                }
            }
            Job newJob = new Job(readnewjobname, validtime, jobDependencies);
            jobs[readnewjobname] = newJob;
            foreach (Job job in jobs.Values)
            {
                string dependencies = job.JobDependencies != null && job.JobDependencies.Any() ? $", {string.Join(",", job.JobDependencies)}" : "";

                Console.WriteLine($"{job.JobID}, {job.JobTime}{dependencies}");
            }
        }
      

    }

}
