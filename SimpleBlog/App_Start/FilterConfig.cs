/*
 * ~/App_Start/FilterConfig.cs
 */
using SimpleBlog.Infrastructure;
using System.Web.Mvc;

namespace SimpleBlog
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
      filters.Add(new TransactionFilter());
    }
  }
}