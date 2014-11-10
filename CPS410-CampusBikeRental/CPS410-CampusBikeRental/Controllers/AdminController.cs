using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CPS410_CampusBikeRental.Code;
using CPS410_CampusBikeRental.ViewModels;

namespace CPS410_CampusBikeRental.Controllers
{
    public class AdminController : Controller
	{
		BikeRentalEntities _bikeDb = new BikeRentalEntities();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
			// This is where admin users get access to reports and the check-in/check-out form
			ViewBag.Title = "Dashboard";
			AccountViewModel viewModel = new AccountViewModel();
			viewModel.checkouts = _bikeDb.Checkouts.ToList();
            viewModel.bikes = _bikeDb.Bikes.ToList();

            return View(viewModel);
        }

		[HttpGet]
		public ActionResult CheckOutForm()
		{
			// Admins will have access to check-out/check-in bikes - username, bike num, location
			ViewBag.Title = "Check Out";
			Checkout viewModel = new Checkout();

			return View( viewModel );
		}
		[HttpPost]
		public ActionResult CheckOutForm(Checkout viewModel)
		{
			BikeRentalEntities dbContext = new BikeRentalEntities();
			viewModel.checkOut1 = DateTime.Now;
			dbContext.Checkouts.Add( viewModel );
			try
			{
				dbContext.SaveChanges();
			}
			catch ( Exception ex )
			{
				// TODO: email it
			}

			// scheduled in will be on form when we start worrying about pre-scheduling
			return RedirectToAction( "Index" );
		}

		public ActionResult CheckInForm(int checkoutId)
		{
			BikeRentalEntities dbContext = new BikeRentalEntities();
			var incompleteCheckout = dbContext.Checkouts.First( c => c.checkoutId == checkoutId );
			incompleteCheckout.checkIn = DateTime.Now;
			//dbContext.Checkouts.Add( completeCheckout );
			//dbContext.Checkouts.Remove( incompleteCheckout );
			try
			{
				dbContext.SaveChanges();
			}
			catch ( Exception ex )
			{
				// TODO: email it
			}

			return RedirectToAction( "Index" );
		}

		[HttpGet]
		public ActionResult AddBike()
		{
			Bike viewModel = new Bike();
			return View( viewModel );
		}
		[HttpPost]
		public ActionResult AddBike( Bike viewModel )
		{
			BikeRentalEntities dbContext = new BikeRentalEntities();
			dbContext.Bikes.Add( viewModel );
			try
			{
				dbContext.SaveChanges();
			}
			catch ( Exception ex )
			{
				// TODO: email it
			}
			return RedirectToAction( "Index" );
		}
    }
}
