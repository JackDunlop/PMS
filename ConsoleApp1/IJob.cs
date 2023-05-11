using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3
{
    public interface IJob
    {

        string JobID { get; set; }

        uint JobTime { get; set; }

        HashSet<string> JobDependencies { get; set; } // updated


        // create add method

        // create remove method

        // update time method
    }

        
}

