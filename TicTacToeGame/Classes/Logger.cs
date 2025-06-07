namespace TicTacToeGame.Classes
{
    public static class Logger
    {
        private static readonly string LogFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "TicTacToeGame",
            "logs",
            $"game_log_{DateTime.Now:yyyy-MM-dd}.txt"
        );

        static Logger()
        {
            var logDirectory = Path.GetDirectoryName(LogFilePath);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
        }

        public static void LogInfo(string message)
        {
            WriteLog("ИНФО", message);
        }

        public static void LogWarning(string message)
        {
            WriteLog("ПРЕДУПРЕЖДЕНИЕ", message);
        }

        public static void LogError(string message)
        {
            WriteLog("ОШИБКА", message);
        }

        public static void LogError(string message, Exception ex)
        {
            WriteLog("ОШИБКА", $"{message} | Исключение: {ex.Message} | Стек вызовов: {ex.StackTrace}");
        }

        public static void LogDebug(string message)
        {
            WriteLog("ОТЛАДКА", message);
        }

        private static void WriteLog(string level, string message)
        {
            try
            {
                var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";

                File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);

                Console.WriteLine(logEntry);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось записать лог: {ex.Message}");
                Console.WriteLine($"Исходный лог: [{level}] {message}");
            }
        }

        public static void ClearOldLogs(int daysToKeep = 7)
        {
            try
            {
                var logDirectory = Path.GetDirectoryName(LogFilePath);
                if (Directory.Exists(logDirectory))
                {
                    var files = Directory.GetFiles(logDirectory, "game_log_*.txt");
                    var cutoffDate = DateTime.Now.AddDays(-daysToKeep);

                    foreach (var file in files)
                    {
                        var fileInfo = new FileInfo(file);
                        if (fileInfo.CreationTime < cutoffDate)
                        {
                            File.Delete(file);
                            LogInfo($"Удален старый файл лога: {Path.GetFileName(file)}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError("Не удалось очистить старые логи", ex);
            }
        }
    }
}
