using System;
using System.IO;
using System.Reflection;

namespace LibraryBooks.Utils
{
    public class Logger : ILogger
    {
        private readonly string _pathToFile;

        public Logger()
        {
            _pathToFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Log.txt");

            if (!File.Exists(_pathToFile))
            {
                File.WriteAllText(_pathToFile, "");
            }
        }

        public void Error(string message, Exception exception = null)
        {
            File.AppendAllText(_pathToFile, $"ERROR: {DateTime.Now} - {message} {exception}\n");
        }

        public void Info(string message)
        {
            File.AppendAllText(_pathToFile, $"INFO: {DateTime.Now} - {message}\n");
        }

        public void Warn(string message)
        {
            File.AppendAllText(_pathToFile, $"WARNING: {DateTime.Now} - {message}\n");
        }
    }

    public interface ILogger
    {
        void Info(string message);
        void Warn(string message);
        void Error(string message, Exception exception = null);
    }
}
