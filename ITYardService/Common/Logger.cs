using System;
using System.Collections.Generic;
using System.Text;

namespace ITYardService.common
{
    class Logger
    {
        private const string info = "info";
        private const string error = "error";

        public static void LogInfo(string message)
        {
            Console.WriteLine($"Type {info}; \t message: {message}");
            LogInFile.LogInfo(message);
        }

        public static void LogError(string message)
        {
            Console.WriteLine($"Type {error}; \t message: {message}");
            LogInFile.LogError(message);
        }
    }
}
