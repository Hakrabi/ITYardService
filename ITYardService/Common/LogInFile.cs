using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ITYardService.common
{
    class LogInFile 
    {
        private const string info = "info";
        private const string error = "error";

        private const string path = @"C:\ITYardService\log.txt";
        //private static StreamWriter sw = new StreamWriter(path,true);

        public  static void LogInfo(string message)
        {
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine($"Type {info}; \t message: {message}");
            sw.Close();
        }

        public static void LogError(string message)
        {
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine($"Type {error}; \t message: {message}");
            sw.Close();
        }
    }
}
