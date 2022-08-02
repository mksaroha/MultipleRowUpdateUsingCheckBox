using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MultipleRowUpdateUsingCheckBox.Models
{
    public class AppContext:DbContext
    {
        public AppContext():base("DefaultConnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
    
}