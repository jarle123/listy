using Listy.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Listy.DataAccess
{
    public class ListyDbContext : DbContext
    {
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<ListyList> ListyLists { get; set; }

        public string DbPath { get; private set; }

        public ListyDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}.listy.db";
        }

        //Configures EF to create a SQLITE db file in the "local" folder;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseSqlite($"Data Source={DbPath}");

        // Seed the DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListyList>()
                .HasMany(l => l.ListItems)
                .WithOne(li => li.ListyList)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ListyList>().HasData(
                new ListyList { ListyListId = 1, Title = "Groceries" },
                new ListyList { ListyListId = 2, Title = "Listy 2do frontend" },
                new ListyList { ListyListId = 3, Title = "Listy 2do backend" },
                new ListyList { ListyListId = 5, Title = "Vacation packing list" }
            );

            modelBuilder.Entity<ListItem>().HasData(

                // Grocery list
                new ListItem { ListyListId = 1, ListItemId = 1, Content = "Milk" },
                new ListItem { ListyListId = 1, ListItemId = 2, Content = "Bread" },
                new ListItem { ListyListId = 1, ListItemId = 3, Content = "Chocolate" },

                // 2do frontend
                new ListItem { ListyListId = 2, ListItemId = 203, Content = "Add notifications / reminderds" },
                new ListItem { ListyListId = 2, ListItemId = 204, Content = "Add notification / popover with status ie." },
                new ListItem { ListyListId = 2, ListItemId = 205, Content = "Edit list item" },
                new ListItem { ListyListId = 2, ListItemId = 206, Content = "Implement login" },


                // 2do backend
                new ListItem { ListyListId = 3, ListItemId = 301, Content = "Add auth" },
                new ListItem { ListyListId = 3, ListItemId = 302, Content = "implement board" },
                new ListItem { ListyListId = 3, ListItemId = 303, Content = "Implementer DTO" },
                new ListItem { ListyListId = 3, ListItemId = 304, Content = "Add counter" },



                // Vacation packing list
                new ListItem { ListyListId = 5, ListItemId = 501, Content = "T-shirt" },
                new ListItem { ListyListId = 5, ListItemId = 502, Content = "Sweater" },
                new ListItem { ListyListId = 5, ListItemId = 503, Content = "Socks" }

            );
        }
    }
}
