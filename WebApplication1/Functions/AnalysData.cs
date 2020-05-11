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

        public static Dictionary<string, int> DateOfCreationData()
        {
            Dictionary<string, int> dates = new Dictionary<string, int>();
            /*            string conString = "Data Source=LAPTOP-8TKAEMDT;Initial Catalog=SkinAllergyDB;Integrated Security=True";
            */
            string conString = "Data Source=skinallergic.database.windows.net;Initial Catalog=skinallergicDB;User ID=sobachka;Password=Glucka(2506);Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
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

        public static Dictionary<int, Dictionary<int, int>> ReadFromFile()
        {

            Dictionary<int, Dictionary<int, int>> allRegions = new Dictionary<int, Dictionary<int, int>>();
            Dictionary<int, int> regionsIncidence = new Dictionary<int, int>();
            string conString = "Data Source=skinallergic.database.windows.net;Initial Catalog=skinallergicDB;User ID=sobachka;Password=Glucka(2506);Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
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

    }
}
