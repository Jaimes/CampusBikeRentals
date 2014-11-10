using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CPS410_CampusBikeRental.Code;

namespace CPS410_CampusBikeRental.ViewModels
{
    public class RentalViewModel
    {
        public Checkout CheckOut { get; set; }
        public SelectList AvailableBikes { get; set; }
    }
}