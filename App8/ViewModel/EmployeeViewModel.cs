using App8.Model;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System.IO;

namespace App8.ViewModel
{

    public class EmployeeViewModel
    {
        /* public EmployeeModel EmployeeModelSet { get; set; }

         public EmployeeViewModel()
         {
             EmployeeModelSet = new EmployeeModel
             {
                 Id = 1,
                 Name = "Cristan Josh Nuguid",
                 Email = "nuguidcj@gmail.com",
                 Address = "Angeles City"
             };

         }*/

        private Services.DatabaseContext getContext()
        {
            return new Services.DatabaseContext();
        }

        public int InsertEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employee.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        public async Task<List<EmployeeModel>> GetAllEmployee()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Employee.ToListAsync();
            return res;
        }
        public async Task<int> UpdateEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employee.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }

        public int DeleteEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employee.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }
    }
}
