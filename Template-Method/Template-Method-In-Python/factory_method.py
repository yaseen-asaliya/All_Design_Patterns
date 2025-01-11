from abc import ABC, abstractmethod

class DataProcessor(ABC):
    # Abstract Class defining the template method.
    
    def process_data(self):
        self.load_data()
        self.parse_data()
        self.save_data()
    
    def load_data(self):
        print("Loading data...")
    
    @abstractmethod
    def parse_data(self):
        pass  
    
    def save_data(self):
        print("Saving data...")


class CsvDataProcessor(DataProcessor):
    def parse_data(self):
        # Add custome implementation
        print("Parsing CSV data...")


class JsonDataProcessor(DataProcessor):
    def parse_data(self):
        # Add custome implementation
        print("Parsing JSON data...")


if __name__ == "__main__":
    print("CSV Data Processing:")
    csv_processor = CsvDataProcessor()
    csv_processor.process_data()
    
    print("\nJSON Data Processing:")
    json_processor = JsonDataProcessor()
    json_processor.process_data()
