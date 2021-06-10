using FirstCrud_Operation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCrud_Operation.Repository
{
    public interface IEmployeeRepository
    {
        

        List<Employee> GetAll();
        
        bool AddEmployee(Employee employee);
        
        bool DeleteEmployee(int Id);

        bool UpdateEmployee(Employee employee);
        


    }
}
