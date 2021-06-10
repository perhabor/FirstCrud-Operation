using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCrud_Operation.Models
{
    public class EmployeeViewModel
    {
        public ICollection<Employee> Employees { get; set; }
        public string address { get; set; }
        public string email { get; set; }
    }
}
