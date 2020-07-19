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

namespace _dock200.Models {
	//public class _shinIps2VM {
	//	[NotMapped] public IEnumerable<shinIps2> Ips { get; set; }
	//	[NotMapped] public int ipRowCount { get; set; }
	//	[NotMapped] public int uniqueAddressesCount { get; set; }



	//	public _DBC _DBC;

	//	public _shinIps2VM() {

	//		var ip = new shinIps2() { };
	//		this.Ips = GetIps();
	//		this.ipRowCount = _DBC.shinIps2.Select(x => x.IP).Count();

	//	}





	//	public _DBC _dbc;

	//	private List<shinIps2> GetIps() {
	//		//.OrderBy(b => b.Url).Where(b => b.Rating > 3).ToList();
	//		try { using (var db = _dbc) {
	//				return db.shinIps2.ToList(); } }
	//		catch (Exception e) {
	//			var a = e; throw;
	//		}
	//	}

	//	//public void init() {
	//	//	if (_DBC.shinIps2.Select(x => x.id).Count() > 0) { shinIps2 shinIP = new shinIps2() { IP = "0.0.0.0.0", TimesSeen = 0, Type = "initIP", CountCode = "code", CountName = "countName", RegionCode = "regionCode", RegionName = "regionName", City = "city", Zip = "zip", Latitude = "latitude", Longitude = "longitude", Notes = "notes" }; _DBC.Add(shinIP); _DBC.SaveChanges(); }
	//	//}
	//}


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
		

		[NotMapped] public _DBC _DBC;




		public int GetIpRowCount() { return _DBC.shinIps2.Select(x => x.IP).Count(); }
		public shinIps2 GetIp(int id) { return _DBC.shinIps2.FirstOrDefault(x => x.id == id); }
		//public  List<shinIps2> GetIps() {  return  _DBC.shinIps2.Select(); }

		public int GetIpCount() {
			int rowCount;
			var connectionString = ConfigurationManager.ConnectionStrings["_d200"].ConnectionString;
			string queryString = "SELECT COUNT(*)FROM [_d200].[dbo].[shinIps2]WHERE 1=1;";
			using (var connection = new SqlConnection(connectionString)) {
				var command = new SqlCommand(queryString, connection);
				connection.Open();
				rowCount = (int)command.ExecuteScalar();
			}
			return rowCount;
		}


		public bool InsertIP(string ip) { //Returns True if added, False if not;
			shinIps2 shinIP = new shinIps2() { IP = ip };

			try {          //https://ipstack.com/quickstart
				using (WebClient client = new WebClient()) {
					string s = client.DownloadString("http://api.ipstack.com/" + shinIP.IP + "?access_key=3c04ccc15d0b1d91a38baf224bf80dd4");

					JObject jObject = JObject.Parse(s); shinIP.type = jObject["type"].ToString(); shinIP.countCode = jObject["country_code"].ToString(); shinIP.countName = jObject["country_name"].ToString(); shinIP.stateABR = jObject["StateABR"].ToString(); shinIP.state = jObject["State"].ToString(); shinIP.city = jObject["city"].ToString(); shinIP.zip = jObject["zip"].ToString(); shinIP.latitude = jObject["latitude"].ToString(); shinIP.longitude = jObject["longitude"].ToString();
				}
				using (_DBC) { _DBC.Add(shinIP); _DBC.SaveChanges(); }
				return true;
			} catch (Exception e) { var a = e; return false; }

		}
	}
}