using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordFulkersonAlgorithm.GraphGenerator;
public class GraphAnaliser
{
    private List<int[,]> _graphsInMatrix;
    private List<List<List<(int, int)>>> _graphsInList;
    private int _verticesAmount;
    private double _density;
    private bool _graphsType;
    public GraphAnaliser(int verticesamount, double density, bool type)
    {
        _verticesAmount = verticesamount;
        _density = density;
        _graphsType = type;
        GenerateGraphs();
    }

    private void GenerateGraphs()
    {
        if (_graphsType)
        {

        }
        else { 

            _graphsInList = new List<List<List<(int, int)>>>();
            for (int i = 0; i < 1000; i++)
            {
                var graph = new Graph(_verticesAmount, _density, _graphsType);
                _graphsInList.Add(graph._graphList);
            }
        }

        
    }
    public void Analyse()
    {
        if (_graphsType) { 
            var timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < _graphsInMatrix.Count; i++)
            {
                Console.WriteLine($"The maximum possible flow is {FordFulkerson.FordFulkersonAlgorithm(_graphsInMatrix[i], 0, 5)}");
            }
            timer.Stop();
            Console.WriteLine("Time elapsed: " + timer.Elapsed);
        }
        else
        {
            var timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < _graphsInList.Count; i++)
            {
                Console.WriteLine($"The maximum possible flow is {FordFulkerson.FordFulkersonAlgorithm(_graphsInList[i], 0, 5)}");
            }
            timer.Stop();
            Console.WriteLine("Time elapsed: " + timer.Elapsed);
        }
    }
}

