using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Diagnostics;

namespace Functions
{
    class RegionAppearance
    {
        public string fill { get; set; } = "#d8d8d8";
        public string stroke { get; set; } = "#ffffff";
        public int strokeWidth { get; set; } = 1;
        public string strokeLinejoin { get; set; } = "round";
        public RegionAppearance(string Fill)
        {
            this.fill = Fill;
        }

        public RegionAppearance(int Num)
        {
            this.fill = GenerateColor(Num);
        }

        private string GenerateColor(int num)
        {
            if (num < 5)
                return "#F9E5E0";
            if (num < 100)
                return "#EFAFA1";
            return "#FF00FF";
        }
    }

    public class SerializeToJson
    {

        public static string DateOfCreationJson()
        {
            string jsonString = JsonSerializer.Serialize(AnalysData.DateOfCreationData());
            return jsonString;
        }

        public static string FullDataJson()
        {
            string jsonString = JsonSerializer.Serialize(AnalysData.FullData());
            return jsonString;
        }
        public static string CreateJson()
        {
            Dictionary<string, Dictionary<string, RegionAppearance>> allRegionColors = new Dictionary<string, Dictionary<string, RegionAppearance>>();
            Dictionary<int, Dictionary<int, int>> allRegions = AnalysData.ReadFromFile();
            Dictionary<int, int> regionIncidence = new Dictionary<int, int>();

            foreach (KeyValuePair<int, Dictionary<int, int>> keyValue in allRegions)
            {
                regionIncidence = keyValue.Value;
                Dictionary<string, RegionAppearance> regionColors = new Dictionary<string, RegionAppearance>();
                foreach (KeyValuePair<int, int> item in regionIncidence)
                {
                    regionColors.Add(item.Key.ToString(), new RegionAppearance(item.Value));
                }
                allRegionColors.Add(keyValue.Key.ToString(), regionColors);
            }
            string jsonString = JsonSerializer.Serialize(allRegionColors);
            return jsonString;
        }

    }

}

