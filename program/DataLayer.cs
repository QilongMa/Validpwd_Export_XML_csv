using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Console_Ado {
    class UserInfor {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Init_Password { get; set; }
        public string Role { get; set; }
        public string Reason_For_Access { get; set; }

        public List<UserInfor> GetUserList() {
            List<UserInfor> list = new List<UserInfor>();
            string CS = ConfigurationManager.ConnectionStrings["qualify"].ConnectionString;
            string cmd = "SELECT Name, Email, Init_Password, Role, Reason_For_Access FROM dbo.Tb_Batch_Item";
            using (var connection = new SqlConnection(CS)) {
                var command = new SqlCommand(cmd, connection);
                connection.Open();
                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        list.Add(new UserInfor {
                            UserName = reader[0].ToString(),
                            Email = reader[1].ToString(),
                            Init_Password = reader[2].ToString(),
                            Role = reader[3].ToString(),
                            Reason_For_Access = reader[4].ToString()
                        });
                    }
                }
                connection.Close();
            }
            return list;
        }
    }
}