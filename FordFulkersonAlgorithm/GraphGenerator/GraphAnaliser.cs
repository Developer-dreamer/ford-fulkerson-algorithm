using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordFulkersonAlgorithm.GraphGenerator;
public class GraphAnaliser
{
    private List<int[,]> _graphs;
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
        _graphs = new List<int[,]>();

        for (int i = 0; i < 1000; i++)
        {
            var graph = new Graph(_verticesAmount, _density, _graphsType);
            _graphs.Add(graph._graphMatrix);
        }
    }
    public void Analyse()
    {
        var timer = new Stopwatch();
        timer.Start();
        for (int i = 0; i < _graphs.Count; i++)
        {
            FordFulkerson m = new FordFulkerson(_graphs[i]);
            //Console.WriteLine("The maximum possible flow is " + FordFulkerson.FordFulkersonAlgorithm(0, 5));
        }
        timer.Stop();
        Console.WriteLine("Time elapsed: " + timer.Elapsed);
    }
}

