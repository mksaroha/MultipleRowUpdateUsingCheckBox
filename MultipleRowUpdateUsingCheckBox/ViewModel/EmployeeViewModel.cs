using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultipleRowUpdateUsingCheckBox.Models;

namespace MultipleRowUpdateUsingCheckBox.ViewModel
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public IEnumerable<Department> DepartmentList { get; set; }
    }
}