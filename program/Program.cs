using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Console_Ado {
    public class Console_Ado {
        static void Main() {
            UserInfor users = new UserInfor();
            List<UserInfor> list = users.GetUserList();
            foreach (var user in list) {
                if (Valid_password.isValid(user.UserName, user.Email, user.Init_Password)) {
                    Console.WriteLine("{0} has a valid password", user.UserName);
                }
                else {
                    foreach (var err in Valid_password.ErrorMessage) {
                        Console.WriteLine(err);
                    }
                    Valid_password.ErrorMessage.Clear();
                    string newpass = Generator.generate(user.UserName, user.Email);
                    Console.WriteLine("New password is " + newpass);
                }
            }

            Write_To helper = new Write_To();
            helper.wirteCSV(list);
            helper.writexml(list);
        }
    }
}