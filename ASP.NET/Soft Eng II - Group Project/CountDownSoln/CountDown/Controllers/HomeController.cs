using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CountDown.Models;

namespace CountDown.Controllers
{
   public class HomeController : Controller
   {
      private CountDownDb _db = new CountDownDb();

      public ActionResult Index()
      {
          var model =
            from i in _items
            orderby i.DueTime
            select i;

          return View(model);
      }

      public ActionResult About()
      {
         ViewBag.Message = "Your app description page.";

         return View();
      }

      public ActionResult View(int id)
      {
          var item = _items.Single(i => i.Id == id);
          

          return View(item);
      }

      public ActionResult Contact()
      {
         ViewBag.Message = "Your contact page.";

         return View();
      }

      protected override void Dispose(bool disposing)
      {
         if (_db != null)
         {
            _db.Dispose();
         }
         base.Dispose(disposing);
      }

      static List<ToDoItem> _items = new List<ToDoItem>
        {
            new ToDoItem
            {
                Owner = "Roach@goldmail.etsu.edu",
                AssignTo = "Self",
                Id = 1,
                Title = "Grade Test",
                Description = "Grade CSCI 3350 tests",
                StartTime = new DateTime(2015,3,23, 4, 0, 0),
                DueTime = new DateTime(2015,3,23, 4, 0, 0),
                TheStatus = CountDown.Models.ToDoItem.Status.Completed
            },

             new ToDoItem
            {
                Owner = "Roach@goldmail.etsu.edu",
                AssignTo = "Self",
                Id = 2,
                Title = "Prep Lab",
                Description = "Prepare Lab 471",
                StartTime = new DateTime(2015,3,23, 9, 0, 0),
                DueTime = new DateTime(2015,3,23, 9, 0, 0),
                TheStatus = CountDown.Models.ToDoItem.Status.WaitingForOther
            }
        };
   }
}
