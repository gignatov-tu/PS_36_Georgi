using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        public delegate void ActionOnError(string _errorMsg);
        private ActionOnError _actionOnError;
        private String _username;
        private String _password;
        private String _errorMsg;
        public LoginValidation(String username, String password, ActionOnError aoe)
        {
            _username = username;
            _password = password;
            _actionOnError = aoe;
        }
        public static UserRoles currentUserRole { private set; get; }
        public static string currentUserUsername { private set; get; }
        public bool ValidateUserInput(ref User newu)
        {
            currentUserRole = UserRoles.ANONYMOUS;

            Boolean emptyUsername;
            emptyUsername = _username.Equals(String.Empty);
            if (emptyUsername)
            {
                _errorMsg = "Не е посочено потребителско име!";
                _actionOnError(_errorMsg);
                return false;
            }
            Boolean emptyPassword;
            emptyPassword = _password.Equals(String.Empty);
            if (emptyPassword)
            {
                _errorMsg = "Не е посочена парола!";
                _actionOnError(_errorMsg);
                return false;
            }
            Boolean UsernameTooShort;
            UsernameTooShort = (_username.Length < 5);
            if (UsernameTooShort)
            {
                _errorMsg = "Потребителското име е твърде късо!";
                _actionOnError(_errorMsg);
                return false;
            }
            Boolean PasswordTooShort;
            PasswordTooShort = (_password.Length < 5);
            if (PasswordTooShort)
            {
                _errorMsg = "Паролата е твърде къса!";
                _actionOnError(_errorMsg);
                return false;
            }

            newu = UserData.IsUserPassCorrect(_username, _password);
            if (newu == null)
            {
                _errorMsg = "Грешно потребителско име или парола!";
                _actionOnError(_errorMsg);
                return false;
            }
            currentUserRole = (UserRoles)newu.Role;
            currentUserUsername = newu.Username;
            Logger.LogActivity("Успешен Login");
            return true;
        }
    }
}
