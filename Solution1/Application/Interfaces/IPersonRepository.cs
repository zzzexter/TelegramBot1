using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.Entities;

namespace Application.Interfaces
{
    internal interface IPersonRepository : IRepository<Pers>
    {
        public List<CustomField<string>> GetCustomFields();
    }
}
