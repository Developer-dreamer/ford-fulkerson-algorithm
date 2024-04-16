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

        
        FordFulkerson m = new FordFulkerson(graph);
        Console.WriteLine("The maximum possible flow is " + FordFulkerson.FordFulkersonAlgorithm(0, 5));
    }
}
