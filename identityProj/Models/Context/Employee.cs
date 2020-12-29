using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace identityProj.Models.Context
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
       
        public string Title { get; set; }
        public int Age { get; set; }
    }
}
