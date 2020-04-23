using System;
using System.Collections.Generic;
using System.Text;
using VagasCom.Domain.Interfaces.Repositories;
using VagasCom.Domain.Interfaces.Services;
using VagasCom.Domain.Models;

namespace VagasCom.Domain.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;
        public PeopleService(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public int PersonInsert(Person person)
        {
            return _peopleRepository.PersonInsert(person);
        }
    }
}
