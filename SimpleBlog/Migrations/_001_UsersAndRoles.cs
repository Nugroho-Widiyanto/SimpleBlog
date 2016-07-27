using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBlog.Migrations
{
  [Migration(1)]
  public class _001_UsersAndRoles : Migration
  {
    public override void Up()
    {
      base.Create.Table("users")
        .WithColumn("id").AsInt32().Identity().PrimaryKey()
        .WithColumn("username").AsString(128)
        .WithColumn("email").AsCustom("VARCHAR(256)")
        .WithColumn("password_hash").AsString(256);

      base.Create.Table("roles")
        .WithColumn("id").AsInt32().Identity().PrimaryKey()
        .WithColumn("name").AsString(128);

      base.Create.Table("role_users")
        .WithColumn("user_id").AsInt32().ForeignKey("users", "id").OnDelete(System.Data.Rule.Cascade)
        .WithColumn("role_id").AsInt32().ForeignKey("roles", "id").OnDelete(System.Data.Rule.Cascade);
    }

    public override void Down()
    {
      base.Delete.Table("role_users");
      base.Delete.Table("roles");
      base.Delete.Table("users");
    }
  }
}