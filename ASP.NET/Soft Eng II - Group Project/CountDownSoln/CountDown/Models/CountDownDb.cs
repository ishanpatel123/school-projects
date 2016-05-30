using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CountDown.Models
{
   public class CountDownDb : DbContext
   {
      public CountDownDb()
         : base("name=DefaultConnection")
      {
      }

      public DbSet<RegisteredUser> Users { get; set; }
      public DbSet<ToDoItem> Items { get; set; }
   }
}