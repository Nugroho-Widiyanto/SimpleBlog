/*
 * ~/Areas/Admin/Controllers/UsersController.cs
 */
using NHibernate.Linq;
using SimpleBlog.Areas.Admin.ViewModels;
using SimpleBlog.Infrastructure;
using SimpleBlog.Models;
using System.Linq;
using System.Web.Mvc;

namespace SimpleBlog.Areas.Admin.Controllers
{
  [Authorize(Roles = "admin"), SelectedTab("users")]
  public class UsersController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View(new UsersIndex
      {
        Users = Database.Session.Query<User>().ToList()
      });
    }

    [HttpGet]
    public ActionResult New()
    {
      return View(new UsersNew
      {
      });
    }

    [HttpPost]
    public ActionResult New(UsersNew form)
    {
      if (Database.Session.Query<User>().Any(u => u.Username == form.Username))
        ModelState.AddModelError("Username", "Username must be unique!");

      if (ModelState.IsValid == false)
        return View();

      var user = new User
      {
        Username = form.Username,
        Email = form.Email
      };
      user.SetPassword(form.Password);

      Database.Session.Save(user);
      return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
      var user = Database.Session.Load<User>(id);
      if (user == null)
        return HttpNotFound();
      
      return View(new UsersEdit
        {
          Username = user.Username,
          Email = user.Email
        });
    }

    [HttpPost]
    public ActionResult Edit(int id, UsersEdit form)
    {
      var user = Database.Session.Load<User>(id);
      if (user == null)
        return HttpNotFound();

      if(Database.Session.Query<User>().Any(u => u.Username == form.Username && u.Id != id))
        ModelState.AddModelError("Username", "Username must be unique!");

      if (ModelState.IsValid == false)
        return View(form);

      user.Username = form.Username;
      user.Email = form.Email;
      Database.Session.Update(user);

      return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult ResetPassword(int id)
    {
      var user = Database.Session.Load<User>(id);
      if (user == null)
        return HttpNotFound();
      
      return View(new UsersResetPassword
      {
        Username = user.Username
      });
    }

    [HttpPost]
    public ActionResult ResetPassword(int id, UsersResetPassword form)
    {
      var user = Database.Session.Load<User>(id);
      if (user == null)
        return HttpNotFound();

      form.Username = user.Username;

      if (ModelState.IsValid == false)
        return View(form);

      user.SetPassword(form.Password);
      Database.Session.Update(user);

      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
      var user = Database.Session.Load<User>(id);
      if (user == null)
        return HttpNotFound();

      Database.Session.Delete(user);
      return RedirectToAction("Index");
    }
  }
}
