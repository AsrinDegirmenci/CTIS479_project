using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace MVC.Controllers.BaseController
{
	public abstract class MvcController : Controller
	{
		protected MvcController() 
		{
			CultureInfo cultureInfo = new CultureInfo("en-US");
			Thread.CurrentThread.CurrentCulture = cultureInfo;
			Thread.CurrentThread.CurrentUICulture = cultureInfo;
		}
	}
}
