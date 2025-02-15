using System;
using System.Collections.Generic;
/* 
The Visitor Pattern is a behavioral design pattern used to separate algorithms from the objects on which they operate. 
It allows adding new operations to existing object structures without modifying their classes. 
*/
namespace VisitorDemo
{
    // Visitor Interface
    public interface IFileVisitor
    {
        void Visit(TextFile file);
        void Visit(ImageFile file);
        void Visit(AudioFile file);
    }

    // Concrete Visitor: Compression
    public class FileCompressionVisitor : IFileVisitor
    {
        public void Visit(TextFile file)
        {
            Console.WriteLine($"Compressing text file: {file.FileName}");
        }

        public void Visit(ImageFile file)
        {
            Console.WriteLine($"Compressing image file: {file.FileName}");
        }

        public void Visit(AudioFile file)
        {
            Console.WriteLine($"Compressing audio file: {file.FileName}");
        }
    }
    
    // Element Interface
    public interface IFileElement
    {
        void Accept(IFileVisitor visitor);
    }

    // Concrete Elements: Different File Types
    public class TextFile : IFileElement
    {
        public string FileName { get; }

        public TextFile(string fileName)
        {
            FileName = fileName;
        }

        public void Accept(IFileVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ImageFile : IFileElement
    {
        public string FileName { get; }

        public ImageFile(string fileName)
        {
            FileName = fileName;
        }

        public void Accept(IFileVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class AudioFile : IFileElement
    {
        public string FileName { get; }

        public AudioFile(string fileName)
        {
            FileName = fileName;
        }

        public void Accept(IFileVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Object Structure: File System
    public class FileSystem
    {
        private List<IFileElement> files = new List<IFileElement>();

        public void AddFile(IFileElement file)
        {
            files.Add(file);
        }

        public void ApplyVisitor(IFileVisitor visitor)
        {
            foreach (var file in files)
            {
                file.Accept(visitor);
            }
        }
    }

    // Main Program
    class Program
    {
        static void Main()
        {
            // Create a file system
            FileSystem fileSystem = new FileSystem();
            fileSystem.AddFile(new TextFile("document.txt"));
            fileSystem.AddFile(new ImageFile("photo.jpg"));
            fileSystem.AddFile(new AudioFile("song.mp3"));

            // Create visitors
            IFileVisitor compressionVisitor = new FileCompressionVisitor();

            // Apply visitors
            Console.WriteLine("Applying Compression Visitor:");
            fileSystem.ApplyVisitor(compressionVisitor);
        }
    }
}
