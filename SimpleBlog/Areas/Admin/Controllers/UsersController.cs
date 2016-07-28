/*
~/Areas/Admin/Controllers/UsersController.cs
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
    public ActionResult Index()
    {
      return View(new UsersIndex
      {
        Users = Database.Session.Query<User>().ToList()
      });
    }
  }
}
