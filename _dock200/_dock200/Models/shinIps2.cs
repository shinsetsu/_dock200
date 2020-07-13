using _dock200.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace _dock200.Models
{
	//https://ipstack.com/quickstart
	public class shinIps2
	{


		[Key] [DisplayName("Id}")] public int id { get; set; }
		public string IP { get; set; }
		public int TimesSeen { get; set; }
		public string Type { get; set; }
		public string CountCode { get; set; }
		public string CountName { get; set; }
		public string RegionCode { get; set; }
		public string RegionName { get; set; }
		public string City { get; set; }
		public string Zip { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }





		public string Notes { get; set; }
		internal void init(_DBC _DBC) {
			if (_DBC.shinIps2.Select(x => x.id).Count() > 0)
			{ shinIps2 shinIP = new shinIps2() { IP = "0.0.0.0.0", TimesSeen = 0, Type = "initIP", CountCode = "code", CountName = "countName", RegionCode = "regionCode", RegionName = "regionName", City = "city", Zip = "zip", Latitude = "latitude", Longitude = "longitude", Notes = "notes" }; _DBC.Add(shinIP); _DBC.SaveChanges(); } }
		internal int CountIpsSeen(_DBC _DBC) { return _DBC.shinIps2.Select(x => x.IP).Count(); }

		internal void UpsertIP(_DBC _DBC, string ip)
		{



			try
			{


				shinIps2 shinIps2 = _DBC.shinIps2.FirstOrDefault(m => m.IP == ip);
				if (shinIps2 == null)
				{
					shinIps2 shinIP = new shinIps2() { };
					shinIP.IP = ip;
					shinIP.TimesSeen = 1;

					using (WebClient client = new WebClient())
					{
						//https://ipstack.com/quickstart
						string s = client.DownloadString
							("http://api.ipstack.com/" + shinIP.IP + "?access_key=3c04ccc15d0b1d91a38baf224bf80dd4");


						JObject jObject = JObject.Parse(s);
						JToken IP = jObject["ip"];


						shinIP.Type = jObject["type"].ToString();
						shinIP.CountCode = jObject["country_code"].ToString();
						shinIP.CountName = jObject["country_name"].ToString();
						shinIP.RegionCode = jObject["region_code"].ToString();
						shinIP.RegionName = jObject["region_name"].ToString();
						shinIP.City = jObject["city"].ToString();
						shinIP.Zip = jObject["zip"].ToString();
						shinIP.Latitude = jObject["latitude"].ToString();
						shinIP.Longitude = jObject["longitude"].ToString();


					}


					_DBC.Add(shinIP);
				}
				else
				{
					shinIps2.TimesSeen++;
					_DBC.Update(shinIps2);
				}



				_DBC.SaveChanges();
			}
			catch (Exception e)
			{
				var a = e;
			}


		}
	}
}