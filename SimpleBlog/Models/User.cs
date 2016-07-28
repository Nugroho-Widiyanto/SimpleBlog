﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SimpleBlog.Models
{
  //just poco and have to be virtual
  public class User
  {
    public virtual int Id { get; set; }
    public virtual string Username { get; set; }
    public virtual string Email { get; set; }
    public virtual string PasswordHash { get; set; }
  }

  public class UserMap : ClassMapping<User>
  {
    public UserMap()
    {
      Table("users");
      Id(x => x.Id, x => x.Generator(Generators.Identity));

      //by default if you dont overide the field name of the property, it will default to the property name and mysql in general is case insensitive
      Property(x => x.Username, x => x.NotNullable(true));
      Property(x => x.Email, x => x.NotNullable(true));

      //if you wanna add more than 1 expression to this lambda, wrapp it inside curly braces
      Property(x => x.PasswordHash, x =>
      {
        x.Column("password_hash");//this time we override the field name
        x.NotNullable(true);
      });
    }
  }
}