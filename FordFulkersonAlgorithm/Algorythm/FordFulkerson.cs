namespace FordFulkersonAlgorithm;

public class FordFulkerson
{
    private static int V;
    public static int[,] _graph;

    public FordFulkerson(int[,] graph)
    {
        V = CountVertices(graph);
        _graph = graph;

    }

    static bool BFS(int[,] graph, int source, int target, Dictionary<int, int> origins)
    {
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


    public static int FordFulkersonAlgorithm(int source, int target)
    {
        int[,] graphCopy = (int[,])_graph.Clone();
        Dictionary<int, int> origins = new Dictionary<int, int>();
        var maxFlow = 0;
        while (BFS(graphCopy, source, target, origins))
        {
            var pathFlow = int.MaxValue;
            for (int v = target; v != source; v = origins[v])
            {
                int u = origins[v];
                pathFlow = Math.Min(pathFlow, graphCopy[u, v]);
            }

            for (int v = target;  v != source; v = origins[v])
            {
                int u = origins[v];
                graphCopy[u, v] -= pathFlow;
                graphCopy[v, u] += pathFlow;
            }

            maxFlow += pathFlow;
        }

        return maxFlow;
    }

    public static int CountVertices(int[,] graph)
    {
        int vertices = 0;
        for (int i = 0; i < graph.GetLength(0); i++)
        {
            vertices++;
        }

        return vertices;
    }
}

