using System.Web;
using System.Web.Mvc;

namespace CPS410_CampusBikeRental
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters( GlobalFilterCollection filters )
		{
			filters.Add( new HandleErrorAttribute() );
		}
	}
}