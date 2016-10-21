using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Console_Ado {
    static class Generator {
        public static string generate(string userName, string email) {
            const string allowedChars =
                "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz~@#$%^&*+=|<>/\\!’?”-:,;()[]{}";
            int len1 = allowedChars.Length;
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            int len2 = rnd.Next(8, 20);
            for (int i = 0; i < len2; i++) {
                int idx = rnd.Next(len1);
                sb.Append(allowedChars[idx]);
            }
            string res = sb.ToString();
            return Valid_password.isValid(userName, email, res) ? res : generate(userName, email);
        }
    }
}