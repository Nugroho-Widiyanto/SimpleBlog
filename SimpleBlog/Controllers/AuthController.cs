/*
 * ~/Controllers/AuthController.cs
 */
using NHibernate.Linq;
using SimpleBlog.Models;
using SimpleBlog.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace SimpleBlog.Controllers
{
  public class AuthController : Controller
  {
    [HttpGet]
    public ActionResult Logout()
    {
      FormsAuthentication.SignOut();
      return RedirectToRoute("Home");
    }

    [HttpGet]
    public ActionResult Login()
    {
      return View(new AuthLogin
      {
      });
    }

    [HttpPost]
    public ActionResult Login(AuthLogin form, string returnUrl)
    {

      var user = Database.Session.Query<User>().FirstOrDefault(u => u.Username == form.Username);

      if (user == null)
        SimpleBlog.Models.User.FakeHash();//for prevent timing attack, simulate hashing, so the loading time would be similar

      if (user == null || user.CheckPassword(form.Password) == false)
        ModelState.AddModelError("Username", "Username or password is incorrect!");

      if (ModelState.IsValid == false)
        return View(form);

      FormsAuthentication.SetAuthCookie(user.Username, true);

      if (string.IsNullOrWhiteSpace(returnUrl) == false)
        return Redirect(returnUrl);

      return RedirectToRoute("Home");
    }
  }
}
