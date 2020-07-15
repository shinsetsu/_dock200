﻿using _dock200.Data;
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
	public class _shinIps2VM {
		[NotMapped] public IEnumerable<shinIps2> Ips { get; set; }
		[NotMapped] public int ipRowCount { get; set; }
		[NotMapped] public int uniqueAddressesCount { get; set; }



		public _DBC _DBC;

		public _shinIps2VM() {

			var ip = new shinIps2() { };
			this.Ips = GetIps();
			this.ipRowCount = _DBC.shinIps2.Select(x => x.IP).Count();

		}





		public _DBC _dbc;

		private List<shinIps2> GetIps() {
			//.OrderBy(b => b.Url).Where(b => b.Rating > 3).ToList();
			try { using (var db = _dbc) { return db.shinIps2.ToList(); } } catch (Exception e) {
				var a = e; throw;
			}
		}

		//public void init() {
		//	if (_DBC.shinIps2.Select(x => x.id).Count() > 0) { shinIps2 shinIP = new shinIps2() { IP = "0.0.0.0.0", TimesSeen = 0, Type = "initIP", CountCode = "code", CountName = "countName", RegionCode = "regionCode", RegionName = "regionName", City = "city", Zip = "zip", Latitude = "latitude", Longitude = "longitude", Notes = "notes" }; _DBC.Add(shinIP); _DBC.SaveChanges(); }
		//}
	}

	public interface IshinIps {


	}

	public class shinIps2                //https://ipstack.com/quickstart
	{


		[Key] [DisplayName("Id}")] public Guid id { get; set; }
		public string IP { get; set; }
		public string Type { get; set; }
		public DateTime SeenDate { get; set; }
		public int TimesSeenDated { get; set; }
		[NotMapped] public int TimesSeenCount { get; set; }
		public string CountCode { get; set; }
		public string CountName { get; set; }
		public string StateABR { get; set; }
		public string State { get; set; }
		public string City { get; set; }
		public string Zip { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public string Notes { get; set; }




		public _DBC _DBC;




		public int GetIpRowCount() { return _DBC.shinIps2.Select(x => x.IP).Count(); }
		public shinIps2 GetIp(Guid id) { return _DBC.shinIps2.FirstOrDefault(x => x.id == id); }
		public async Task<shinIps2> GetIpsAsync(Guid id) { if (id == Guid.Empty) { throw new ArgumentNullException(nameof(id)); } return await _DBC.shinIps2.FirstOrDefaultAsync(x => x.id == id); }
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


			shinIps2 shinIP = new shinIps2() { IP = ip};			

			try {          //https://ipstack.com/quickstart
				using (WebClient client = new WebClient()) {
					string s = client.DownloadString("http://api.ipstack.com/" + shinIP.IP + "?access_key=3c04ccc15d0b1d91a38baf224bf80dd4");

					JObject jObject = JObject.Parse(s); shinIP.Type = jObject["type"].ToString(); shinIP.CountCode = jObject["country_code"].ToString(); shinIP.CountName = jObject["country_name"].ToString(); shinIP.StateABR = jObject["StateABR"].ToString(); shinIP.State = jObject["State"].ToString(); shinIP.City = jObject["city"].ToString(); shinIP.Zip = jObject["zip"].ToString(); shinIP.Latitude = jObject["latitude"].ToString(); shinIP.Longitude = jObject["longitude"].ToString();
				}
				using (_DBC) { _DBC.Add(shinIP); _DBC.SaveChanges(); }
				return true;
			} catch (Exception e) { var a = e; return false; }

		}
	}
}