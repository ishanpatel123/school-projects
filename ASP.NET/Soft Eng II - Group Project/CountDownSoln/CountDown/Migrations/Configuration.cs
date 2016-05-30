namespace CountDown.Migrations
{
    using CountDown.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CountDown.Models.CountDownDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CountDown.Models.CountDownDb context)
        {

            context.Items.AddOrUpdate(items => items.Title, 
                                         new ToDoItem {Title = "Take out the trash", Description = "Please take out the trash tomorrow...", StartTime = new DateTime(2015,03,18,23,59,59), DueTime = new DateTime(2015,03,19,23,59,59)}

                );

            context.Users.AddOrUpdate(user => user.Email,
               new RegisteredUser
               {
                   Firstname = "Jeff",
                   Lastname = "Roach",
                   Email = "abc@abc.com",
                   Password = "1234",
                   OwnedItems = new List<ToDoItem> {
                         new ToDoItem {Title = "Take out the trash", Description = "Please take out the trash tomorrow...", StartTime = new DateTime(2015,03,18,23,59,59), DueTime = new DateTime(2015,03,19,23,59,59)},
                         new ToDoItem {Title = "Wash the dog", Description = "Please wash the dog tomorrow...", StartTime = new DateTime(2015,03,18,23,59,59), DueTime = new DateTime(2015,03,19,23,59,59)}
                   }
               },



               new RegisteredUser
               {
                   Firstname = "Jane",
                   Lastname = "Doe",
                   Email = "bbb@bbb.com",
                   Password = "2345",
                   OwnedItems = new List<ToDoItem> {
                         new ToDoItem {Title = "Take out the trash2", Description = "Please take out the trash tomorrow...", StartTime = new DateTime(2015,03,18,23,59,59), DueTime = new DateTime(2015,03,19,23,59,59)},
                         new ToDoItem {Title = "Wash the dog2", Description = "Please wash the dog tomorrow...", StartTime = new DateTime(2015,03,18,23,59,59), DueTime = new DateTime(2015,03,19,23,59,59)}
                   }
               }

               );
        }
    }
}