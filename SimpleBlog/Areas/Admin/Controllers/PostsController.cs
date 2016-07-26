using SimpleBlog.Infrastructure;
/*
~/Areas/Admin/Controllers/PostsController.cs
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
