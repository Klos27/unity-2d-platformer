using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

namespace Utils
{
    public class RegexValidator
    {
        static Regex m_emailRegex = CreateEmailRegex();
        static Regex m_passwordRegex = CreatePasswordRegex();

        private static Regex CreateEmailRegex()
        {
            string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(emailPattern, RegexOptions.IgnoreCase);
        }

        private static Regex CreatePasswordRegex()
        {
            // TODO PasswordRegex
            string passwordPattern = "TODO";

            return new Regex(passwordPattern);
        }

        internal static bool isEmailValid(string email)
        {
            return m_emailRegex.IsMatch(email);
        }

        internal static bool isPasswordValid(string password)
        {
            return m_passwordRegex.IsMatch(password);
        }
    }
}