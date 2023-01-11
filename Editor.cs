namespace Helium_editor;
class Editor
{
    private static List<string> page = new List<string>();

    static void Main(string[] args)
    {
        if(args.Length == 0)
        {
            Console.WriteLine("No file name or path was provided exiting...");
            Environment.Exit(160);
        }

        string filePath = args[0];

        CheckFilePath(filePath);

        StreamReader file = new StreamReader(filePath);
        LoadFileContents(file);
        file.Close();

        Edit();
        
    }

    private static void CheckFilePath(string path)
    {
        if(!File.Exists(path))
        {
            StreamWriter file = File.CreateText(path);
            file.Close();
        }
    }

    private static void LoadFileContents(StreamReader file)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;

        string? line = file.ReadLine();

        while(line != null)
        {
            page.Add(line);
            Console.WriteLine(line);
            line = file.ReadLine();
        }

        file.Close();
    }

    private static void Edit()
    {
        ConsoleKeyInfo cki;

        Console.SetCursorPosition(0, 0);

        (int cursorX, int cursorY) = Console.GetCursorPosition();

        do
        {
            cki = Console.ReadKey(true);

            switch(cki.Key)
            {
                case ConsoleKey.LeftArrow:
                    if(cursorX == 0 && cursorY > 0)
                    {
                        cursorX = page[cursorY - 1].Length;
                        cursorY -= 1;
                        Console.SetCursorPosition(cursorX, cursorY);
                    }
                    else if(cursorX > 0)
                    {
                        cursorX -= 1; 
                        Console.SetCursorPosition(cursorX, cursorY);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if(cursorX == page[cursorY].Length && cursorY < page.Count - 1)
                    {
                        cursorX = page[cursorY + 1].Length;
                        cursorY += 1;
                        Console.SetCursorPosition(cursorX, cursorY);
                    }
                    else if(cursorX < page[cursorY].Length)
                    {
                        cursorX += 1; 
                        Console.SetCursorPosition(cursorX, cursorY);
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if(cursorY == 0) {break;}
                    else 
                    {
                        cursorY -= 1; 
                        cursorX = page[cursorY].Length; 
                        Console.SetCursorPosition(cursorX, cursorY);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if(cursorY == page.Count - 1) {break;}
                    else 
                    {
                        cursorY += 1; 
                        cursorX = page[cursorY].Length; 
                        Console.SetCursorPosition(cursorX, cursorY);
                    }
                    break;
            }
        } 
        while(cki.Key != ConsoleKey.Escape);
    }
}
