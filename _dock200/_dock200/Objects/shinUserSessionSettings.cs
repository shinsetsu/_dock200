using _dock200.Data;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;


namespace _dock200.Models
{
	public class shinUserSessionSettings
	{
		

		[Key]
		public string io { get; set; }
		public string IP { get; set; }
		public bool DarkStyle { get; set; }
		public DateTime expirationTime { get; set; }

		//internal void InintUpsert(_DBC _dbC, string ip)
		//{


		//	try
		//	{
		//		shinUserSessionSettings userSession = _dbC.shinUserSessionSettings.FirstOrDefault(m => m.IP == ip);
		//		if (userSession == null)
		//		{
		//			userSession = new shinUserSessionSettings() { };
		//			userSession.IP = ip;


		//			_dbC.Add(userSession);

		//		}
		//		else
		//		{
		//			userSession.DarkStyle = true;
		//			userSession.expirationTime = DateTime.UtcNow;
		//			_dbC.Update(userSession);
		//		}


		//	}
		//	catch (Exception e)
		//	{

		//		throw;
		//	}



		//}
	}





}
