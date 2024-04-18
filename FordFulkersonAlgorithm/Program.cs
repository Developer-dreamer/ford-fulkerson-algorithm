using FordFulkersonAlgorithm;
using FordFulkersonAlgorithm.GraphGenerator;
public class Program
{
    public static void Main()
    {
        bool isMatrix = true;
        bool isList = false;

        var analiser = new GraphAnaliser(200, 0.1, isList);

        analiser.Analyse();
    }
}
