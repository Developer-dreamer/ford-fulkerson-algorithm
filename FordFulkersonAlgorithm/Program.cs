using FordFulkersonAlgorithm;
using FordFulkersonAlgorithm.GraphGenerator;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello World");
        var graph = new Graph(200, 0.02, 'm');
        var graphMatrix = graph._graphMatrix;

        
        FordFulkerson m = new FordFulkerson(graphMatrix);
        Console.WriteLine("The maximum possible flow is " + FordFulkerson.FordFulkersonAlgorithm(0, 5));
    }
}
