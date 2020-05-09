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
            /*            string conString = "Data Source=LAPTOP-8TKAEMDT;Initial Catalog=SkinAllergyDB;Integrated Security=True";
            */
            string conString = "Data Source=skinallergic.database.windows.net;Initial Catalog=skinallergicDB;User ID=sobachka;Password=Glucka(2506);Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string querystring = "Insert into Respondents(Name, Age, Gender, Disease, Region, DateOfCreation) values('" + person.Name + "','" + person.Age + "','" + person.Gender + "','" + person.Disease + "','" + person.Region + "','" + person.DateOfCreation + "')";
                SqlCommand cmd = new SqlCommand(querystring, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

    }
}
