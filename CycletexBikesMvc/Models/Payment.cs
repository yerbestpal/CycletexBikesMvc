// name: Ross McLean
// date: 13/05/20

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
	/// <summary>
	/// Payment POCO class
	/// Facilitiates payment of Bookings via DebitCards
	/// </summary>
	public class Payment
	{
		[Key]
		public int Id { get; set; }

		public bool IsSuccessful { get; set; }

		[DataType(DataType.DateTime),
		 DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
		public DateTime Date { get; set; }

		public decimal Total { get; set; }

		// Navigational Properties

		[ForeignKey("Booking")]
		public int BookingId { get; set; }
		public Booking Booking { get; set; }
	}
}