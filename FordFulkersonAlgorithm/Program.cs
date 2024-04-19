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

        
        var analiser = new GraphAnaliser(300, 0.8, isList, fullPath);

        var analiser1 = new GraphAnaliser(300, 0.8, isMatrix, fullPath);


        analiser.Analyse();
        analiser1.Analyse();

        Console.WriteLine("Done");
    }
}
