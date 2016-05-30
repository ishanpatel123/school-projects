using CountDown.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountDown.Controllers
{
    public class ListController : Controller
    {
        //
        // GET: /List/

        public ActionResult Index()
        {
           
            return View();
        }

        //
        // GET: /List/Details/5

        public ActionResult Details(int id)
        {
           return View();
        }

        //
        // GET: /List/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /List/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /List/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // GET: /List/view/5
        public ActionResult View(int id)
        {
            var item = _items.Single(i => i.Id == id);

            return View(item);
        }

        //
        // POST: /List/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /List/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /List/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        static List<ToDoItem> _items = new List<ToDoItem>
        {
            new ToDoItem
            {
                Id = 1,
                Title = "Jeff",
                Description = "Roach",
                StartTime = DateTime.Now,
                DueTime = DateTime.Now,
                TheStatus = CountDown.Models.ToDoItem.Status.Completed
            },

             new ToDoItem
            {
                Id = 2,
                Title = "Martin",
                Description = "Barret",
                StartTime = DateTime.Now,
                DueTime = DateTime.Now,
                TheStatus = CountDown.Models.ToDoItem.Status.Completed
            }
        };

    }
}
