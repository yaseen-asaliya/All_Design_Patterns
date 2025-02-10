/*
The Composite design pattern in C# is a structural pattern that allows you to treat individual objects and compositions of objects uniformly. 
It is particularly useful when dealing with tree structures, such as UI components, file systems, or organizational hierarchies.
*/

using System;
using System.Collections.Generic;

namespace CompositeDemo
{
    // Component (Abstract Base Class)
    public abstract class FileSystemComponent
    {
        protected string name;

        public FileSystemComponent(string name)
        {
            this.name = name;
        }

        public abstract void Display(int depth);
    }

    // Leaf (File)
    public class File : FileSystemComponent
    {
        public File(string name) : base(name) { }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " File: " + name);
        }
    }

    // Composite (Folder)
    public class Folder : FileSystemComponent
    {
        private List<FileSystemComponent> _children = new List<FileSystemComponent>();

        public Folder(string name) : base(name) { }

        public void Add(FileSystemComponent component)
        {
            _children.Add(component);
        }

        public void Remove(FileSystemComponent component)
        {
            _children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " Folder: " + name);
            foreach (var component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }

    // Main Program
    class Program
    {
        static void Main()
        {
            Folder root = new Folder("Root");
            File file1 = new File("File1.txt");
            File file2 = new File("File2.txt");

            Folder subFolder = new Folder("SubFolder");
            File file3 = new File("File3.txt");

            subFolder.Add(file3);
            root.Add(file1);
            root.Add(file2);
            root.Add(subFolder);

            root.Display(1);
        }
    }
}
