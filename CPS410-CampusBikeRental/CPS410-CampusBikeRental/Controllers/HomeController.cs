using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CPS410_CampusBikeRental.Code;
using CPS410_CampusBikeRental.ViewModels;

namespace CPS410_CampusBikeRental.Controllers
{
	public class HomeController : Controller
	{
		public bool isLoggedIn;

		BikeRentalEntities _bikeDb = new BikeRentalEntities();

		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Login( LoginViewModel viewModel )
		{
			if ( string.IsNullOrEmpty( viewModel.password ) ) { viewModel.password = "asd"; }

			if ( viewModel.password.Equals("admin", StringComparison.OrdinalIgnoreCase) )
			{
				return RedirectToAction( "Index", "Admin" );
			}
			else
			{
				return RedirectToAction( "Index" );
			}
		}

		public ActionResult Index()
		{
			// Choose where to send user based on usertype
			// Pop up login if no user type found

            HomeViewModel viewModel = new HomeViewModel();
            viewModel.AccountViewModel = new AccountViewModel();
            viewModel.AccountViewModel.checkouts = _bikeDb.Checkouts.ToList();

            viewModel.RentalViewModel = new RentalViewModel();
            viewModel.RentalViewModel.CheckOut = new Checkout();
            viewModel.RentalViewModel.CheckOut.username = "sutte1aa";
            viewModel.RentalViewModel.CheckOut.bikeNumber = 134235;

            List<Bike> availableBikes = new List<Bike>(_bikeDb.Bikes.Where(x => x.isAvailable == true));
            

            viewModel.RentalViewModel.AvailableBikes = new SelectList(availableBikes, "bikeNumber", "bikeNumber + condition");

			return View(viewModel);
		}

		public ActionResult AccountOverview()
		{
			// This is where a student can see past and current rentals, upcoming reservations, and bill
			// Link to reservation form is in menu here
			ViewBag.Title = "Account Overview";
			ViewBag.Message = "What would you like to do?";
			AccountViewModel viewModel = new AccountViewModel();
			viewModel.checkouts = _bikeDb.Checkouts.ToList();
			return View(viewModel);
		}

		[HttpGet]
		public ActionResult RentalForm()
		{
			// Students will have access to reserve bikes - out datetime, return datetime, location
			// Admins will have access to check-out/check-in bikes - username, bike num, location
			ViewBag.Title = "Reserve a Bike";
            RentalViewModel viewModel = new RentalViewModel();
            viewModel.CheckOut = new Checkout();

            viewModel.CheckOut.username = "sutte1aa";
            viewModel.CheckOut.bikeNumber = 134235;

			return View( viewModel );
		}
		[HttpPost]
        public ActionResult RentalForm(RentalViewModel viewModel)
		{
			BikeRentalEntities dbContext = new BikeRentalEntities();
			dbContext.Checkouts.Add( viewModel.CheckOut );
			try
			{
				dbContext.SaveChanges();
			}
			catch ( Exception ex )
			{
				// TODO: email it
			}

			return RedirectToAction( "AccountOverview" );
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your app description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}
