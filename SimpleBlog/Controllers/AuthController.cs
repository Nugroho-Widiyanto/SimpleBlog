/*
~/Controllers/AuthController.cs
*/

using SimpleBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
      if (ModelState.IsValid == false)
        return View(form);

      FormsAuthentication.SetAuthCookie(form.Username, true);

      if (string.IsNullOrWhiteSpace(returnUrl) == false)
        return Redirect(returnUrl);

      return RedirectToRoute("Home");
    }
  }
}
