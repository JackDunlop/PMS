using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3
{
    public interface IJob
    {

        // half of the methods should be private or other  types of access modifiers for test sake i made them all public

        public string JobID { get; set; }
        public uint JobTime { get; set; }
        public HashSet<string> JobDependencies { get; set; }

        public void UpdateJob(Dictionary<string, Job> jobs);
        public void RemoveJob(Dictionary<string, Job> jobs);
        
        public void AddJob(Dictionary<string, Job> jobs);

        public LinkedList<string> FindJobSequence(Dictionary<string, Job> jobs);
        

       public bool DFS(Job startJob, LinkedList<string> sequence, HashSet<string> visited, Dictionary<string, Job> jobs);


        // all public for testing
        public LinkedList<string> FindEarliestTime(Dictionary<string, Job> jobs);
        

        public Dictionary<string, uint> CalculateEarliestTimes(Dictionary<string, HashSet<string>> graph, Dictionary<string, uint> durations);
        

        public HashSet<string> TopologicalSort(Dictionary<string, HashSet<string>> graph);

        public void DFS2(string node, Dictionary<string, HashSet<string>> graph, HashSet<string> visited, HashSet<string> order);
       


    }


}

