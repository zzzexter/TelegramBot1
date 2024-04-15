using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.ValueObjects;
using Domen.Primitivies;

namespace Application.DTOs
{
    public class PersonGetByIdResponse
    {
        public FullName FullName { get; private set; }
        public DateTime BirthDay { get; private set; }
        public int Age => DateTime.Now.Year - BirthDay.Year;
        public Gender Gender { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Telegram { get; private set; }
    }
}
