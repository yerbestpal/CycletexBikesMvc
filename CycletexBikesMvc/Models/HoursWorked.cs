// name: Ross McLean
// date: 17/05/20

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// HoursWorked class
    /// Creates many to many relationship between Job and Labour classes
    /// </summary>
    public class HoursWorked
    {
        public int Quantity { get; set; }

        // Navigational Properties

        [Key, ForeignKey("Job"), Column(Order = 0)]
        public int? JobId { get; set; }

        public Job Job { get; set; }

        [Key, ForeignKey("Labour"), Column(Order = 1)]
        public int LabourId { get; set; }

        public Labour Labour { get; set; }
    }
}