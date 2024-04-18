using System.Collections;

namespace FordFulkersonAlgorithm.GraphGenerator;
public class Statistics
{
    public static void GetStatistics(ArrayList values, string pathToFile)
    {
        using (var writer = new StreamWriter(pathToFile, true))
        {
            //    string result = string.Join(", ", values.Cast<object>().Select(x => x.ToString()));
            string result = string.Join(
                ", ",
                values.Cast<object>().Select(
                    x => Convert.ToString(
                        x, System.Globalization.CultureInfo.InvariantCulture
                        )
                    )
                );


            writer.WriteLine(result);
        }
    }
    public static void GetStatistics(string[] values, string pathToFile)
    {
        if (File.Exists(pathToFile))
        {
            File.WriteAllText(pathToFile, string.Empty);
        }
        using (var writer = new StreamWriter(pathToFile, true))
        {
            string result = string.Join(", ", values);
            writer.WriteLine(result);
        }
        
    }
}

