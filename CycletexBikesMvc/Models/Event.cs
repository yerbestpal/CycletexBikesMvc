using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Event class.
    /// Represents bookings on FullCalendar.
    /// </summary>
    public class Event
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Url { get; set; }
        public bool AllDay { get; set; }
    }
}