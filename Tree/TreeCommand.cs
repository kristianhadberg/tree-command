
internal class TreeCommand
{
    public static void Main(string[] args)
    {
        string directory;

        if (args.Length > 0)
        {
            directory = args[0];
        }
        else
        {
            directory = Directory.GetCurrentDirectory();
        }

        if (!Directory.Exists(directory))
        {
            Console.WriteLine($"The directory: '{directory}' does not exist.");
            return;
        }
         
        IterateThroughDirectory(directory, new List<bool>());
    }

    private static void IterateThroughDirectory(string directory, List<bool> parentDirectoriesHasMoreItems, int depth = 0)
    {
        var prefix = GetPrefix(depth, parentDirectoriesHasMoreItems);
        var directories = Directory.GetDirectories(directory);
        var files = Directory.GetFiles(directory);
        
        for (int i = 0; i < directories.Length; i++)
        {
            var isLastItem = i == directories.Length - 1 && files.Length == 0;
            var containsFiles = files.Length > 0;
            var currentDir = directories[i];

            parentDirectoriesHasMoreItems.Add(!isLastItem);

            PrintDirectotry(currentDir, prefix, isLastItem, containsFiles);
            
            IterateThroughDirectory(currentDir, parentDirectoriesHasMoreItems, depth + 1);
            parentDirectoriesHasMoreItems.RemoveAt(parentDirectoriesHasMoreItems.Count - 1);
        }
        
        for (int i = 0; i < files.Length; i++)
        {
            var isLastFile = i == files.Length - 1;
            PrintFile(files[i], prefix, isLastFile);
        }
    }

    private static string GetPrefix(int depth, List<bool> parentDirectoryHasMoreItems)
    {
        var prefix = "";
        for (int i = 0; i < depth; i++)
        {
            if (parentDirectoryHasMoreItems.Count > 0)
            {
                if (parentDirectoryHasMoreItems[i])
                {
                    prefix += "\u2502";
                }
            }
            prefix += "\t";
        }
        
        return prefix;
    }

    private static void PrintDirectotry(string directory, string prefix, bool isLastItem, bool containsFiles)
    {
        var prefixString = $"{prefix}{(isLastItem && !containsFiles ? "\u2514" : "\u251c")}";
        prefixString += "\u2500";
        
        Console.Write(prefixString);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"{TrimString(directory)}");
        Console.ResetColor();
    }

    private static void PrintFile(string file, string prefix, bool isLastFile)
    {
        var prefixString = $"{prefix}{(isLastFile ? "\u2514" : "\u251c")}";
        prefixString += "\u2500";
        
        Console.WriteLine($"{prefixString}{TrimString(file)}");
    }
    
    private static string TrimString(string str)
    {
        var lastIndexOfSlash = str.LastIndexOf("/");
        return str.Substring(lastIndexOfSlash + 1); // +1 to remove slash as well
    }
}