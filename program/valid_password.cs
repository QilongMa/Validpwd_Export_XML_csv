using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Console_Ado {
    static class Valid_password {
        public static ICollection<String> ErrorMessage { get; private set; }
        public static bool isValid(string userName, string email, string password) {
            bool flag = true;
            ErrorMessage = new List<string>();
            if (!CheckLen(password)) {
                flag = false;
                ErrorMessage.Add("Password less than 8 chars!");
            }
            if (!CheckUserNameToken(userName, password)) {
                flag = false;
                ErrorMessage.Add("Token in username should not appear in password!");
            }
            if (!CheckEmail(email, password)) {
                flag = false;
                ErrorMessage.Add("Cannot contain the local part or domain part of email address!");
            }
            if (!CheckComb(password)) {
                flag = false;
                ErrorMessage.Add("Password must contain 3 of 5 character sets!");
            }
            return flag;
        }

        private static bool CheckLen(string password) {
            return password.Length < 8 ? false : true;
        }

        private static bool CheckUserNameToken(string userName, string password) {
            char[] delimiters = new char[] { ',', '_', ' ', '\t', '-', '#', '.' };
            string[] parts = userName.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts) {
                if (part.Length >= 3 && password.ToLower().Contains(part.ToLower())) {
                    return false;
                }
            }
            return true;
        }

        private static bool CheckEmail(string email, string password) {
            string[] parts = email.Split('@');
            foreach (var part in parts) {
                if (password.ToLower().Contains(part.ToLower()))
                    return false;
            }
            return true;
        }

        private static bool CheckComb(string password) {
            int cnt = 0;
            char[] Punctuation = new char[] { '!', '\'', '?', '"', '-', ':', ',', ';', '(', ')', '[', ']', '{', '}' };
            char[] Symbol = new char[] { '~', '@', '#', '$', '%', '^', '&', '*', '+', '=', '|', '<', '>', '/', '\\' };
            if (password.Any(char.IsDigit)) cnt++;
            if (password.Any(char.IsUpper)) cnt++;
            if (password.Any(char.IsLower)) cnt++;
            if (password.Any(Punctuation.Contains)) cnt++;
            if (password.Any(Symbol.Contains)) cnt++;
            if (cnt >= 3) return true;
            return false;
        }
    }
}