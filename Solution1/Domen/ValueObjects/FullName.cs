using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.ValueObjects
{
    public class FullName : BaseValueObjects
    {
        public FullName(string firstName, string lastName, string middleName) 
        { 
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }

        protected override BaseValueObjects DeepClone()
        {
            return new FullName(FirstName, LastName, MiddleName);
        }
    }
}
