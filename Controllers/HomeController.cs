using FirstCrud_Operation.Data;
using FirstCrud_Operation.Models;
using FirstCrud_Operation.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCrud_Operation.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<UserLoginViewModel> users = new List<UserLoginViewModel>();
        private readonly IEmployeeRepository _dbcontext;


        public HomeController(IEmployeeRepository employeesrepo)
        {
            _dbcontext = employeesrepo;
            UserLoginViewModel model = new UserLoginViewModel();
            model.FirstName = "Samuel";
            model.LastName = "Ojo";
            model.Email = "pammy0@gmail.com";
            model.PassWord = "whitelady";
            users.Add(model);
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(UserLoginViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var user = users.Find(x => x.Email == viewModel.Email && x.PassWord == viewModel.PassWord);
                if (user != null)
                {
                    TempData["StatusMessage"] = "Welcome " + user.FirstName + " " + user.LastName;
                    return RedirectToAction("Register");
                }
                else
                {
                    TempData["StatusMessage"] = "Invalid Username or Password supplied!";
                    return View();
                }

            }
            //ViewBag.message = TempData["StatusMessage"];
            return View();
        }

        [HttpGet]
        public IActionResult Register(int id = 0)
        {
            if (id <= 0)
                return View();

            var data = _dbcontext.GetAll().Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                return View(data);
            }
            else
            {
                return View("GetDetails");
            }
        }

        [HttpPost]
        public IActionResult Register(Employee model)
        {


            if (ModelState.IsValid)
            {
                if (model.Id > 0)

                {
                    _dbcontext.UpdateEmployee(model);
                }

                else
                {
                    _dbcontext.AddEmployee(model);
                }


            }
            return RedirectToAction("GetDetails");
        }

        public IActionResult GetDetails(string address = "", string email = "")
        {

            

            EmployeeViewModel employeeCollection = new EmployeeViewModel();
            ViewBag.address = _dbcontext.GetAll().Select(s => s.Address).Distinct();
            ViewBag.email = _dbcontext.GetAll().Select(e => e.Email).Distinct();

            //employeeCollection = new EmployeeViewModel
            //{
            //    Employees = String.IsNullOrEmpty(address)? _dbcontext.GetAll() : _dbcontext.GetAll().Where(x=>x.Address == address).ToList()
            //};

            if (String.IsNullOrEmpty(address) && (string.IsNullOrEmpty(email)))
            {

                // EmployeeViewModel employeeCollection = null;
                employeeCollection.Employees = _dbcontext.GetAll();
            }
            else
            {
                employeeCollection.Employees = _dbcontext.GetAll().Where(a => a.Address == address || a.Email ==email).ToList();
               
            }


            return View(employeeCollection);
        }

       


        public IActionResult DeleteEmployee(int id)
        {
            var data = _dbcontext.GetAll().Where(x => x.Id == id).FirstOrDefault().Id;
            if (data != 0)
            {
                _dbcontext.DeleteEmployee(data);

                return RedirectToAction("GetDetails");

            }
            else
            {
                return NotFound();
            }


        }


    }



}





