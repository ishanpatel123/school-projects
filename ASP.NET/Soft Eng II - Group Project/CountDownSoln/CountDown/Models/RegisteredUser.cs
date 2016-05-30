using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountDown.Models
{
   public class RegisteredUser
   {
      public int Id { get; set; }
      public string Firstname { get; set; }
      public string Lastname { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }
      public virtual ICollection<ToDoItem> OwnedItems { get; set; }
      public virtual ICollection<ToDoItem> AssignedItems { get; set; }
      public virtual ICollection<ToDoItem> PendingItems { get; set; }
      public virtual ICollection<ToDoItem> RejectedItems { get; set; }
   }
}