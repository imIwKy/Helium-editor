namespace Helium_editor;
class Program
{
    static void Main(string[] args)
    {
        if(args.Length > 0)
        {
            string filePath = args[0];

            //Try to read file make one if it doesnt exist.
            try
            {
                StreamReader file = new StreamReader(filePath);
                PrintFileContents(file);
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("The file does not exist, exiting..");
                Environment.Exit(2);
            }
        }
        else
        {
            Console.WriteLine("No file name was provided, exiting..");
            Environment.Exit(160);
        }
    }

    private static void PrintFileContents(StreamReader file)
    {
        string? str = file.ReadLine();

        Console.ForegroundColor = ConsoleColor.White;

        while(str != null)
        {
            Console.WriteLine(str);
            str = file.ReadLine();
        }
    }
}
