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
        public Dictionary<string, object> JobDependencies { get; set; }

        public Job(string jobId, uint jobTime, Dictionary<string, object> jobDependencies)
        {
            JobID = jobId;
            JobTime = jobTime;
            JobDependencies = jobDependencies;
        }
    }
   
}
