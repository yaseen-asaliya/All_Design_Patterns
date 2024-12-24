using DataProcess;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CSV Data Processing:");
        DataProcessor csvProcessor = new CsvDataProcessor();
        csvProcessor.ProcessData();

        Console.WriteLine("\nJSON Data Processing:");
        DataProcessor jsonProcessor = new JsonDataProcessor();
        jsonProcessor.ProcessData();
    }
}
