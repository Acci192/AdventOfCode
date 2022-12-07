using AoCHelpers;
using System.Drawing;
using System.IO;

namespace AoC2022.Solutions;

public class Day7 : ASolution
{
    public Day7(bool testInput) : base(testInput) { }

    public override string A()
    {
        var root = GetFileStructure(Input);

        var sum = 0;
        CountSmallDirectorySizes(root, ref sum );
        return sum.ToString();
    }

    public override string B()
    {
        var root = GetFileStructure(Input);

        var totalNeededDiskSpace = 70000000;
        var neededFreeDiskSpace = 30000000;

        var currentFreeSpace = totalNeededDiskSpace - root.GetTotalSize();
        var diskSpaceToBeDeleted = neededFreeDiskSpace - currentFreeSpace;

        var fileSizeToDelete = int.MaxValue;
        return CalculateB(root, fileSizeToDelete, diskSpaceToBeDeleted).ToString();
    }
    private int CalculateB(Directory directory, int fileSizeToDelete, int diskSpaceToBeDeleted)
    {
        var size = directory.GetTotalSize();

        if(size > diskSpaceToBeDeleted)
        {
            fileSizeToDelete = Math.Min(size, fileSizeToDelete);
        }
        foreach (var dir in directory.Directorys)
        {
            fileSizeToDelete = Math.Min(fileSizeToDelete, CalculateB(dir, fileSizeToDelete, diskSpaceToBeDeleted));
        }

        return fileSizeToDelete;
    }

    private void CountSmallDirectorySizes(Directory directory, ref int sum)
    {
        var size = directory.GetTotalSize();
        foreach(var dir in directory.Directorys)
        {
            CountSmallDirectorySizes(dir, ref sum);
        }

        if(size < 100000)
        {
            sum += size;
        }
    }

    private static Directory GetFileStructure(IEnumerable<string> input)
    {
        var root = new Directory("", null);
        var currentDirectory = root;

        foreach(var row in input)
        {
            var split = row.Split(' ');
            if (row[0] == '$')
            {
                if (split[1] == "cd")
                {
                    if (split[2] == "/")
                    {
                        currentDirectory = root;
                    }
                    else if (split[2] == "..")
                    {
                        currentDirectory = currentDirectory.Parent ?? throw new Exception();
                    }
                    else
                    {
                        currentDirectory = currentDirectory.Directorys.First(x => x.Name == split[2]);
                    }
                }
                continue;
            }

            if (row[0] == 'd')
            {
                currentDirectory.Directorys.Add(new Directory(split[1], currentDirectory));
            }
            else
            {
                currentDirectory.Files.Add(new File(int.Parse(split[0]), split[1]));
            }
        }

        return root;
    }
}

public class Directory
{
    public string Name { get; set; }
    public Directory? Parent { get; set; }

    public List<File> Files { get; } = new List<File>();
    public List<Directory> Directorys { get; } = new List<Directory>();

    public int GetTotalSize() => Files.Sum(x => x.Size) + Directorys.Sum(x => x.GetTotalSize());

    public Directory(string name, Directory? parent)
    {
        Name = name;
        Parent = parent;
    }
}

public class File
{
    public int Size { get; set; }
    public string Name { get; set; }

    public File(int size, string name)
    {
        Size = size;
        Name = name;
    }
}
