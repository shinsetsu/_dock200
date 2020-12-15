﻿using System;
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
        private readonly _DBC _d200DB;
        private readonly IWebHostEnvironment _ENV;
        private shinIps2 _shinIps2;

        public HomeController(_DBC _dbc, IWebHostEnvironment env)
        {
            _d200DB = _dbc; _ENV = env;

        }

        private void initVariables()
        {
            //var shinIP2 = new shinIps2(); shinIP2.init();
            //var metrics = new shinSiteMetrics(); metrics.init();


        }

        /////■■■■  O v e r R i d e s ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        public override void OnActionExecuted(ActionExecutedContext context)
        {


            //_DBInitalize.Init(_dbc);

            base.OnActionExecuted(context);

            ViewBag.IsDebug = false;


            ViewBag.IpCount = "";
            ViewBag.pageViewsDebug = "";
            ViewBag.pageViewsRelease = "";
            ViewBag.ClientIP = "";
            ViewBag.IsDebug = true;
            _DBInitalize.Init(_d200DB);


            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development") { ViewBag.IsDebug = true; } else { ViewBag.IsDebug = false; }

            //if (true || Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")//ToggleThisOffIfYouNeedAFasterReloadDuringDevelopment___SometimesIUseThisInDebug_and_sometimesInRelease
            //{

            //    _shinIps2 = new shinIps2();

            //    ViewBag.ClientIP = HttpContext.Connection.RemoteIpAddress.ToString();
            //    if (ViewBag.ClientIP != null) {
            //        _shinIps2.InsertIP(Request.HttpContext.Connection.RemoteIpAddress.ToString(), _d200DB);
            //        //ViewBag.IpCount = _shinIps2.CountIpsSeen();
            //    } else { ViewBag.IpCount = 0; }



            //    shinSiteMetrics siteMetrics = _d200DB.shinSiteMetrics.FirstOrDefault();
            //    //siteMetrics.PageEventsIncrement(_d200DB);
            //    ViewBag.pageViewsDebug = siteMetrics.GetDebugCount(_d200DB);
            //    ViewBag.pageViewsRelease = siteMetrics.GetReleaseCount(_d200DB);
            //    ViewBag.Mac = siteMetrics.GetMacAddress();




            //}
        }

        [Route("")] public IActionResult Index() { return View("z___Index____________________.cshtml"); }
        
        //[Route("styleBotRM")] public IActionResult styleBotRM() { return View("z__styleBotRM.cshtml"); }
        [Route("RefList")] public IActionResult RefList() { return View("RefList.cshtml"); }
        [Route("Form")] public IActionResult Form() { return View("Form.cshtml"); }

        [Route("Resume")] public IActionResult Resume() { return View("z__Resume_________________________.cshtml"); }


        [Route("shinIps2")]
        public async Task<IActionResult> shinIps2I()
        {
            var Ips = await _d200DB.shinIps2.ToListAsync(); return View("Ips.cshtml", Ips);






        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }














        [Route("JT_Company")] public IActionResult JT_Company() { return View("zJT_Company____________________.cshtml"); }
        [Route("JT_Contact")] public IActionResult JT_Contact() { return View("zJT_Contact____________________.cshtml"); }
        [Route("JT_EmployeeLogin")] public IActionResult JT_EmployeeLogin() { return View("zJT_EmployeeLogin____________________.cshtml"); }
        [Route("JTAssociates")] public IActionResult JT_Index() { return View("zJT_Index____________________.cshtml"); }
        [Route("JT_ReportLogin")] public IActionResult JT_ReportLogin() { return View("zJT_ReportLogin____________________.cshtml"); }
        [Route("JT_Solutions")] public IActionResult JT_Solutions() { return View("zJT_Solutions____________________.cshtml"); }
        [Route("JT_Testimonials")] public IActionResult JT_Testimonials() { return View("zJT_Testimonials____________________.cshtml"); }







    }
}
