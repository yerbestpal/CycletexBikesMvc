using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nexmo.Api;

namespace CycletexBikesMvc.Controllers
{
    public class SMSController : Controller
    {
        [HttpGet]
       public ActionResult Send()
        {
            return View();
        }
    }
}
