namespace FordFulkersonAlgorithm.GraphGenerator;

public class Graph
{
    private int[,] _graphMatrix;
    private int _verticesAmount;
    private int _density;
    public Graph(int n, int p)
    {
        _verticesAmount = n;
        _density = p;
        _graphMatrix = Generate(_verticesAmount, _density);
    }

    private int[,] Generate(int vertices, int density)
    {
        return _graphMatrix;
    }
}