﻿namespace #{PROJECT_DEFAULT_NAMESPACE};

public interface IConsoleService
{
    string? ReadLine();

    void PrintLine(string? text = null, ConsoleColor textColor = ConsoleColor.White);

    void Print(string? text = null, ConsoleColor textColor = ConsoleColor.White);

    void New();
}