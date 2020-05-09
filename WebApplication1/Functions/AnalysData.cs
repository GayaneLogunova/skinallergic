using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;


namespace Functions
{
    public class AnalysData
    {

        /*        public static List<User> ReadFromFile()
                {
                    var users = new List<User>();
                    OdbcConnection con = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb)};"
                    + @"Dbq=C:\Users\Gaya\Programming\Kursach\WebApplication1\DD.mdb;Uid=Admin;Pwd=;");
                    string querystring = "Select * from Table1";
                    con.Open();
                    OdbcCommand cmd = new OdbcCommand(querystring, con);
                    OdbcDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(new User(reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[6].ToString(), reader[4].ToString()));
                    }
                    con.Close();
                    return users;
                }*/

        /*        public static Dictionary<int, int> ReadFromFile(string disease)
                {
                    int num = 0;
                    Dictionary<int, int> regionsIncidence = new Dictionary<int, int>();
                    for (int i = 1; i < 92; i++)
                    {
                        OdbcConnection con = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb)};"
                        + @"Dbq=C:\Users\Gaya\Programming\Kursach\WebApplication1\DD.mdb;Uid=Admin;Pwd=;");
                        *//*                string querystring = "SELECT Count(*) FROM Table1 WHERE Region = ?";
                        *//*
                        string querystring = "SELECT Count(*) From Table1 WHERE (Disease = ? AND Region = ?)";
                        con.Open();
                        OdbcCommand cmd = new OdbcCommand(querystring, con);
                        cmd.Parameters.AddWithValue("@Disease", disease);
                        cmd.Parameters.AddWithValue("@Region", i);
        *//*                cmd.Parameters.AddWithValue("@Region", i);
        *//*                OdbcDataReader Reader = cmd.ExecuteReader();
                        while (Reader.Read())
                        {
                            num = Reader.GetInt32(0);
                            Trace.WriteLine(num);
                        }

                        Reader.Close();
                        con.Close();
                        regionsIncidence.Add(i, num);
                    }
                    return regionsIncidence;
                }
        */



        public static Dictionary<string, int> DateOfCreationData()
        {
            Dictionary<string, int> dates = new Dictionary<string, int>();
            string conSting = "Data Source=LAPTOP-8TKAEMDT;Initial Catalog=SkinAllergyDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conSting);
            string querystring = "Select Day(DateOfCreation), YEAR(DateOfCreation), count(*) From Respondents Group By Day(DateOfCreation), Year(DateOfCreation) Order By Day(DateOfCreation), Year(DateOfCreation)";
            con.Open();
            SqlCommand cmd = new SqlCommand(querystring, con);
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                dates.Add(Reader.GetInt32(0).ToString() + "." + Reader.GetInt32(1).ToString(), Reader.GetInt32(2));
            }
            Reader.Close();
            con.Close();
            return dates;
        }

        /*        public static Dictionary<string, int> DateOfCreationData()
                {
                    Dictionary<string, int> dates = new Dictionary<string, int>();
                    *//*  OdbcConnection con = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb)};"
                      + @"Dbq=C:\Users\Gaya\Programming\Kursach\WebApplication1\DD.mdb;Uid=Admin;Pwd=;");*//*


                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-8TKAEMDT;Initial Catalog=SkinAllergyDB;Integrated Security=True");
                    string querystring = "Select Month(DateOfCreation) As[Month], Year(DateOfCreation), count(*) From Respondents Group By Month(DateOfCreation), Year(DateOfCreation) Order By Month(DateOfCreation), Year(DateOfCreation)";

                    *//*            string querystring = "Select Month(DateOfCreation) As[Month], Year(DateOfCreation), count(*) From Table1 Group By Month(DateOfCreation), Year(DateOfCreation) Order By Month(DateOfCreation), Year(DateOfCreation)";
                    *//*            string querystring = " Select Month(DateOfCreation), count(*) From Table1 Group By Month(DateOfCreation)";
                    *//*
                    con.Open();
                    SqlCommand cmd = new SqlCommand(querystring, con);
            *//*        OdbcCommand cmd = new OdbcCommand(querystring, con);
                    OdbcDataReader Reader = cmd.ExecuteReader();*//*
                    while (Reader.Read())
                    {
                        dates.Add(Reader.GetInt32(0).ToString() + "." + Reader.GetInt32(1).ToString(), Reader.GetInt32(2));
                    }
        *//*            while (Reader.Read())
                    {
                        dates.Add(Reader.GetInt32(0).ToString(), Reader.GetInt32(1));
                    }*//*
                    Reader.Close();
                    con.Close();
                    return dates;
                }*/


        public static Dictionary<int, Dictionary<int, int>> ReadFromFile()
        {

            Dictionary<int, Dictionary<int, int>> allRegions = new Dictionary<int, Dictionary<int, int>>();
            Dictionary<int, int> regionsIncidence = new Dictionary<int, int>();
            string conSting = "Data Source=LAPTOP-8TKAEMDT;Initial Catalog=SkinAllergyDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conSting);
            string querystring = "Select Disease, Count(Disease), Region From Respondents GROUP BY Disease, Region ORDER BY Disease";
            con.Open();
            SqlCommand cmd = new SqlCommand(querystring, con);
            SqlDataReader Reader = cmd.ExecuteReader();
            int disease = 0;
            while (Reader.Read())
            {
                if (disease == 0)
                {
                    disease = Reader.GetInt32(0);
                }
                if (Reader.GetInt32(0) != disease && disease != 0)
                {
                    allRegions.Add(disease, regionsIncidence);
                    disease = Reader.GetInt32(0);
                    regionsIncidence = new Dictionary<int, int>();
                }
                regionsIncidence.Add(Reader.GetInt32(2), Reader.GetInt32(1));
            }
            allRegions.Add(disease, regionsIncidence);
            Reader.Close();
            con.Close();
            return allRegions;
        }


        /* public static Dictionary<int, Dictionary<int, int>> ReadFromFile()
         {
             Dictionary<int, Dictionary<int, int>> allRegions = new Dictionary<int, Dictionary<int, int>>();
             Dictionary<int, int> regionsIncidence = new Dictionary<int, int>();

             OdbcConnection con = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb)};"
             + @"Dbq=C:\Users\Gaya\Programming\Kursach\WebApplication1\DD.mdb;Uid=Admin;Pwd=;");
             string querystring = "SELECT DISTINCTROW Table1.Disease, Table1.Region, Sum(1) FROM Table1 GROUP BY Table1.Disease, Table1.Region ORDER BY Disease";
             con.Open();
             OdbcCommand cmd = new OdbcCommand(querystring, con);
             OdbcDataReader Reader = cmd.ExecuteReader();
             int disease = 0;
             while (Reader.Read())
             {
                 if (disease == 0)
                 {
                     disease = Reader.GetInt32(0);
                 }
                 if (Reader.GetInt32(0) != disease && disease != 0)
                 {
                     allRegions.Add(disease, regionsIncidence);
                     disease = Reader.GetInt32(0);
                     regionsIncidence = new Dictionary<int, int>();
                 }
                 regionsIncidence.Add(Reader.GetInt32(1), Reader.GetInt32(2));
             }
             allRegions.Add(disease, regionsIncidence);
             Reader.Close();
             con.Close();
             return allRegions;
         }
     }*/
    }
}
