using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class Employs
    {
        public String firstName, lastName, address, email, phoneNumber, Id;
        public int salary;


        public Employs(string firstName, string lastName, string address, string email, string id, string phoneNumber, int salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.email = email;
            Id = id;
            this.phoneNumber = phoneNumber;
            this.salary = salary;
        }

        public override string ToString()
        {
            return String.Format("firstName: {0}\nlastName: {1}\nID: {2}\n Salary: {4}", firstName, lastName, Id, salary);
        }
    }
}
