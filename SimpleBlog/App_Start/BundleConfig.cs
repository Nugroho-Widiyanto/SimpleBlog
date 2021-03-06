﻿/*
 * ~/App_Start/BundleConfig.cs
 */
using System.Web.Optimization;

namespace SimpleBlog
{
  public class BundleConfig
  {
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new StyleBundle("~/styles")
        .Include("~/content/styles/bootstrap.css")
        .Include("~/content/styles/site.css"));

      bundles.Add(new StyleBundle("~/admin/styles")
        .Include("~/content/styles/bootstrap.css")
        .Include("~/content/styles/admin.css"));

      bundles.Add(new StyleBundle("~/scripts")
        .Include("~/scripts/jquery-3.1.0.js")
        .Include("~/scripts/jquery.validate.js")
        .Include("~/scripts/jquery.validate.unobtrusive.js")
        .Include("~/scripts/bootstrap.js"));

      bundles.Add(new StyleBundle("~/admin/scripts")
        .Include("~/scripts/jquery-3.1.0.js")
        .Include("~/scripts/jquery.validate.js")
        .Include("~/scripts/jquery.validate.unobtrusive.js")
        .Include("~/scripts/bootstrap.js")
        .Include("~/areas/admin/scripts/forms.js"));
    }
  }
}