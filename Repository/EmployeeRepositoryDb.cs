using FirstCrud_Operation.Data;
using FirstCrud_Operation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCrud_Operation.Repository
{
    public class EmployeeRepositoryDb : IEmployeeRepository

    {
        public EmployeeDbcontext _dbcontext;


        public EmployeeRepositoryDb( EmployeeDbcontext context)
        {
            _dbcontext = context;
        }
        public bool AddEmployee(Employee employee)
        {
            _dbcontext.Employees.Add(employee);
            _dbcontext.SaveChanges();
            return true;
        }

       

        public List<Employee> GetAll()
        {
            var allEmployees = _dbcontext.Employees.ToList();
            return allEmployees;
        }

        public bool DeleteEmployee(int Id)
        {
            
            var Employees = _dbcontext.Employees.Where(x => x.Id == Id).FirstOrDefault();
            _dbcontext.Remove(Employees);
            _dbcontext.SaveChanges();
            return true;  
        }

        public bool UpdateEmployee(Employee employee)
        {
            //var Employees = _dbcontext.Employees.Where(x => x.Id == Id).FirstOrDefault();
            _dbcontext.Update(employee);
            _dbcontext.SaveChanges();
            return true;
           
        }
    }

   
}
