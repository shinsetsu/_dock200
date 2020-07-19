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
		public class shinLink
	{
		public shinLink() { }
		public shinLink(string aHref, string aId, string aDisplayText, bool debug)
		{
			this.aHref = aHref;
			this.aId = aId;
			this.aDisplayText = aDisplayText;
			this.aTarget = "_self";
			this.aDownload = "";
			this.aFilename = "";
			this.debugBool = debug;
		}
		public shinLink(string aHref, string aId, string aDisplayText)
		{
			this.aHref = aHref;
			this.aId = aId;
			this.aDisplayText = aDisplayText;
			this.aTarget = "_self";
			this.aDownload = "";
			this.aFilename = "";
			this.debugBool = false;
		}
		public shinLink(string aHref, string aId, string aDisplayText, string aTarget, string aDownload, string aFilename)
		{
			this.aHref = aHref;
			this.aId = aId;
			this.aDisplayText = aDisplayText;
			this.aTarget = aTarget;
			this.aDownload = aDownload;
			this.aFilename = aFilename;
			this.debugBool = false;
		}

		public string aHref { get; set; }
		public string aId { get; set; }
		public string aDisplayText { get; set; }
		public string aTarget { get; set; }
		public string aDownload { get; set; }
		public string aFilename { get; set; }
		public bool debugBool { get; set; }
	}




	public class shinSiteMetrics
	{


		public interface IshinsiteMetrics
		{
			public void PageViewDebugIncrement();
			public void PageViewReleaseIncrement();
			public void init();
		}

		public void init(_DBC _DBC)
		{
			var metric = new shinSiteMetrics()
			{
				pageViewsDebug = 1,
				pageViewsRelease = 1,
				pageViewsEx = 1
			};

			_DBC.Add(metric);
			_DBC.SaveChanges();
	}


		[Key] [DisplayName("Id}")] public int id { get; set; }


		[DisplayName("PageViewsDebug")] public int pageViewsDebug { get; set; }
		[DisplayName("PageViewsRelease")] public int pageViewsRelease { get; set; }
		[DisplayName("pageViewsEx")] public int pageViewsEx { get; set; }
		//[DisplayName("Ips")] public virtual ICollection<shinIps2> Ips { get; set; }

		internal string GetMacAddress()
		{
			const int MIN_MAC_ADDR_LENGTH = 12;
			string macAddress = string.Empty;
			long maxSpeed = -1;

			foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
			{
				//log.Debug(
				//    "Found MAC Address: "+nic.GetPhysicalAddress()+
				//    " Type: "+nic.NetworkInterfaceType);

				string tempMac = nic.GetPhysicalAddress().ToString();
				if (nic.Speed > maxSpeed &&
				    !string.IsNullOrEmpty(tempMac) &&
				    tempMac.Length >= MIN_MAC_ADDR_LENGTH)
				{
					//log.Debug("New Max Speed = "+nic.Speed+", MAC: "+tempMac);
					maxSpeed = nic.Speed;
					macAddress = tempMac;
				}
			}

			return macAddress;
		}





		internal void PageEventsIncrement(_DBC _dbContext)
		{
			try
			{
				shinSiteMetrics siteMetrics = _dbContext.shinSiteMetrics.FirstOrDefault();
				if (siteMetrics == null)
				{
					siteMetrics = new shinSiteMetrics() { };
					_dbContext.Add(siteMetrics);

				}

				if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
				{
					siteMetrics.pageViewsDebug++;
					_dbContext.Update(siteMetrics);


				}
				else
				{
					siteMetrics.pageViewsRelease++;
					_dbContext.Update(siteMetrics);
				}



				_dbContext.SaveChanges();
			}
			catch (Exception e)
			{
				var a = e;
			}
		}


		internal void PageViewExIncrement(_DBC _dbContext)
		{


			try
			{
				shinSiteMetrics siteMetrics = _dbContext.shinSiteMetrics.FirstOrDefault();
				siteMetrics.pageViewsEx++;
				_dbContext.Update(siteMetrics);
				_dbContext.SaveChanges();
			}
			catch (Exception e)
			{
				var a = e;
			}

		}


		internal dynamic GetReleaseCount(_DBC _dbContext)
		{
			try
			{
				shinSiteMetrics siteMetrics = _dbContext.shinSiteMetrics.FirstOrDefault();
				if (siteMetrics == null)
				{
					siteMetrics = new shinSiteMetrics() { };

				}
				return siteMetrics.pageViewsRelease;
			}
			catch (Exception)
			{
				return 0;
			}

		}

		internal dynamic GetDebugCount(_DBC _dbContext)
		{
			try
			{
				shinSiteMetrics siteMetrics = _dbContext.shinSiteMetrics.FirstOrDefault();
				if (siteMetrics == null)
				{
					siteMetrics = new shinSiteMetrics() { };

				}
				return siteMetrics.pageViewsDebug;
			}
			catch (Exception)
			{
				return 0;
			}



		}
	}



}
