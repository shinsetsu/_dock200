using _dock200.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using _dock200.Data;
using _dock200.Models;


namespace _dock200.Models
{
    public class _shinIps2VM
    {
        public _shinIps2VM()
        {
            

        }

        [NotMapped] public ICollection<shinIps2> Ips { get; set; }
        //	[NotMapped] public IEnumerable<shinIps2> Ips { get; set; }
        //	[NotMapped] public int ipRowCount { get; set; }
        //	[NotMapped] public int uniqueAddressesCount { get; set; }

    }



    public class shinIps2                //https://ipstack.com/quickstart
    {


        [Key] [DisplayName("Id}")] public Int64 id { get; set; }
        public string IP { get; set; }
        public string type { get; set; }
        public DateTime seenDate { get; set; }
        public int timesSeenDay { get; set; }
        public Int64 timesSeenCount { get; set; }
        public Int64 totalIpsSeen { get; set; }
        public string countCode { get; set; }
        public string countName { get; set; }
        public string stateABR { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }


        [NotMapped] public _DBC _dbc;


        public shinIps2()
        {
            IP = "_";
            this.type = "_";
            this.seenDate = DateTime.UtcNow;
            this.timesSeenDay = -1;
            this.timesSeenCount = -1;
            this.totalIpsSeen = -1;
            this.countCode = "_";
            this.countName = "_";
            this.stateABR = "_";
            this.state = "_";
            this.city = "_";
            this.zip = "_";
            this.latitude = "_";
            this.longitude = "_";

        }



        public int GetIpRowCount() { return _dbc.shinIps2.Select(x => x.IP).Count(); }
        public shinIps2 GetIp(int id) { return _dbc.shinIps2.FirstOrDefault(x => x.id == id); }
        //public  List<shinIps2> GetIps() {  return  _DBC.shinIps2.Select(); }

        public int GetIpCount()
        {
            int rowCount;
            var connectionString = ConfigurationManager.ConnectionStrings["_d200"].ConnectionString;
            string queryString = "SELECT COUNT(*)FROM [_d200].[dbo].[shinIps2]WHERE 1=1;";
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                rowCount = (int)command.ExecuteScalar();
            }
            return rowCount;
        }


        public bool InsertIP(string ip)
        { //Returns True if added, False if not;
            shinIps2 shinIP = new shinIps2()
            {
                IP = ip,
                seenDate = DateTime.UtcNow,
                timesSeenDay = 1,
                timesSeenCount = 1,
                totalIpsSeen = 1
            };

            try
            {          //https://ipstack.com/quickstart
                using (WebClient client = new WebClient())
                {
                    string s = client.DownloadString("http://api.ipstack.com/" + shinIP.IP + "?access_key=3c04ccc15d0b1d91a38baf224bf80dd4");

                    JObject jObject = JObject.Parse(s);
                    shinIP.type = jObject["type"].ToString();
                    shinIP.countCode = jObject["country_code"].ToString();
                    shinIP.countName = jObject["country_name"].ToString();
                    shinIP.stateABR = jObject["region_code"].ToString();
                    shinIP.state = jObject["region_name"].ToString();
                    shinIP.city = jObject["city"].ToString();
                    shinIP.zip = jObject["zip"].ToString();
                    shinIP.latitude = jObject["latitude"].ToString();
                    shinIP.longitude = jObject["longitude"].ToString();
                }

                //using (var context = new _DBC() { }) { 
                //}
                    //using (var _dbc = new _DBC(getConnectionString)) { _dbc.Add(shinIP); _dbc.SaveChanges(); }
                    return true;
            }
            catch (Exception e) { var a = e; return false; }

        }
    }
}