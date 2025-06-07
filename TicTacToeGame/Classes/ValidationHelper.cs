using System.Text.RegularExpressions;

namespace TicTacToeGame.Classes
{
    public static class ValidationHelper
    {
        public class ValidationResult
        {
            public bool IsValid { get; set; }
            public string ErrorMessage { get; set; }

            public ValidationResult(bool isValid, string errorMessage = null)
            {
                IsValid = isValid;
                ErrorMessage = errorMessage;
            }
        }

        public static ValidationResult ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return new ValidationResult(false, "Имя пользователя не может быть пустым.");

            if (username.Length < 3)
                return new ValidationResult(false, "Имя пользователя должно содержать минимум 3 символа.");

            if (username.Length > 50)
                return new ValidationResult(false, "Имя пользователя не может быть длиннее 50 символов.");

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
                return new ValidationResult(false, "Имя пользователя может содержать только буквы, цифры и символ подчеркивания.");

            return new ValidationResult(true);
        }

        public static ValidationResult ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return new ValidationResult(false, "Email не может быть пустым.");

            if (email.Length > 100)
                return new ValidationResult(false, "Email не может быть длиннее 100 символов.");

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address != email)
                    return new ValidationResult(false, "Некорректный формат email.");
            }
            catch
            {
                return new ValidationResult(false, "Некорректный формат email.");
            }

            return new ValidationResult(true);
        }

        public static ValidationResult ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return new ValidationResult(false, "Пароль не может быть пустым.");

            if (password.Length < 6)
                return new ValidationResult(false, "Пароль должен содержать минимум 6 символов.");

            if (password.Length > 100)
                return new ValidationResult(false, "Пароль не может быть длиннее 100 символов.");

            if (!Regex.IsMatch(password, @"[A-Za-z]") || !Regex.IsMatch(password, @"[0-9]"))
                return new ValidationResult(false, "Пароль должен содержать как минимум одну букву и одну цифру.");

            return new ValidationResult(true);
        }

        public static ValidationResult ValidateIpAddress(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
                return new ValidationResult(false, "IP адрес не может быть пустым.");

            if (!Regex.IsMatch(ipAddress, @"^(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})$"))
                return new ValidationResult(false, "Некорректный формат IP адреса.");

            string[] parts = ipAddress.Split('.');
            foreach (string part in parts)
            {
                if (!int.TryParse(part, out int value) || value < 0 || value > 255)
                    return new ValidationResult(false, "Некорректный формат IP адреса. Каждая часть должна быть числом от 0 до 255.");
            }

            return new ValidationResult(true);
        }

        public static ValidationResult ValidatePort(int port)
        {
            if (port < 1024 || port > 65535)
                return new ValidationResult(false, "Порт должен быть числом от 1024 до 65535.");

            return new ValidationResult(true);
        }
    }
}
