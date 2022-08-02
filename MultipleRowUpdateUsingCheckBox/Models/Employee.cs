using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultipleRowUpdateUsingCheckBox.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string City { get; set; }
        [Display(Name="Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}