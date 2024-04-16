using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.Entities;
using Domen.ValueObjects;
using AutoMapper;
namespace Application.Service
{
    internal class PersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public PersonGetByIdResponse GetById(Guid id)
        {
            var person = _personRepository.GetById(id);
            if (person == null)
            {
                throw new Exception();
            }
            // ToDo: Замаппить
            var response = _mapper.Map<PersonGetByIdResponse>(person);
            return response;
        }
        // ToDo: Описать PersonService до конца
    }
}
