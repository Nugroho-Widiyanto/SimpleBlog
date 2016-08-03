/*
 * ~/Controllers/PostsController.cs
 */
using System.Web.Mvc;

namespace SimpleBlog.Controllers
{
  public class PostsController : Controller
  {
    public ActionResult Index()
    {
      //return Content("PostsController.Index");
      return View();
    }
  }
}
