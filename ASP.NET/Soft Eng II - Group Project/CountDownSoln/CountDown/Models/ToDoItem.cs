using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountDown.Models
{
   public class ToDoItem
   {
      public enum Status
      {
         WaitingForOther,
         Rejected,
         WaitingForYou,
         Completed
      }

      public int Id { get; set; }
      public string Owner { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public DateTime StartTime { get; set; }
      public DateTime DueTime { get; set; }
      public Status TheStatus { get; set; }
      public string AssignTo { get; set; }
   }
}