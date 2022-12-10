using AoCHelpers;

namespace AoC2022.Solutions;

public class Day7 : ASolution
{
    public Day7(bool testInput) : base(testInput) { }

    public override string A()
    {
        var root = GetFileStructure(Input);
        return CountSmallDirectorySizes(root, 100000).ToString();
    }

    public override string B()
    {
        var root = GetFileStructure(Input);

        var totalNeededDiskSpace = 70000000;
        var neededFreeDiskSpace = 30000000;

        var currentFreeSpace = totalNeededDiskSpace - root.GetTotalSize();
        var diskSpaceToBeDeleted = neededFreeDiskSpace - currentFreeSpace;

        return FindSmallestDirectoryToDelete(root, diskSpaceToBeDeleted).ToString();
    }
    private int FindSmallestDirectoryToDelete(Directory directory, int diskSpaceToBeDeleted)
    {
        var size = directory.GetTotalSize();

        if(size < diskSpaceToBeDeleted)
        {
            return int.MaxValue;
        }

        if(directory.Directorys.Count == 0)
        {
            return size;
        }   

        var smallestSubDirectoryToDelete = directory.Directorys.Select(x => FindSmallestDirectoryToDelete(x, diskSpaceToBeDeleted)).Min();

        return Math.Min(size, smallestSubDirectoryToDelete);
    }

    private int CountSmallDirectorySizes(Directory directory, int smallSize)
    {
        return directory.GetTotalSize() <= smallSize
            ? directory.GetTotalSize() + directory.Directorys.Sum(x => CountSmallDirectorySizes(x, smallSize))
            : directory.Directorys.Sum(x => CountSmallDirectorySizes(x, smallSize));
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
