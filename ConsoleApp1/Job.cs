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
        public List<string> JobDependencies { get; set; }

        public Job(string jobId, uint jobTime)
        {
            JobID = jobId;
            JobTime = jobTime;
        
        }

        public Job(string jobId, uint jobTime, List<string> jobDependencies)
        {
            JobID = jobId;
            JobTime = jobTime;
            JobDependencies = new List<string>(jobDependencies);
           
           
        }


    }

}
