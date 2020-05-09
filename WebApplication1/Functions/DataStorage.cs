using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Odbc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Data.SqlClient;

namespace Functions
{
    class Region
    {
        public string name { get; set; }
        public string identity { get; set; }
        public Region(string Identity, string Name)
        {
            this.identity = Identity;
            this.name = Name;
        }
    }
    public class DataStorage
    {

        public static Random rnd = new Random();
        private DataTable table;

        public static void WriteRegionsToFile()
        {



            OdbcConnection con = new OdbcConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Users\\Gaya\\Programming\\Kursach\\WebApplication1\\DD.mdb");
            

           
          /*  OdbcConnection con = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb)};"
           + @"Dbq=C:\Users\Gaya\Programming\Kursach\WebApplication1\DD.mdb;Uid=Admin;Pwd=;");*/
            //Replaced Parameters with Value
            string query = "INSERT INTO Regions (Identity, Region_name) VALUES(?, ?)";
            OdbcCommand cmd = new OdbcCommand(query, con);

  /*          //Pass values to Parameters
            for (int i = 0; i < regionNames.names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@Identity", regionNames.names[i].num);
                cmd.Parameters.AddWithValue("@Region_name", regionNames.names[i].name);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }*/

        }



        public static void SaveInfoToFile(User person)
        {
            string conString = "Data Source=LAPTOP-8TKAEMDT;Initial Catalog=SkinAllergyDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string querystring = "Insert into Respondents(Id, Name, Age, Gender, Disease, Region, DateOfCreation) values('" + 1 + "','" + person.Name + "','" + person.Age + "','" + person.Gender + "','" + person.Disease + "','" + person.Region + "','" + person.DateOfCreation + "')";
                SqlCommand cmd = new SqlCommand(querystring, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        public static void FullTable()
        {
            /*Dictionary<int, string> openWith = new Dictionary<int, string>();


            openWith.Add(0, "Covid-19");
            openWith.Add(1, "Allergy");
            openWith.Add(2, "Angina");*/
            for (int i = 0; i < 1000; i++)
            {
/*                openWith.TryGetValue(rnd.Next(0, 3), out value);
*/                User person = new User(GenerateName(), rnd.Next(1, 120).ToString(), rnd.Next(0, 2) == 0 ? "male" : "female", "77", rnd.Next(1, 4).ToString());
                SaveInfoToFile(person);
            }
        }

        public static void ClearTable()
        {
            OdbcConnection con = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb)};"
            + @"Dbq=C:\Users\Gaya\Programming\Kursach\WebApplication1\DD.mdb;Uid=Admin;Pwd=;");
            string querystring = "DELETE FROM Table1";
            con.Open();
            OdbcCommand cmd = new OdbcCommand(querystring, con);
            con.Close();

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        private static string GenerateName()
        {
            int length = rnd.Next(2, 14);
            StringBuilder s = new StringBuilder();
            s.Append((char)rnd.Next('A', 'Z' + 1));
            for (int i = 0; i < length - 1; i++)
            {
                s.Append((char)rnd.Next('a', 'z' + 1));
            }
            return s.ToString();
        }
 /*       public DataStorage()
        {
            DataTable table = new DataTable();
            DataColumn column;
            column = new DataColumn();
            column.ColumnName = "Name";
            table.Columns.Add(column);
            column = new DataColumn();
            column.ColumnName = "Age";
            table.Columns.Add(column); column = new DataColumn();
            column.ColumnName = "Gender";
            table.Columns.Add(column); column = new DataColumn();
            column.ColumnName = "Disease";
            table.Columns.Add(column);
            this.table = table;
        }

        private void AddInfo(User person)
        {
            table.Rows.Add(person.Name, person.Age, person.Gender, person.Disease);
        }*/

    }
}
