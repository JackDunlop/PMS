using Ass3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Ass3
{
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
            JobDependencies = new HashSet<string>(jobDependencies.Select(d => d.Trim()));


        }
        public void UpdateJob(Dictionary<string, Job> jobs)
        {

            uint validtime;
            while (true)
            {
                Console.WriteLine("Please enter a name of a job you want to update: ");
                string updatejob = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(updatejob))
                {
                    if (jobs.ContainsKey(updatejob))
                    {
                        while (true)
                        {
                            Console.WriteLine("Please enter the Time to complete for this job: ");
                            string readnewjobtime = Console.ReadLine();
                            if (uint.TryParse(readnewjobtime, out validtime))
                            {
                                jobs[updatejob].JobTime = validtime; // Update job time here
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Enter a valid input");
                                continue;
                            }
                        }
                        Console.WriteLine($"Job '{updatejob}' has been updated.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This job isn't in our database. Try again.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid job name.");
                    continue;
                }
            }
            
            foreach (Job job in jobs.Values)
            {
                string dependencies = job.JobDependencies != null && job.JobDependencies.Any() ? $", {string.Join(",", job.JobDependencies)}" : "";
                Console.WriteLine($"{job.JobID}, {job.JobTime}{dependencies}");
            }
          //  LinkedList<string> sequence = FindJobSequence(jobs);
        }
        public void RemoveJob(Dictionary<string, Job> jobs)
        {
            while (true)
            {
                Console.WriteLine("Please enter a name of a job you want to remove: ");
                string removejob = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(removejob))
                {
                    if (jobs.ContainsKey(removejob))
                    {
                        // Remove the job from all dependencies
                        foreach (Job job in jobs.Values)
                        {//T4, 90,T1,T7
                            job.JobDependencies?.Remove(removejob);
                        }

                        // Remove the job from the dictionary
                        jobs.Remove(removejob);
                        Console.WriteLine($"Job '{removejob}' has been removed.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This job isn't in our database. Try again.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid job name.");
                    continue;
                }
            }//T4, 90, T1,T7
            foreach (Job job in jobs.Values)
            {
                string dependencies = job.JobDependencies != null && job.JobDependencies.Any() ? $", {string.Join(",", job.JobDependencies)}" : "";

                Console.WriteLine($"{job.JobID}, {job.JobTime}{dependencies}");
            }
          //  LinkedList<string> sequence = FindJobSequence(jobs);
        }
        public void AddJob(Dictionary<string, Job> jobs)
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
           // LinkedList<string> sequence = FindJobSequence(jobs);
            foreach (Job job in jobs.Values)
            {
                string dependencies = job.JobDependencies != null && job.JobDependencies.Any() ? $", {string.Join(",", job.JobDependencies)}" : "";

                Console.WriteLine($"{job.JobID}, {job.JobTime}{dependencies}");
            }
        }
        
        public LinkedList<string> FindJobSequence(Dictionary<string, Job> jobs)
        {
            LinkedList<string> sequence = new LinkedList<string>();// linked list which will be used to return the sorted sequence
            HashSet<string> visited = new HashSet<string>(); // keeping track of vistened jobs 

            foreach (Job job in jobs.Values)
            {
                if (!visited.Contains(job.JobID)) // Add a check for visited nodes
                {
                    if (!DFS(job, sequence, visited, jobs)) // error handling
                    {
                        Console.WriteLine("There is a circular dependency in the jobs graph.");
                        return null;
                    }
                }
            }

          
            return sequence;
        }

        private bool DFS(Job startJob, LinkedList<string> sequence, HashSet<string> visited, Dictionary<string, Job> jobs)
        {
            Stack<Job> stack = new Stack<Job>();
            stack.Push(startJob);

            while (stack.Count > 0)
            {
                Job job = stack.Peek();

                if (job.JobDependencies != null)
                {
                    bool allDependenciesVisited = true;

                    foreach (string dependencyId in job.JobDependencies)
                    {
                        if (!jobs.ContainsKey(dependencyId))
                        {
                            // Dependency job doesn't exist, so we skip it for now
                            continue;
                        }

                        Job dependencyJob = jobs[dependencyId];

                        if (!visited.Contains(dependencyJob.JobID))
                        {
                            if (stack.Contains(dependencyJob))
                            {
                                return false; 
                            }

                            stack.Push(dependencyJob);
                            allDependenciesVisited = false;
                            break;
                        }
                    }

                    if (!allDependenciesVisited)
                    {
                        continue;
                    }
                }

                stack.Pop();
                visited.Add(job.JobID);
                sequence.AddLast(job.JobID);
            }

            return true;
        }

    }

}
