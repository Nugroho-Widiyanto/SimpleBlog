/*
 * ~/Areas/Admin/ViewModels/Users.cs
 */
using SimpleBlog.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Areas.Admin.ViewModels
{
  public class UsersIndex
  {
    public IEnumerable<User> Users { get; set; }
  }

  public class UsersNew
  {
    [Required, MaxLength(128)]
    public string Username { get; set; }

    [Required, DataType(DataType.Password)]
    public string Password { get; set; }

    [Required, MaxLength(256), DataType(DataType.EmailAddress)]
    public string Email { get; set; }
  }

  public class UsersEdit
  {
    [Required, MaxLength(128)]
    public string Username { get; set; }

    [Required, MaxLength(256), DataType(DataType.EmailAddress)]
    public string Email { get; set; }
  }

  public class UsersResetPassword
  {
    //we are not using data annotation
    //coz we're not using this property to communicate from view to controller
    //we are only using this as data that being populated from the controller and being presented in the view
    //coz we're not making a format of this, we dont need to add data annotation
    public string Username { get; set; }

    [Required, DataType(DataType.Password)]
    public string Password { get; set; }
  }
}