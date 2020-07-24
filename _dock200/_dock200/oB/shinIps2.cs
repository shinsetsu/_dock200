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
using System.Collections;
using System.Data;

namespace _dock200.Models
{
    public class oList
    {

        [NotMapped] _DBC _dbc;
        [NotMapped]
        List<string> ob { get; set; }
        //{



        //////////////////////////////////var dtm = _dbc.Mapping;
        //////////////////////////////////foreach (var t in dtm.GetTables())
        //////////////////////////////////{
        //////////////////////////////////    Console.WriteLine(t.TableName);
        //////////////////////////////////}

        //_______________
        //https://stackoverflow.com/questions/3892926/entity-framework-get-list-of-tables
        // We need dbcontext to access the models


        //// Get all the entity types information
        //var entityTypes = models.GetEntityTypes();

        //// T is Name of class
        //var entityTypeOfT = entityTypes.First(t => t.ClrType == typeof(T));

        //var tableNameAnnotation = entityTypeOfT.GetAnnotation("Relational:TableName");
        //var TableName = tableNameAnnotation.Value.ToString();
        //return TableName;
        //_______________





        //_________THE SQL Route of doing this. ________________________________________
        //  SELECT TABLE_NAME FROM _d200.INFORMATION_SCHEMA.TABLES
        //List<string> obList = new List<string>();
        //var connectionString = ConfigurationManager.ConnectionStrings["_d200"].ConnectionString;
        //using (var con = new SqlConnection(connectionString))
        //{
        //    string qry = "SELECT TABLE_NAME FROM _d200.INFORMATION_SCHEMA.TABLES";
        //    var cmd = new SqlCommand(qry, con); cmd.CommandType = CommandType.Text;

        //    con.Open();
        //    using (SqlDataReader objReader = cmd.ExecuteReader())
        //    {
        //        if (objReader.HasRows)
        //        {
        //            while (objReader.Read())
        //            {
        //                //I would also check for DB.Null here before reading the value.
        //                string item = objReader.GetString(objReader.GetOrdinal("Column1"));
        //                obList.Add(item);
        //            }
        //        }

        //    }//endOf    ■    using (SqlDataReader objReader = cmd.ExecuteReader())

        //}//endOf        ■  using (var con = new SqlConnection(connectionString))



        //    return (obList);





        //}; set;
        //}

    }

    [Table("sys")] // These should probally be st8 mapped as the ob Name is...  No need for 3 names for somwething...
    public class shinSystem
    {
        [Key] [DisplayName("Id}")] public Int64 id { get; set; }
        public string sysName { get; set; }
        public string sysDesc { get; set; }
        public string sysCode { get; set; }
        public string sysCategory { get; set; }
        public string opStatus { get; set; }
        public string sysEnvironment { get; set; }
        public string sysConditions { get; set; } //Special Instructions or Notes
        public string sysRecovery { get; set; } //Special Instructions or Notes
        public string sysStorageReqs { get; set; } //Special Instructions or Notes
        public string sysSecConfig { get; set; } //Special Instructions or Notes

        public string sysPOC { get; set; }
        public string sysOwner { get; set; }
        public string sysHardware { get; set; }
        public string sysHardwareConfig { get; set; }
        public string sysSoftware { get; set; }

    }

    public class _shinIps2VM
    {
        public _shinIps2VM() { }

        [NotMapped] public ICollection<shinIps2> Ips { get; set; }
        //	[NotMapped] public IEnumerable<shinIps2> Ips { get; set; }
        //	[NotMapped] public int ipRowCount { get; set; }
        //	[NotMapped] public int uniqueAddressesCount { get; set; }

    }

    public enum IpTypes
    {
        [Description("Ipv4")] IP4,
        [Description("Ipv6")] IP6
    }

    //https://docs.microsoft.com/en-us/dotnet/standard/attributes/writing-custom-attributes
    public class shinIps2                //https://ipstack.com/quickstart
    {


        [Key] [DisplayName("Id}")] public Int64 id { get; set; }
        public string IP { get; set; }
        public IpTypes? IpType { get; set; }
        public DateTime? seenDate { get; set; }
        public int? timesSeenDay { get; set; }
        public Int64? timesSeenCount { get; set; }
        public Int64? totalIpsSeen { get; set; }
        public string? countCode { get; set; }
        public string? countName { get; set; }
        public string? stateABR { get; set; }
        public string? state { get; set; }
        public string? city { get; set; }
        public string? zip { get; set; }
        public string? latitude { get; set; }
        public string? longitude { get; set; }


        [NotMapped] public _DBC _dbc;


        public shinIps2()
        {
            IP = "_";
            this.IpType = null;
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




        public bool InsertIP(string ip, _DBC _dbc)
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
            {

                if (ip != "::/")
                { //https://ipstack.com/quickstart
                    using (WebClient client = new WebClient())
                    {
                        string s = client.DownloadString("http://api.ipstack.com/" + shinIP.IP + "?access_key=3c04ccc15d0b1d91a38baf224bf80dd4");
                        //string s = client.DownloadString("http://api.ipstack.com/24.12.63.159?access_key=3c04ccc15d0b1d91a38baf224bf80dd4");

                        JObject jO = JObject.Parse(s);

                        if (jO["type"].ToString() == "ipv4") { shinIP.IpType = IpTypes.IP4; }
                        if (jO["type"].ToString() == "ipv6") { shinIP.IpType = IpTypes.IP6; }

                        shinIP.countCode = jO["country_code"].ToString();
                        shinIP.countName = jO["country_name"].ToString();
                        shinIP.stateABR = jO["region_code"].ToString();
                        shinIP.state = jO["region_name"].ToString();
                        shinIP.city = jO["city"].ToString();
                        shinIP.zip = jO["zip"].ToString();
                        shinIP.latitude = jO["latitude"].ToString();
                        shinIP.longitude = jO["longitude"].ToString();
                    }
                }
               




                _dbc.Add(shinIP);
                _dbc.SaveChanges();
                return true;
            }
            catch (Exception e) { var a = e; return false; }

        }
    }
}