using System.Runtime.CompilerServices;

namespace FordFulkersonAlgorithm.GraphGenerator;

public class Graph
{
    // Properties of the graph
    public int[,] _graphMatrix;
    public List<List<(int, int)>> _graphList;
    private int _verticesAmount;
    private double _density;
    private int _maxWeight;

    // Constructor
    public Graph(int n, double p, int w, bool generationType)
    {
        _verticesAmount = n;
        _density = p;
        _maxWeight = w;
   
        if (generationType)
        {
            _graphMatrix = GenerateMatrix();
        }
        else
        {
            _graphList = GenerateList();
        }
    }

    // Method for generating a matrix
    private int[,] GenerateMatrix()
    {
       _graphMatrix = new int[_verticesAmount, _verticesAmount];

        var random = new Random();

        for (int i = 0; i < _verticesAmount; i++ )
        {
            for (int j = 0; j < _verticesAmount; j++)
            {
                if ( random.NextDouble() < _density)
                {
                    _graphMatrix[i, j] = random.Next(1, _maxWeight + 1);
                }
                else
                {
                    _graphMatrix[i, j] = 0;
                }
            }
        }
        return _graphMatrix;
    }

    // Method for generating a list
    private List<List<(int, int)>> GenerateList()
    {
        List<List<(int, int)>> graph = new();
        var random = new Random();

        for (int i = 0; i < _verticesAmount; i++)
        {
            graph.Add(new List<(int, int)>());
        }

        for (int i = 0; i < _verticesAmount; i++)
        {
            for (int j = 0; j < _verticesAmount; j++)
            {
                if (i != j && random.NextDouble() < _density)
                {
                   graph[i].Add((j, random.Next(1, _maxWeight + 1)));
                }
            }
        }
        return graph;
    }
}