using System.Numerics;
using FordFulkersonAlgorithm;
using FordFulkersonAlgorithm.GraphGenerator;
public class Program
{
    public static void Main()
    {

        // Path to the file where the statistics will be saved
        string fullPath = Path.Combine("..", "..", "..", "GraphGenerator", "statistics.csv");

        // If resetCurrentStatistics is set to true, the file will be cleared and the new statistics will be saved
        bool resetCurrentStatistics = true;
        if (resetCurrentStatistics)
        {
            File.WriteAllText(fullPath, string.Empty);
            string[] values = { "Vertices", "Density", "Type", "Flow", "Time" };
            Statistics.GetStatistics(values, fullPath);
        }

        // If isMatrix is set to true, the graph will be generated as a matrix, otherwise as a list
        bool isMatrix = true;
        bool isList = false;

        // The GraphAnaliser class is responsible for generating graphs and analysing them
        var analiser = new GraphAnaliser(50, 0.8, 20, isList, fullPath);

        // The Analyse method generates graphs and analyses them
        analiser.Analyse();

        Console.WriteLine("Done");
    }
}
