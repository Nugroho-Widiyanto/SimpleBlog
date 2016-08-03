/*
 * ~/Database.cs
 */
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using SimpleBlog.Models;
using System.Web;

namespace SimpleBlog
{
  public static class Database
  {
    private const string SessionKey = "SimpleBlog.Database.SessionKey";//alternate option rather than to use GUID
    private static ISessionFactory _sessionFactory;

    public static ISession Session
    {
      // if casting fail, it will throw exception
      // e.g. when someone referencing it and the session has not been initialized or not the correct type of object
      get { return (ISession) HttpContext.Current.Items[SessionKey]; }
    }

    //app level
    public static void Configure()//will be invoked at application startup
    {
      var config = new Configuration();

      //configure the connection string
      config.Configure();//will automatically look at web.config

      //add mappings
      var mapper = new ModelMapper();
      mapper.AddMapping<UserMap>();//tell the mapper about the mappings
      config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());//tell the configuration about the mapper

      //create session factory
      _sessionFactory = config.BuildSessionFactory();
    }

    //request level
    public static void OpenSession()//will be invoked at the beginning of every request
    {
      HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
    }

    //request level
    public static void CloseSession()//will be invoked at the end of every request
    {
      // if casting fail, it will NOT throw exception
      // e.g. the session were never open in a request even if the close session is invoke
      //      example: you want to make sure that requesting for a file or image from the server is not resulting of opening database connection
      var session = HttpContext.Current.Items[SessionKey] as ISession;
      if (session != null)
        session.Close();

      HttpContext.Current.Items.Remove(SessionKey);
    }
  }
}