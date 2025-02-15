"""
The Visitor Pattern is a behavioral design pattern used to separate algorithms from the objects on which they operate. 
It allows adding new operations to existing object structures without modifying their classes. 
"""

# Visitor Interface
class IFileVisitor:
    def visit_text_file(self, file):
        pass

    def visit_image_file(self, file):
        pass

    def visit_audio_file(self, file):
        pass


# Concrete Visitor: Compression
class FileCompressionVisitor(IFileVisitor):
    def visit_text_file(self, file):
        print(f"Compressing text file: {file.file_name}")

    def visit_image_file(self, file):
        print(f"Compressing image file: {file.file_name}")

    def visit_audio_file(self, file):
        print(f"Compressing audio file: {file.file_name}")


# Element Interface
class IFileElement:
    def accept(self, visitor):
        pass


# Concrete Elements: Different File Types
class TextFile(IFileElement):
    def __init__(self, file_name):
        self.file_name = file_name

    def accept(self, visitor):
        visitor.visit_text_file(self)


class ImageFile(IFileElement):
    def __init__(self, file_name):
        self.file_name = file_name

    def accept(self, visitor):
        visitor.visit_image_file(self)


class AudioFile(IFileElement):
    def __init__(self, file_name):
        self.file_name = file_name

    def accept(self, visitor):
        visitor.visit_audio_file(self)


# Object Structure: File System
class FileSystem:
    def __init__(self):
        self.files = []

    def add_file(self, file):
        self.files.append(file)

    def apply_visitor(self, visitor):
        for file in self.files:
            file.accept(visitor)


# Main Program
if __name__ == "__main__":
    # Create a file system
    file_system = FileSystem()
    file_system.add_file(TextFile("document.txt"))
    file_system.add_file(ImageFile("photo.jpg"))
    file_system.add_file(AudioFile("song.mp3"))

    # Create visitor
    compression_visitor = FileCompressionVisitor()

    # Apply visitor
    print("Applying Compression Visitor:")
    file_system.apply_visitor(compression_visitor)
