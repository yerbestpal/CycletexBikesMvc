// name: Ross McLean
// date: 15/05/20

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CycletexBikesMvc.ViewModels
{
	/// <summary>
	/// MakePaymentViewModel class
	/// Creates a view for the MakePayment action
	/// </summary>
	public class MakePaymentViewModel
    {

		public bool IsSuccessful { get; set; }

		[DataType(DataType.DateTime),
		 DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
		public DateTime Date { get; set; }

		// Populates dropDownListFor()
		public List<SelectListItem> DebitCards { get; set; }

		// Stores the Id of the selected item
		public int SelectedDebitCardId { get; set; }

		public decimal Total { get; set; }
	}
}