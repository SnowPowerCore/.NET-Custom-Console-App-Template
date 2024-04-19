using #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Services;

public class ConsoleService : IConsoleService
{
    public string? ReadLine() =>
        Console.ReadLine();

    public void PrintLine(string? text = null, ConsoleColor textColor = ConsoleColor.White)
    {
        if (textColor is not ConsoleColor.White)
            Console.ForegroundColor = textColor;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public void Print(string? text = null, ConsoleColor textColor = ConsoleColor.White)
    {
        if (textColor is not ConsoleColor.White)
            Console.ForegroundColor = textColor;
        Console.Write(text);
        Console.ResetColor();
    }

    public void New() =>
        Console.Clear();
}