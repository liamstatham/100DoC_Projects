using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string first,
                                   string last,
                                   bool isSupervisor)
        {
            Person ret = null;
            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    ret = new Supervisor();
                }
                else
                {
                    ret = new Employee();
                }

                //assign variables
                ret.FirstName = first;
                ret.LastName = last;
            }

            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "Liam", LastName = "Statham"});
            people.Add(new Person() { FirstName = "James", LastName = "Statham" });
            people.Add(new Person() { FirstName = "Emma", LastName = "Statham" });

            return people;
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Liam", "Statham", true));
            people.Add(CreatePerson("Emma", "Statham", false));

            return people;
        }

        public List<Person> GetEmployees()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("James", "Statham", false));
            people.Add(CreatePerson("Freddie", "Statham", false));

            return people;
        }

        public List<Person> GetSupervisorsAndEmployees()
        {
            List<Person> people = new List<Person>();

            people.AddRange(GetEmployees());
            people.AddRange(GetSupervisors());

            return people;

        }
    }
}
