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
		internal int CountIpsSeen(_DBC _DBC)
		{
			return _DBC.shinIps2.Select(x => x.IP).Count();

		}

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
					using (WebClient client = new WebClient())
					{
						string s = client.DownloadString
							("http://api.ipstack.com/24.12.63.159?access_key=3c04ccc15d0b1d91a38baf224bf80dd4");


						JObject jObject = JObject.Parse(s);
						JToken IP = jObject["ip"];


						shinIps2.Type = jObject["type"].ToString();
						shinIps2.CountCode = jObject["country_code"].ToString();
						shinIps2.CountName = jObject["country_name"].ToString();
						shinIps2.RegionCode = jObject["region_code"].ToString();
						shinIps2.RegionName = jObject["region_name"].ToString();
						shinIps2.City = jObject["city"].ToString();
						shinIps2.Zip = jObject["zip"].ToString();
						shinIps2.Latitude = jObject["latitude"].ToString();
						shinIps2.Longitude = jObject["longitude"].ToString();


					}
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