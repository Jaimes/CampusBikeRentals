using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CPS410_CampusBikeRental.Code;

namespace CPS410_CampusBikeRental.ViewModels
{
	public class AccountViewModel
	{
		public List<Checkout> checkouts { get; set; }
        public List<Bike> bikes { get; set; }
	}
}