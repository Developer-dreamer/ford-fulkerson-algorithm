namespace FordFulkersonAlgorithm;

public class FordFulkerson
{

    static bool BFS(int[,] graph, int source, int target, Dictionary<int, int> origins)
    {
        int V = graph.GetLength(0);
        List<int> visited = new List<int>();
        Queue<int> queue = new Queue<int>();
        visited.Add(source);
        queue.Enqueue(source);
        origins[source] = -1;
        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            for (int v = 0; v < V; v++)
            {
                if (!visited.Contains(v) && graph[u,v] > 0)
                {
                    if (v == target)
                    {
                        origins[v] = u;
                        return true;
                    }   
                    visited.Add(v);
                    queue.Enqueue(v);
                    origins[v] = u;
                }
            }
        }

        return false;
    }


    public static int FordFulkersonAlgorithm(int[,] graph, int source, int target)
    {
        Dictionary<int, int> origins = new Dictionary<int, int>();
        var maxFlow = 0;
        while (BFS(graph, source, target, origins))
        {
            var pathFlow = int.MaxValue;
            for (int v = target; v != source; v = origins[v])
            {
                int u = origins[v];
                pathFlow = Math.Min(pathFlow, graph[u, v]);
            }

            for (int v = target;  v != source; v = origins[v])
            {
                int u = origins[v];
                graph[u, v] -= pathFlow;
                graph[v, u] += pathFlow;
            }

            maxFlow += pathFlow;
        }

        return maxFlow;
    }
    
    
    static bool BFS(List<List<(int, int)>> adjacencyList, int source, int target, Dictionary<int, int> origins)
        {
            List<int> visited = new List<int>();
            Queue<int> queue = new Queue<int>();
            visited.Add(source);
            queue.Enqueue(source);
            origins[source] = -1;
            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                foreach (var (v, weight) in adjacencyList[u])
                {
                    if (!visited.Contains(v) && weight > 0)
                    {
                        if (v == target)
                        {
                            origins[v] = u;
                            return true;
                        }
                        visited.Add(v);
                        queue.Enqueue(v);
                        origins[v] = u;
                    }
                }
            }

            return false;
        }

    public static int FordFulkersonAlgorithm(List<List<(int, int)>> adjacencyList, int source, int target)
    {
        var adjacencyListCopy = adjacencyList;

        Dictionary<int, int> origins = new Dictionary<int, int>();
        var maxFlow = 0;
        while (BFS(adjacencyListCopy, source, target, origins))
        {
            var pathFlow = int.MaxValue;
            for (int v = target; v != source; v = origins[v])
            {
                int u = origins[v];
                foreach (var (vertex, weight) in adjacencyListCopy[u])
                {
                    if (vertex == v)
                    {
                        pathFlow = Math.Min(pathFlow, weight);
                        break;
                    }
                }
            }

            for (int v = target; v != source; v = origins[v])
            {
                int u = origins[v];
                for (int i = 0; i < adjacencyListCopy[u].Count; i++)
                {
                    var (vertex, weight) = adjacencyListCopy[u][i];
                    if (vertex == v)
                    {
                        adjacencyListCopy[u][i] = (vertex, weight - pathFlow);
                        break;
                    }
                }

                for (int i = 0; i < adjacencyListCopy[v].Count; i++)
                {
                    var (vertex, weight) = adjacencyListCopy[v][i];

                    if (vertex == u)
                    {
                        adjacencyListCopy[v][i] = (vertex, weight + pathFlow);
                        break;
                    }
                }
            }
            maxFlow += pathFlow;
        }

        return maxFlow;
    }


       
    }

