using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VagasCom.Api.Models.Request;
using VagasCom.Api.Models.Response;
using VagasCom.Domain.Interfaces.Services;
using VagasCom.Domain.Models;

namespace VagasCom.Api.Controllers
{
    [Route("v1/candidaturas")]
    public class ApplicationsController : Controller
    {
        private readonly IApplicationsService _applicationsService;
        private readonly IMapper _mapper;
        public ApplicationsController(IApplicationsService applicationsService, IMapper mapper)
        {
            _applicationsService = applicationsService;
            _mapper = mapper;
        }
        [HttpPost]
        public ApplicationInsertResponse Index([FromBody]ApplicationInsertRequest rq)
        {
            ApplicationInsertResponse rsp = new ApplicationInsertResponse();

            try
            {
                Application application = _mapper.Map<Application>(rq);
                bool insert =  _applicationsService.ApplicationInsert(application);

                if (insert)
                    rsp = new ApplicationInsertResponse() { ErrorNumber = 0, Message = "Cadidatura cadastrada com successo Boa sorte", Data = new { successo = insert } };
                else
                    rsp = new ApplicationInsertResponse() { ErrorNumber = 2, Message = "Não foi possivel completar sua candidatura por causa de um erro", Data = new { successo = insert } };
            }
            catch (Exception ex)
            {
                rsp = new ApplicationInsertResponse() { ErrorNumber = 1, Message = "Erro no servidor" };
            }

            return rsp;
        }
    }
}