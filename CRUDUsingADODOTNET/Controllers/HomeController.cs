using CRUDUsingADODOTNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDUsingADODOTNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDataAccessLayer dal;
        public HomeController()
        {
            dal = new EmployeeDataAccessLayer();
        }

        public IActionResult Index()
        {
            List<Employee> emp = dal.GetAllEmployees();
            return View(emp);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            try
            {
                dal.CreateEmployees(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        public IActionResult Edit(int id)
        {
            Employee emp = dal.GetEmployeeByID(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            try
            {
                dal.UpdateEmployees(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Details(int id)
        {
            Employee emp = dal.GetEmployeeByID(id);
            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            Employee emp = dal.GetEmployeeByID(id);
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteEmployeeByID(int id)
        {
            try
            {
                dal.DeleteEmployeeByID(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
