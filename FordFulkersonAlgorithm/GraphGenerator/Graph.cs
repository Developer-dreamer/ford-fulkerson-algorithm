namespace FordFulkersonAlgorithm.GraphGenerator;

public class Graph
{
    public int[,] _graphMatrix;
    private List<List<int>> _graphList;
    private int _verticesAmount;
    private double _density;
    public Graph(int n, double p, char generationType)
    {
        _verticesAmount = n;
        _density = p;
        switch (generationType)
        {
            case 'm':
                _graphMatrix = GenerateMatrix(_verticesAmount, _density);
                break;
            case 'l':
                _graphList = GenerateList(_verticesAmount, _density);
                break;
            default:
                _graphMatrix = GenerateMatrix(_verticesAmount, _density);
                break;
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