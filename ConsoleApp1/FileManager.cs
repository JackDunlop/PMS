using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Ass3
{
    public class FileManager
    {
        public Dictionary<string, Job> ReadJobs(string path, Dictionary<string, Job> jobs)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string jobId = parts[0].Trim();
                    uint jobTime = uint.Parse(parts[1]);
                    HashSet<string> jobDependencies = new HashSet<string>();

                    for (int i = 2; i < parts.Length; i++)
                    {
                        jobDependencies.Add(parts[i]);
                    }

                    Job job = new Job(jobId, jobTime, jobDependencies);
                    jobs[jobId] = job;
                }
                return jobs;
            }
        }

        public Dictionary<string, Job> CreateFile(Dictionary<string, Job> jobs, string path)
        {
            
            if (File.Exists(path))
            {
                Console.WriteLine($"Opening existing file: {path}");
                ReadJobs(path, jobs);
                foreach (Job job in jobs.Values)
                {
                    string dependencies = job.JobDependencies != null && job.JobDependencies.Any() ? $",{string.Join(",", job.JobDependencies)}" : "";
                    Console.WriteLine($"{job.JobID}, {job.JobTime}{dependencies}");
                }
                return jobs;
            }
            else
            {
                Console.WriteLine($"Creating new file: {path}");
                File.Create(path).Close();
                return null;
            }
        }

        private string GetValidFileName()
        {
            while (true)
            {
                Console.Write("Please enter file name: ");
                string readPathLine = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(readPathLine) && readPathLine.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    return readPathLine;
                   
                }
                else { Console.WriteLine("Please enter a non-null name or must have txt on the end."); continue; }
              
            }
        }
        public void UpdateFile(string path, Dictionary<string, Job> jobs)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (Job job in jobs.Values)
                {
                    string dependencies = job.JobDependencies != null && job.JobDependencies.Any() ? $",{string.Join(",", job.JobDependencies)}" : "";
                    writer.WriteLine($"{job.JobID}, {job.JobTime}{dependencies}");
                }
            }
        }
        public void UpdateSequence(LinkedList<string> sequence)
        {
            string path = "Sequence.txt";
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                if (File.Exists(path))
                {
                   
                    if (sequence != null)
                    {
                        writer.WriteLine($"{string.Join(", ", sequence)}");
                    }
                   
                }
                else
                {
              
                    if (sequence != null)
                    {
                        writer.WriteLine($"{string.Join(", ", sequence)}");
                    }
                    File.Create(path).Close();
                  
                }
            }
        }


        public void UpdateEarilestTimes(LinkedList<string> earilesttimes)
        {
            string path = "EarliestTimes.txt";
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                if (File.Exists(path))
                {

                    if (earilesttimes != null)
                    {
                        writer.WriteLine($"{string.Join(", ", earilesttimes)}");
                    }

                }
                else
                {

                    if (earilesttimes != null)
                    {
                        writer.WriteLine($"{string.Join(", ", earilesttimes)}");
                    }
                    File.Create(path).Close();

                }
            }
        }
        // rewrite over file method
    }
}