namespace FordFulkersonAlgorithm.GraphGenerator;

public class Graph
{
    public int[,] _graphMatrix;
    public List<List<int>> _graphList;
    private int _verticesAmount;
    private double _density;
    public Graph(int n, double p, bool generationType)
    {
        _verticesAmount = n;
        _density = p;
        if (generationType)
        {
            _graphMatrix = GenerateMatrix(n, p);
        }
        else
        {
            _graphList = GenerateList(n, p);
        }
    }

    private int[,] GenerateMatrix(int vertices, double density)
    {
       _graphMatrix = new int[vertices, vertices];

        var random = new Random();

        for (int i = 0; i < vertices; i++ )
        {
            for (int j = 0; j < vertices; j++)
            {
                if ( random.NextDouble() < density)
                {
                    _graphMatrix[i, j] = random.Next(1, 51);
                }
                else
                {
                    _graphMatrix[i, j] = 0;
                }
            }
        }
        return _graphMatrix;
    }

    private List<List<int>> GenerateList(int vertices, double density)
    {
        _graphList = new List<List<int>>();
        var random = new Random();

        for (int i = 0; i < vertices; i++)
        {
            _graphList.Add(new List<int>());
        }

        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                if (i != j && random.NextDouble() < density)
                {
                   _graphList[i].Add(j);
                }
                else
                {
                    _graphList[i].Add(0);
                }
            }
        }
        return new List<List<int>>();
    }
}