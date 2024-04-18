using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordFulkersonAlgorithm.GraphGenerator;
public class GraphAnaliser<T>
{
    private T _graphToAnalis;
    private int _verticesAmount;
    private double _density;
    public GraphAnaliser(T graph, int verticesAmount, double density)
    {
        _graphToAnalis = graph;
        _verticesAmount = verticesAmount;
        _density = density;
    }

    public void Analyse()
    {

    }
}

