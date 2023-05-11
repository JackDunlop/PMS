using Ass3;
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




    }

}
