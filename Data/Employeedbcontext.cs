using FirstCrud_Operation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCrud_Operation.Data
{
    public class EmployeeDbcontext : DbContext

    {
        public EmployeeDbcontext(DbContextOptions<EmployeeDbcontext> options) : base(options)
        {

        }
       

        public DbSet<Employee> Employees{ get; set; }



       
    }
}
