using System.Numerics;
using FordFulkersonAlgorithm;
using FordFulkersonAlgorithm.GraphGenerator;
public class Program
{
    public static void Main()
    {
        string fullPath = Path.Combine("..", "..", "..", "GraphGenerator", "statistics.csv");

        bool resetCurrentStatistics = true;
        if (resetCurrentStatistics)
        {
            File.WriteAllText(fullPath, string.Empty);
            string[] values = { "Vertices", "Density", "Type", "Flow", "Time" };
            Statistics.GetStatistics(values, fullPath);
        }

        bool isMatrix = true;
        bool isList = false;

        
        var analiser = new GraphAnaliser(200, 0.1, isList, fullPath);

        analiser.Analyse();

        Console.WriteLine("Done");
    }
}
