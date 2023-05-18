using System;
using System.Collections.Generic;
using System.Linq;
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
                                jobs[updatejob].JobTime = validtime; 
                                break;
                            }
                            else if (readnewjobtime.ToLower() == "back")
                            {
                                Console.WriteLine("Exiting menu...");
                                return;
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
                        break;
                    }
                }
                else if (updatejob.ToLower() == "back")
                {
                    Console.WriteLine("Exiting menu...");
                    return;
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
                       
                        foreach (Job job in jobs.Values)
                        {
                            job.JobDependencies?.Remove(removejob);
                        }

                        jobs.Remove(removejob);
                        Console.WriteLine($"Job '{removejob}' has been removed.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This job isn't in our database. Try again.");
                        break;
                    }
                }
                else if (removejob.ToLower() == "back")
                {
                    Console.WriteLine("Exiting menu...");
                    return;
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
                else if (readnewjobname.ToLower() == "back")
                {
                    Console.WriteLine("Exiting menu...");
                    return;
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
                else if (readnewjobtime.ToLower() == "back")
                {
                    Console.WriteLine("Exiting menu...");
                    return;
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
                        while (true) 
                        {
                            Console.WriteLine($"Please enter the name of dependency {i + 1}: ");
                            string readnewjobdep = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(readnewjobdep))
                            {
                                Console.WriteLine("Invalid name please try again, can't be blank space: ");
                                continue;
                            }
                            else if (readnewjobdep.ToLower() == "back")
                            {
                                Console.WriteLine("Exiting menu...");
                                return;
                            }
                            else
                            {
                                Console.WriteLine($"Added dependency {readnewjobdep}");
                                jobDependencies.Add(readnewjobdep);
                                break;
                            }
                        }
                        
                    }
                    break;
                }
                else if (readnewnumberofdep.ToLower() == "back")
                {
                    Console.WriteLine("Exiting menu...");
                    return;
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
            LinkedList<string> sequence = new LinkedList<string>();
            HashSet<string> visited = new HashSet<string>(); 

            foreach (Job job in jobs.Values)
            {
                if (!visited.Contains(job.JobID)) 
                {
                    if (!DFS(job, sequence, visited, jobs)) 
                    {
                        Console.WriteLine("There is a circular dependency in the jobs graph.");
                        return null;
                    }
                }
            }

          
            return sequence;
        }

        public bool DFS(Job startJob, LinkedList<string> sequence, HashSet<string> visited, Dictionary<string, Job> jobs)
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


        // all public for testing
        public LinkedList<string> FindEarliestTime(Dictionary<string, Job> jobs)
        {
            LinkedList<string> earliestTime = new LinkedList<string>();
            Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();
            Dictionary<string, uint> durations = new Dictionary<string, uint>();
            List<string> jobKeys = new List<string>(jobs.Keys);
           
            foreach (KeyValuePair<string, Job> job in jobs)
            {
                string task = job.Key;
                durations[task] = job.Value.JobTime;
                if (!graph.ContainsKey(task))
                    graph[task] = new HashSet<string>();

                foreach (string dependency in job.Value.JobDependencies)
                {
                    graph[task].Add(dependency);
                }
            }
            //Dictionary<string, uint> earliestTimes = CalculateEarliestTimes(graph, durations);
            //SortedDictionary<string, uint> sortedEarliestTimes = new SortedDictionary<string, uint>(earliestTimes);
            //earliestTimes = new Dictionary<string, uint>(sortedEarliestTimes);
            //Console.WriteLine("Sorted lexicographically, nothing in given sheets said anything about how these should be ordered, in terms of ordered based on when they were added or anything like that so I ordered it lexicographically.");
            //foreach (KeyValuePair<string, uint> pair in earliestTimes)
            //{
            //    earliestTime.AddLast($"{pair.Key}, {pair.Value}\n");
            //}

            //return earliestTime;
            Dictionary<string, uint> earliestTimes = CalculateEarliestTimes(graph, durations);
           // Console.WriteLine("Order is based on the order items were added to 'jobs'.");
            foreach (string task in jobKeys)
            {
                if (earliestTimes.ContainsKey(task))
                {
                    earliestTime.AddLast($"{task}, {earliestTimes[task]}\n");
                }
            }

            return earliestTime;
        }

        public Dictionary<string, uint> CalculateEarliestTimes(Dictionary<string, HashSet<string>> graph, Dictionary<string, uint> durations)
        {
            Dictionary<string, uint> earliestTimes = new Dictionary<string, uint>();

            HashSet<string> order = TopologicalSort(graph);

            foreach (string node in order)
            {
                uint maxCompletionTime = 0;
                if (graph.ContainsKey(node))
                {
                    foreach (string dependency in graph[node])
                    {
                        uint completionTime = 0;
                        if (earliestTimes.ContainsKey(dependency) && durations.ContainsKey(dependency))
                        {
                            completionTime = earliestTimes[dependency] + durations[dependency];

                        }
                        
                        else
                        {
                            Console.WriteLine($"The Job '{dependency}' that your Job '{node}' Depends on hasn't been added, please add the required job.");
                            continue; // Skip to next dependency
                        }
                        maxCompletionTime = Math.Max(maxCompletionTime, completionTime);

                    }
                }
                else
                {
                   // Console.WriteLine($"The Job '{node}' that your Job Depends on hasn't been added, please add the required job.");
                    continue;

                }
                earliestTimes[node] = maxCompletionTime;
            }

            return earliestTimes;
        }

        public HashSet<string> TopologicalSort(Dictionary<string, HashSet<string>> graph)
        {
            HashSet<string> visited = new HashSet<string>();
            HashSet<string> order = new HashSet<string>();

            foreach (string node in graph.Keys)
            {
                if (!visited.Contains(node))
                    DFS2(node, graph, visited, order);
            }

            return order;
        }

        public void DFS2(string node, Dictionary<string, HashSet<string>> graph, HashSet<string> visited, HashSet<string> order)
        {
            visited.Add(node);

            if (graph.ContainsKey(node))
            {
                foreach (string neighbor in graph[node])
                {
                    if (!visited.Contains(neighbor))
                        DFS2(neighbor, graph, visited, order);
                }
            }

            order.Add(node);
        }












        //public LinkedList<string> FindJobSequenceWithRecursion(Dictionary<string, Job> jobs)
        //{
        //    LinkedList<string> sequence = new LinkedList<string>();
        //    HashSet<string> visited = new HashSet<string>();
        //    HashSet<string> recursionStack = new HashSet<string>();
        //    foreach (Job job in jobs.Values)
        //    {
        //        if (!visited.Contains(job.JobID)) 
        //        {
        //            if (!DFSWithRecursion(job, sequence, visited, recursionStack, jobs)) 
        //            {
        //                Console.WriteLine("There is a circular dependency in the jobs graph.");
        //                return null;
        //            }
        //        }
        //    }
        //    return sequence;
        //}

        //private bool DFSWithRecursion(Job startJob, LinkedList<string> sequence, HashSet<string> visited, HashSet<string> recursionStack, Dictionary<string, Job> jobs)
        //{
        //    Stack<Job> stack = new Stack<Job>();
        //    stack.Push(startJob);
        //    recursionStack.Add(startJob.JobID); // Add to recursion stack

        //    while (stack.Count > 0)
        //    {
        //        Job job = stack.Peek();

        //        if (job.JobDependencies != null)
        //        {
        //            bool allDependenciesVisited = true;

        //            foreach (string dependencyId in job.JobDependencies)
        //            {
        //                if (!jobs.ContainsKey(dependencyId))
        //                {
                            
        //                    continue;
        //                }

        //                Job dependencyJob = jobs[dependencyId];

        //                if (!visited.Contains(dependencyJob.JobID))
        //                {
        //                    if (recursionStack.Contains(dependencyJob.JobID)) 
        //                    {
        //                        return false;
        //                    }

        //                    stack.Push(dependencyJob);
        //                    recursionStack.Add(dependencyJob.JobID); 
        //                    allDependenciesVisited = false;
        //                    break;
        //                }
        //            }

        //            if (!allDependenciesVisited)
        //            {
        //                continue;
        //            }
        //        }

        //        stack.Pop();
        //        visited.Add(job.JobID);
        //        recursionStack.Remove(job.JobID); 
        //        sequence.AddLast(job.JobID);
        //    }

        //    return true;
        //}

    }

}
