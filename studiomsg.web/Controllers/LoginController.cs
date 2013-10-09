using System.Web.Mvc;
using System.Web.Security;

namespace studiomsg.web.Controllers
{
	public class LoginController: Controller
	{

		public ActionResult Index(LoginModel model)
		{
			return View(model);
		}

		[HttpPost]
		public ActionResult Login(LoginModel model, string returnUrl)
		{
			bool userValid = model.Password == "nrkstudio";

			// User found in the database
			if(userValid)
			{

				FormsAuthentication.SetAuthCookie("testcookie", true);
				if(Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
					&& !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
				{
					return Redirect(returnUrl);
				}
				else
				{
					return RedirectToAction("Index", "Home");
				}
			}
			
			// If we got this far, something failed, redisplay form
			model.IsLoginAttemptWithWrongPassword = true;
			return RedirectToAction("Index", model);
		}


	}

	public class LoginModel
	{
		public string Password { get; set; }

		public bool IsLoginAttemptWithWrongPassword { get; set; }
	}
}
