using App8.Model;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System.IO;

namespace App8.Services
{
    public class DatabaseContext:DbContext
    {
        public DbSet<EmployeeModel> Employee { get; set; }

        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"Employee.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
