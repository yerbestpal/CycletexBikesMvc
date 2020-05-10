using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// EventViewModel class.
    /// Used as a template to build events and send them to the Index view.
    /// </summary>
    public class EventViewModel
    {
        public Int64 id { get; set; }
        public String title { get; set; }
        public String start { get; set; }
        public String end { get; set; }
        public bool allDay { get; set; }
    }
}