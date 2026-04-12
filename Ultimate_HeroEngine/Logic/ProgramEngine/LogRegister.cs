namespace Ultimate_HeroEngine.Logic.ProgramEngine;

using System;
using System.Collections.Generic;
using System.IO;

public static class LogRegister
{
    public static List<String> ActionData { get; set; } = new List<String>();

    /// <summary>
    /// Appends a log message to the end of the 'BattleLogs.txt' file. 
    /// If the target directory or file does not exist at the specified path, they are created automatically.
    /// </summary>
    /// <param name="logMessage">The complete text message to be appended and registered in the file.</param>
    public static void RegisterLog(string logMessage)
    {
        string directoryPath = AppDomain.CurrentDomain.BaseDirectory;

        string filePath = Path.GetFullPath(Path.Combine(directoryPath, @"..\..\..\Files\BattleLogs.txt"));

        string? targetDirectory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(targetDirectory))
        {
            Directory.CreateDirectory(targetDirectory!);
        }
        string finalLine = $"{logMessage}\n";
        File.AppendAllText(filePath, finalLine);
    }

    /// <summary>
    /// Iterates through a list of text strings and inserts all of them, 
    /// one by one, into the log file.
    /// </summary>
    /// <param name="actionData">The list of text strings (action data) to be dumped into the file.</param>
    public static void InsertActionData(List<String> actionData)
    {
        actionData.ForEach(data => RegisterLog(data));
    }
}