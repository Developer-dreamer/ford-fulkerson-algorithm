using System.Collections;
using System.ComponentModel;
using System.Diagnostics;


namespace FordFulkersonAlgorithm.GraphGenerator;
public class GraphAnaliser
{
    private int _verticesAmount;
    private double _density;
    private bool _graphsType;

    private int _flowSum;

    private List<int[,]> _graphsInMatrix;
    private List<List<List<(int, int)>>> _graphsInList;
    private ArrayList _statistics = new ArrayList();
    private string _pathToOutput;

    public GraphAnaliser(int verticesAmount, double density, bool type, string pathToOutput)
    {
        _verticesAmount = verticesAmount;
        _density = density;
        _graphsType = type;
        GenerateGraphs();
        _pathToOutput = pathToOutput;
    }

    private void GenerateGraphs()
    {
        if (_graphsType)
        {
            _graphsInMatrix = new();
            for (int i = 0; i < 20; i++)
            {
                var graph = new Graph(_verticesAmount, _density, _graphsType);
                _graphsInMatrix.Add(graph._graphMatrix);
            }
        }
        else { 

            _graphsInList = new ();
            for (int i = 0; i < 20; i++)
            {
                var graph = new Graph(_verticesAmount, _density, _graphsType);
                _graphsInList.Add(graph._graphList);
            }
        }
    }
    public void Analyse()
    {

        if (_graphsType)
        {
            var timer = new Stopwatch();
            for (int i = 0; i < _graphsInMatrix.Count; i++)
            {
                timer.Start();
                int flow = FordFulkerson.FordFulkersonAlgorithm(_graphsInMatrix[i], 0, 5);
                timer.Stop();

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

            var avgFlow = _flowSum / _graphsInMatrix.Count;

            using (var writer = new StreamWriter(_pathToOutput, true))
            {
                string result = $"Average flow: {avgFlow}";
                writer.WriteLine(result);
            }
        }
        else
        {
            var timer = new Stopwatch();
            for (int i = 0; i < _graphsInList.Count; i++)
            {
                timer.Start();
                int flow = FordFulkerson.FordFulkersonAlgorithm(_graphsInList[i], 0, 5);
                timer.Stop();

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

            var avgFlow = _flowSum / _graphsInList.Count;

            // Statistics.GetStatistics(new string[] { "Average flow: " + avgFlow }, _pathToOutput);

            using (var writer = new StreamWriter(_pathToOutput, true))
            {
                string result = $"Average flow: {avgFlow}";
                writer.WriteLine(result);
            }
        }
        
    }
}

