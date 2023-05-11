using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3
{
    public class Graph
    {
        private int V; 
        private LinkedList<int>[] adj; 

        public Graph(int v)
        {
            V = v;
            adj = new LinkedList<int>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new LinkedList<int>();
            }


        }
        public void AddEdge(int u, int v)
        {
            adj[u].AddLast(v);
        }

        public LinkedList<int> TopologicalSort()
        {
            int[] inDegree = new int[V];
            for (int u = 0; u < V; u++)
            {
                foreach (int v in adj[u])
                {
                    inDegree[v]++;
                }
            }

            Queue<int> q = new Queue<int>();
            for (int u = 0; u < V; u++)
            {
                if (inDegree[u] == 0)
                {
                    q.Enqueue(u);
                }
            }

            LinkedList<int> sorted = new LinkedList<int>();
            while (q.Count > 0)
            {
                int u = q.Dequeue();
                sorted.AddLast(u);
                foreach (int v in adj[u])
                {
                    if (--inDegree[v] == 0)
                    {
                        q.Enqueue(v);
                    }
                }
            }
            if (sorted.Count != V)
            {
                throw new Exception("Graph contains a cycle");
            }

            return sorted;
        
        
        }



    }
}
