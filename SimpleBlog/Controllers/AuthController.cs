/*
~/Controllers/AuthController.cs
*/

using SimpleBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.Controllers
{
  public class AuthController : Controller
  {
    [HttpGet]
    public ActionResult Login()
    {
      return View(new AuthLogin
      {
      });
    }

    [HttpPost]
    public ActionResult Login(AuthLogin form)
    {
      if (ModelState.IsValid == false)
        return View(form);

      if (form.Username != "widi")
      {
        ModelState.AddModelError("Username", "not widi");
        return View(form);
      }

      return Content("form is valid");
    }
  }
}
