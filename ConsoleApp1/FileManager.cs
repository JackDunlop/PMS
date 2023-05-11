﻿using System;
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

        public Dictionary<string, Job> CreateFile(Dictionary<string, Job> jobs)
        {
            string path = GetValidFileName();
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

        // rewrite over file method
    }
}