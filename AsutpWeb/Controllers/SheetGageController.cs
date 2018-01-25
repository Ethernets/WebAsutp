using System;
using System.Data.OracleClient;
using System.Web.Mvc;
using AsutpWeb.Models;

namespace AsutpWeb.Controllers
{
    public class SheetGageController : Controller
    {
        // GET: SteelGage
        public ActionResult SheetGage()
        {
            var ora = new OracleCon();
            
            ViewBag.Test = ora.OracleQury("Select datetime from test where datetime IS NOT null", 1);

            ora.OracleCloseCon();
            
            //oracleCon:OracleDataReader=Convert.ToDateTime() //var dt = Convert.ToDateTime(dr.GetDateTime(0));

            return View();
        }
    }
}