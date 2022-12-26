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
            // Path to the project folder
            _pathToFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Log.txt");

            if (!File.Exists(_pathToFile))
            {
                // INFO: Создание файла: Create() - требует Dispose(), а WriteAllText() его уже содержет
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

    public interface ILogger  // For dependency injection
    {
        void Info(string message);
        void Warn(string message);
        void Error(string message, Exception exception = null);
    }
}
