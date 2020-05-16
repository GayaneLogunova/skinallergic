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

        public static Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, int>>>> FullData()
        {
            Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, int>>>> groupedByDisease = new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, int>>>>();
            Dictionary<string, Dictionary<string, Dictionary<string, int>>> groupedByRegion = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
            Dictionary<string, Dictionary<string, int>> groupedByStage = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> groupedByDuration = new Dictionary<string, int>();
            string conString = "Data Source=skinallergic.database.windows.net;Initial Catalog=skinallergicDB;User ID=sobachka;Password=Glucka(2506);Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string querystring = "Select COUNT(DurationOfIlness), DurationOfIlness, Stage, Region, Disease From Respondents GROUP BY Disease, Region, Stage, DurationOfIlness Order by Disease, Region, Stage, DurationOfIlness";
            con.Open();
            SqlCommand cmd = new SqlCommand(querystring, con);
            SqlDataReader Reader = cmd.ExecuteReader();
            int disease = 0, region = 0, stage = 0;
            while (Reader.Read())
            {
                if (disease == 0)
                {
                    disease = Reader.GetInt32(4);
                    region = Reader.GetInt32(3);
                    stage = Reader.GetInt32(2);
                }
                if (stage != Reader.GetInt32(2))
                {
                    groupedByStage.Add(stage.ToString(), groupedByDuration);
                    stage = Reader.GetInt32(2);
                    groupedByDuration = new Dictionary<string, int>();
                }
                if (region != Reader.GetInt32(3))
                {
                    if (groupedByStage.Count == 0)
                    {
                        groupedByStage.Add(stage.ToString(), groupedByDuration);
                        groupedByDuration = new Dictionary<string, int>();
                    }
                    groupedByRegion.Add(region.ToString(), groupedByStage);
                    region = Reader.GetInt32(3);
                    groupedByStage = new Dictionary<string, Dictionary<string, int>>();
                }
                if (disease != Reader.GetInt32(4))
                {
                    if (groupedByRegion.Count == 0)
                    {
                        if (groupedByStage.Count == 0)
                        {
                            groupedByStage.Add(stage.ToString(), groupedByDuration);
                            groupedByDuration = new Dictionary<string, int>();
                        }
                        groupedByRegion.Add(region.ToString(), groupedByStage);
                        groupedByStage = new Dictionary<string, Dictionary<string, int>>();
                    }
                    groupedByDisease.Add(disease.ToString(), groupedByRegion);
                    disease = Reader.GetInt32(4);
                    groupedByRegion = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
                }
                if (Reader.GetInt32(1) == 1)
                    groupedByDuration.Add(1.ToString(), Reader.GetInt32(0));
                else if (Reader.GetInt32(1) <= 5)
                {
                    if (groupedByDuration.ContainsKey(2.ToString()))
                        groupedByDuration[2.ToString()] += Reader.GetInt32(0);
                    else
                        groupedByDuration.Add(2.ToString(), Reader.GetInt32(0));
                }
                else
                {
                    if (groupedByDuration.ContainsKey(3.ToString()))
                        groupedByDuration[3.ToString()] += Reader.GetInt32(0);
                    else
                        groupedByDuration.Add(3.ToString(), Reader.GetInt32(0));
                }

            }
            groupedByDisease.Add(disease.ToString(), groupedByRegion);
            Reader.Close();
            con.Close();
            return groupedByDisease;
        }
    }
}
