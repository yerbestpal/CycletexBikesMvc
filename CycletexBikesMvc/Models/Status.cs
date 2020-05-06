using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Status class.
    /// Acts as bridge between Statuses enum and classes accessing them.
    /// </summary>
    public class Status
    {
        public Statuses Statuses { get; set; }
    }

    /// <summary>
    /// Statuses enumeration.
    /// Contains list of different possible Status types.
    /// </summary>
    public enum Statuses
    {
        Completed,
        InProgress,
        NotStarted
    }
}