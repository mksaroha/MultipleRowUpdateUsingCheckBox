using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultipleRowUpdateUsingCheckBox.Models;
using MultipleRowUpdateUsingCheckBox.ViewModel;
using System.Data.Entity;

namespace MultipleRowUpdateUsingCheckBox.Controllers
{
    public class EmployeeController : Controller
    {
        AppContext _context = new AppContext();
        // GET: Employee
        public ActionResult Index(string option,string search)
        {
             
            var viewModel = new EmployeeViewModel();

            if(option=="Name")
            {
                viewModel.EmployeeList = _context.Employees.Include(x => x.Department).Where(x=>x.Name==search).ToList();
                viewModel.DepartmentList = _context.Departments.ToList();
            }

            else if(option=="City")
            {
                viewModel.EmployeeList = _context.Employees.Include(x => x.Department).Where(x => x.City == search).ToList();
                viewModel.DepartmentList = _context.Departments.ToList();
            }

            else
            {
                viewModel.EmployeeList = _context.Employees.Include(x => x.Department).ToList();
                viewModel.DepartmentList = _context.Departments.ToList();
            }

            return View(viewModel);

            //var viewModel = new EmployeeViewModel
            //{
            //    EmployeeList = _context.Employees.Include(x=>x.Department).ToList(),
            //    DepartmentList=_context.Departments.ToList()
            //};
            //return View(viewModel);
        }

        public ActionResult SaveEmployee(Employee employee)
        {
            using (AppContext _context=new AppContext())
            {
                try
                {
                    if(ModelState.IsValid)
                    {
                        _context.Employees.Add(employee);                        
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(List<Employee> employee)
        {
            using (AppContext _contex = new AppContext())
            {
                foreach (var i in employee)
                {
                    try
                    {
                        var k = _contex.Employees.Where(x => x.Id == i.Id).FirstOrDefault();
                        if (k != null)
                        {
                            k.Name = i.Name;
                            k.Salary = i.Salary;
                            k.City = i.City;
                            k.DepartmentId = i.DepartmentId;
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
                _contex.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (AppContext _context = new AppContext())
            {
                try
                {
                    var result = _context.Employees.Where(x=>x.Id==id).FirstOrDefault();
                    _context.Employees.Remove(result);
                }
                catch (Exception)
                {

                    throw;
                }
                _context.SaveChanges();               
            }
            return RedirectToAction("Index");
        }

        public JsonResult Search(Employee c)
        {
            var data = _context.Employees.Include(x=>x.Department).Where(x => x.Name == c.Name).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}