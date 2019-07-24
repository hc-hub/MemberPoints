using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPMS.Web.Controllers
{
    public class AtricleController : Controller
    {
        // GET: Atricle
        public ActionResult Index(int year, int month, int day, int id)
        {
            var result = $"{year}-{month}-{day}-{id}";
            return Content(result);
        }
    }
}