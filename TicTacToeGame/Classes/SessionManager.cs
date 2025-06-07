using System.Collections.Concurrent;
using TicTacToeGame.Model;

namespace TicTacToeGame.Classes
{
    public static class SessionManager
    {
        private static readonly ConcurrentDictionary<int, SessionInfo> _activeSessions = new();
        private static readonly object _lock = new object();
        private const int SessionTimeoutMinutes = 30;

        public class SessionInfo
        {
            public int UserId { get; set; }
            public string Username { get; set; }
            public DateTime LastActivity { get; set; }
            public string IpAddress { get; set; }
        }

        public static bool IsUserLoggedIn(int userId)
        {
            lock (_lock)
            {
                CleanupExpiredSessions();
                return _activeSessions.ContainsKey(userId);
            }
        }

        public static bool IsUserActive(int userId)
        {
            lock (_lock)
            {
                CleanupExpiredSessions();
                return _activeSessions.ContainsKey(userId);
            }
        }

        public static bool IsUsernameActive(string username)
        {
            lock (_lock)
            {
                CleanupExpiredSessions();
                return _activeSessions.Values.Any(s => s.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            }
        }

        public static bool TryLoginUser(User user)
        {
            lock (_lock)
            {
                if (_activeSessions.ContainsKey(user.Id))
                {
                    Logger.LogWarning($"Попытка входа заблокирована: Пользователь {user.Name} (ID: {user.Id}) уже вошел в систему");
                    return false;
                }

                RegisterSession(user, "localhost");
                return true;
            }
        }

        public static void RegisterSession(User user, string ipAddress)
        {
            lock (_lock)
            {
                CleanupExpiredSessions();

                if (_activeSessions.ContainsKey(user.Id))
                {
                    _activeSessions[user.Id].LastActivity = DateTime.Now;
                    _activeSessions[user.Id].IpAddress = ipAddress;
                    Logger.LogInfo($"Обновлена сессия пользователя: {user.Name} (ID: {user.Id})");
                }
                else
                {
                    _activeSessions[user.Id] = new SessionInfo
                    {
                        UserId = user.Id,
                        Username = user.Name,
                        LastActivity = DateTime.Now,
                        IpAddress = ipAddress
                    };
                    Logger.LogInfo($"Зарегистрирована новая сессия пользователя: {user.Name} (ID: {user.Id})");
                }
            }
        }

        public static void LogoutUser(int userId)
        {
            lock (_lock)
            {
                if (_activeSessions.TryRemove(userId, out var session))
                {
                    Logger.LogInfo($"Сессия пользователя завершена: {session.Username} (ID: {userId})");
                }
            }
        }

        public static void UpdateActivity(int userId)
        {
            lock (_lock)
            {
                if (_activeSessions.ContainsKey(userId))
                {
                    _activeSessions[userId].LastActivity = DateTime.Now;
                }
            }
        }

        public static List<SessionInfo> GetActiveSessions()
        {
            lock (_lock)
            {
                CleanupExpiredSessions();
                return _activeSessions.Values.ToList();
            }
        }

        public static void CleanupExpiredSessions(TimeSpan sessionTimeout)
        {
            lock (_lock)
            {
                var expiredSessions = _activeSessions
                    .Where(kvp => DateTime.Now - kvp.Value.LastActivity > sessionTimeout)
                    .Select(kvp => kvp.Key)
                    .ToList();

                foreach (var userId in expiredSessions)
                {
                    if (_activeSessions.TryRemove(userId, out var session))
                    {
                        Logger.LogInfo($"Истекшая сессия удалена: {session.Username} (ID: {userId})");
                    }
                }
            }
        }

        private static void CleanupExpiredSessions()
        {
            CleanupExpiredSessions(TimeSpan.FromMinutes(SessionTimeoutMinutes));
        }

        public static int GetActiveSessionsCount()
        {
            return _activeSessions.Count;
        }
    }
}
