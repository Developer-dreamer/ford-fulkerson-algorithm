using System.Collections;
using System.ComponentModel;
using System.Diagnostics;


namespace FordFulkersonAlgorithm.GraphGenerator;
public class GraphAnaliser
{
    // Properties for generated graphs

    private int _verticesAmount;
    private double _density;
    private int _maxWeight;
    private bool _graphsType;

    // Properties for statistics
    private int _flowSum;

    // Properties for generated graphs
    private List<int[,]> _graphsInMatrix;
    private List<List<List<(int, int)>>> _graphsInList;
    private ArrayList _statistics = new ArrayList();
    private string _pathToOutput;

    // Constructor
    public GraphAnaliser(int verticesAmount, double density, int maxWeight, bool type, string pathToOutput)
    {
        _verticesAmount = verticesAmount;
        _density = density;
        _graphsType = type;
        GenerateGraphs();
        _pathToOutput = pathToOutput;
        _maxWeight = maxWeight;
    }

    // Method for generating graphs
    private void GenerateGraphs()
    {
        // If the graph is generated as a matrix
        if (_graphsType)
        {
            _graphsInMatrix = new();
            for (int i = 0; i < 10; i++)
            {
                var graph = new Graph(_verticesAmount, _density, _maxWeight, _graphsType);
                _graphsInMatrix.Add(graph._graphMatrix);
            }
        }
        // If the graph is generated as a list
        else { 

            _graphsInList = new ();
            for (int i = 0; i < 10; i++)
            {
                var graph = new Graph(_verticesAmount, _density, _maxWeight, _graphsType);
                _graphsInList.Add(graph._graphList);
            }
        }
    }
    public void Analyse()
    {
        // If the graph is generated as a matrix
        if (_graphsType)
        {
            var timer = new Stopwatch();
            for (int i = 0; i < _graphsInMatrix.Count; i++)
            {
                timer.Start();
                int flow = FordFulkerson.FordFulkersonAlgorithm(_graphsInMatrix[i], 0, 5);
                timer.Stop();

                // Add statistics to the list
                _statistics.AddRange(new object[] {
                    _verticesAmount,
                    _density,
                    _graphsType ? "Matrix" : "List",
                    flow,
                    timer.Elapsed
                });

                Statistics.GetStatistics(_statistics, _pathToOutput);

                _statistics.Clear();
                _flowSum += flow;
            }

            // Calculate the average flow
            var avgFlow = _flowSum / _graphsInMatrix.Count;

            // Save the average flow to the file
            using (var writer = new StreamWriter(_pathToOutput, true))
            {
                string result = $"Average flow: {avgFlow}";
                writer.WriteLine(result);
            }
        }
        // If the graph is generated as a list
        else
        {
            var timer = new Stopwatch();
            for (int i = 0; i < _graphsInList.Count; i++)
            {
                timer.Start();
                int flow = FordFulkerson.FordFulkersonAlgorithm(_graphsInList[i], 0, 5);
                timer.Stop();

                // Add statistics to the list
                _statistics.AddRange(new object[] {
                    _verticesAmount,
                    _density,
                    _graphsType ? "Matrix" : "List",
                    flow,
                    timer.Elapsed
                });

                Statistics.GetStatistics(_statistics, _pathToOutput);
                _statistics.Clear();
                _flowSum += flow;
            }

            // Calculate the average flow
            var avgFlow = _flowSum / _graphsInList.Count;

            // Save the average flow to the file
            using (var writer = new StreamWriter(_pathToOutput, true))
            {
                string result = $"Average flow: {avgFlow}";
                writer.WriteLine(result);
            }
        }
        
    }
}

