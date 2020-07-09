using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _dock200.Models;
using _dock200.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace _dock200.Controllers
{
	public class HomeController : Controller
	{
		//private readonly ILogger<HomeController> _logger;
		private readonly _DBC _DBC;
		private readonly IWebHostEnvironment _ENv;
		private shinIps2 _shinIps2;


		public HomeController(_DBC dbc, IWebHostEnvironment env) { _DBC = dbc; _ENv = env; }
		/////■■■■  O v e r R i d e s ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

		public override void OnActionExecuted(ActionExecutedContext context)
		{

			base.OnActionExecuted(context);

			ViewBag.IsDebug = false;


			//ViewBag.IpCount = "";
			//ViewBag.pageViewsDebug = "";
			//ViewBag.pageViewsRelease = "";
			//ViewBag.ClientIP = "";
			//ViewBag.IsDebug = true;



			//if (true)//ToggleThisOffIfYouNeedAFasterReloadDuringDevelopment___SometimesIUseThisInDebug_and_sometimesInRelease
			//{



			//	if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
			//	{ ViewBag.IsDebug = true; }
			//	else
			//	{
			//		ViewBag.IsDebug = false;

			//		ViewBag.ClientIP = HttpContext.Connection.RemoteIpAddress.ToString();
			//		if (ViewBag.ClientIP != null)
			//		{
			//			_shinIps2.UpsertIP(_port198DBContext, Request.HttpContext.Connection.RemoteIpAddress.ToString());
			//			ViewBag.IpCount = _shinIps2.CountIpsSeen(_port198DBContext);
			//		}
			//		else { ViewBag.IpCount = 0; }



			//		shinSiteMetrics siteMetrics = _port198DBContext.shinSiteMetrics.FirstOrDefault();
			//		siteMetrics.PageEventsIncrement(_port198DBContext);
			//		ViewBag.pageViewsDebug = siteMetrics.GetDebugCount(_port198DBContext);
			//		ViewBag.pageViewsRelease = siteMetrics.GetReleaseCount(_port198DBContext);
			//		ViewBag.Mac = siteMetrics.GetMacAddress();

			//		if (ViewBag.ClientIp != null)
			//		{
			//			shinUserSessionSettings userSessionSettings = new shinUserSessionSettings();
			//			userSessionSettings.InintUpsert(_port198DBContext, ViewBag.ClientIp);

			//		}

			//	}





		}



		[Route("")] public IActionResult Index() { return View("z___Index____________________.cshtml"); }
		[Route("Resume")] public IActionResult Resume() { return View("z__Resume_________________________.cshtml"); }


		[Route("shinIps2")]
		public async Task<IActionResult> shinIps2()
		{
			//var Ips = await _DBC.shinIps2.ToListAsync();
			var Ips = await _DBC.shinIps2.ToListAsync();

			
			
				return View("Ips.cshtml", Ips);
			
			
		



		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
