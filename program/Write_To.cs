using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace Console_Ado {
    class Write_To {
        private string CSVFormat(string s) {
            // CSV rules: http://en.wikipedia.org/wiki/Comma-separated_values#Basic_rules
            // From the rules:
            // 1. if the data has quote, escape the quote in the data
            // 2. if the data contains the delimiter (in our case ','), double-quote it
            // 3. if the data contains the new-line, double-quote it.

            if (s.Contains('"')) {
                s = s.Replace("\"", "\"\"");
            }

            if (s.Contains(",")) {
                s = String.Format("\"{0}\"", s);
            }

            if (s.Contains(System.Environment.NewLine)) {
                s = String.Format("\"{0}\"", s);
            }
            return s;
        }

        public void wirteCSV(List<UserInfor> list) {
            var csv = new StringBuilder();
            csv.AppendLine("Name,Email,Init_Password,Role,Reason_For_Access");

            foreach(var item in list) {                
                csv.AppendLine(CSVFormat(item.UserName) + ',' + CSVFormat(item.Email) + ',' + CSVFormat(item.Init_Password) + ',' + CSVFormat(item.Role) + ',' + CSVFormat(item.Reason_For_Access));
            }

            File.WriteAllText("./User.csv", csv.ToString(), Encoding.UTF8);
        }
        
        public void writexml(List<UserInfor> list) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;
            using(XmlWriter writer = XmlWriter.Create("./User.xml", settings)) {
                writer.WriteStartDocument();
                writer.WriteStartElement("AllUserInfor");
                foreach(var item in list) {
                    writer.WriteStartElement("User");
                    writer.WriteElementString("Name", item.UserName.ToString());
                    writer.WriteElementString("Email", item.Email.ToString());
                    writer.WriteElementString("Init_Password", item.Init_Password.ToString());
                    writer.WriteElementString("Role", item.Role.ToString());
                    writer.WriteElementString("Reason_For_Access", item.Reason_For_Access.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}