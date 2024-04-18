using FordFulkersonAlgorithm;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello World");
        int[,] graph = 
        {
            { 0, 16, 13, 0, 0, 0 },
            { 0, 0, 10, 12, 0, 0 },
            { 0, 4, 0, 0, 14, 0 },
            { 0, 0, 9, 0, 0, 20 },
            { 0, 0, 0, 7, 0, 4 },
            { 0, 0, 0, 0, 0, 0 }
        };
        Console.WriteLine("Hello World");
        var adjacencyList = new List<List<(int, int)>>();

        adjacencyList.Add(new List<(int, int)> { (1, 16), (2, 13) });

        adjacencyList.Add(new List<(int, int)> { (2, 10), (3, 12) });

        adjacencyList.Add(new List<(int, int)> { (1, 4), (4, 14) });

        adjacencyList.Add(new List<(int, int)> { (2, 9), (5, 20) });

        adjacencyList.Add(new List<(int, int)> { (3, 7), (5, 4) });

        adjacencyList.Add(new List<(int, int)>());



        Console.WriteLine("The maximum possible flow is " + FordFulkerson.FordFulkersonAlgorithm(graph, 0, 5));
        
        Console.WriteLine("The maximum possible flow is " + FordFulkerson.FordFulkersonAlgorithm(adjacencyList, 0, 5));
}}
