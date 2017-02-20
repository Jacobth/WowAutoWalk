using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWObjMgr
{
    class ShortestPath
    {

        Dictionary<int, Dictionary<int, int>> vertices = new Dictionary<int, Dictionary<int, int>>();

        public void add_vertex(int name, Dictionary<int, int> edges)
        {
            vertices[name] = edges;
        }

        public List<int> shortest_path(int start, int finish)
        {
            var previous = new Dictionary<int, int>();
            var distances = new Dictionary<int, int>();
            var nodes = new List<int>();

            List<int> path = null;

            foreach (var vertex in vertices)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
                }

                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == finish)
                {
                    path = new List<int>();
    
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in vertices[smallest])
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }

            return path;
        }
    }
}
