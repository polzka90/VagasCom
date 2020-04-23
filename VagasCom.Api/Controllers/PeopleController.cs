using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VagasCom.Api.Models.Response;
using VagasCom.Domain.Interfaces.Services;
using VagasCom.Domain.Models;
using VagasCom.Domain.Models.Request;
using VagasCom.Domain.Services;

namespace VagasCom.Api.Controllers
{
    [Route("v1/pessoas")]
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly IMapper _mapper;
        public PeopleController(IPeopleService peopleService, IMapper mapper)
        {
            _peopleService = peopleService;
            _mapper = mapper;
        }
        [HttpPost]
        public PeopleInsertResponse Index([FromBody]PeopleInsertRequest rq)
        {
            PeopleInsertResponse rsp = new PeopleInsertResponse();

            try
            {
                Person person = _mapper.Map<Person>(rq);
                person.Id = _peopleService.PersonInsert(person);

                rsp = new PeopleInsertResponse() { ErrorNumber = 0, Message = "Perfil criado com successo com o numero: " + person.Id, Data = new { id_pessoa = person.Id } };
            }
            catch (Exception ex)
            {
                rsp = new PeopleInsertResponse() { ErrorNumber = 1, Message = "Erro no servidor" };
            }

            return rsp;
        }
    }
}