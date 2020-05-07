using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CycletexBikesMvc.Controllers
{
    /// <summary>
    /// CalendarController class.
    /// Handles functionality for DayPilot.
    /// </summary>
    public class CalendarController : Controller
    {
        public ActionResult Backend()
        {
            return new Dpc().CallBack(this);
        }

        class Dpc : DayPilotCalendar
        {
            protected override void OnInit (InitArgs e)
            {
                UpdateWithMessage("Welcome!", CallBackUpdateType.Full);
            }
        }
    }
}
