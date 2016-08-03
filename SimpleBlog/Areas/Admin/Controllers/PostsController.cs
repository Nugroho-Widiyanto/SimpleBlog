/*
 * ~/Areas/Admin/Controllers/PostsController.cs
 */
using SimpleBlog.Infrastructure;
using System.Web.Mvc;

namespace SimpleBlog.Areas.Admin.Controllers
{
  [Authorize(Roles = "admin"), SelectedTab("posts")]
  public class PostsController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}
