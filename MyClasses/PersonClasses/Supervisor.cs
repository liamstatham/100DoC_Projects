using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.PersonClasses
{
    public class Supervisor : Person
    {
        public List<Employee> Employees { get; set; }
    }
}
