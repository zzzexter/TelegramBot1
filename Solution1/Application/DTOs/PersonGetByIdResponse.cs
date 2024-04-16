using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.ValueObjects;
using Domen.Primitivies;

namespace Application.DTOs
{
    /// <summary>
    /// Скачать Docker DataGrip 
    /// </summary>
    public class PersonGetByIdResponse
    {
        protected Guid Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public DateTime BirthDay { get; private set; }

        public int Age;
        public string Gender { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Telegram { get; private set; }
    }
}
