using System;

namespace DataProcess {
    abstract class DataProcessor {
        // Template Method
        // here we have like a template (some methods are having implementation and other aren't), the methods that
        // doesn't having implementation it will take the implementation based on what has been written in subclass
        // Note that here the base class is the one takes the implementation from it's subclass (usually the other way around)
        public void ProcessData() 
        {
            LoadData();
            ParseData();
            SaveData();
        }

        // Common method (same across subclasses)
        protected void LoadData()
        {
            Console.WriteLine("Loading data...");
        }

        // Abstract methods (to be implemented by based on sub class)
        protected abstract void ParseData();

        // Common method (same across subclasses)
        protected void SaveData()
        {
            Console.WriteLine("Saving data...");
        }

        // Add your other methods here...
    }

    class CsvDataProcessor : DataProcessor
    {
        protected override void ParseData()
        {
            // Add custome implementation
            Console.WriteLine("Parsing CSV data...");
        }
    }


    class JsonDataProcessor : DataProcessor
    {
        protected override void ParseData()
        {
            // Add custome implementation
            Console.WriteLine("Parsing JSON data...");
        }
    }



}