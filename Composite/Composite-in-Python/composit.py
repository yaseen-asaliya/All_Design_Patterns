# The Composite design pattern in Python allows individual objects 
# and compositions of objects to be treated uniformly.
# It is useful for tree structures like UI components, file systems, or hierarchies.

class FileSystemComponent:
    """Component (Abstract Base Class)"""
    def __init__(self, name):
        self.name = name

    def display(self, depth):
        raise NotImplementedError("Subclass must implement abstract method")


class File(FileSystemComponent):
    """Leaf (File)"""
    def display(self, depth):
        print("-" * depth + f" File: {self.name}")


class Folder(FileSystemComponent):
    """Composite (Folder)"""
    def __init__(self, name):
        super().__init__(name)
        self._children = []

    def add(self, component):
        self._children.append(component)

    def remove(self, component):
        self._children.remove(component)

    def display(self, depth):
        print("-" * depth + f" Folder: {self.name}")
        for component in self._children:
            component.display(depth + 2)


# Main program
if __name__ == "__main__":
    root = Folder("Root")
    file1 = File("File1.txt")
    file2 = File("File2.txt")

    sub_folder = Folder("SubFolder")
    file3 = File("File3.txt")

    sub_folder.add(file3)
    root.add(file1)
    root.add(file2)
    root.add(sub_folder)

    root.display(1)
