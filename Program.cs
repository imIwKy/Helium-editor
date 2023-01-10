namespace Helium_editor;
class Program
{
    static void Main(string[] args)
    {
        if(args.Length == 0)
        {
            Console.WriteLine("No file name or path was provided exiting...");
            Environment.Exit(160);
        }

        CheckFilePath(args[0]);

        StreamReader file = new StreamReader(args[0]);

        PrintFileContents(file);
    }

    private static void CheckFilePath(string path)
    {
        if(!File.Exists(path))
        {
            StreamWriter file = File.CreateText(path);
            file.Close();
        }
    }

    private static void PrintFileContents(StreamReader file)
    {
        Console.Clear();

        string? str = file.ReadLine();

        Console.ForegroundColor = ConsoleColor.White;

        while(str != null)
        {
            Console.WriteLine(str);
            str = file.ReadLine();
        }
    }
}
