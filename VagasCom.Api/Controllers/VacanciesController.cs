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

namespace VagasCom.Api.Controllers
{
    [Route("v1/vagas/")]
    public class VacanciesController : Controller
    {
        private readonly IVacanciesService _vacanciesService;
        private readonly IMapper _mapper;
        public VacanciesController(IVacanciesService vacanciesService, IMapper mapper)
        {
            _vacanciesService = vacanciesService;
            _mapper = mapper;
        }

        [HttpPost]
        public VacanciesInsertResponse Index([FromBody] VacanciesInsertRequest rq)
        {
            VacanciesInsertResponse rsp = new VacanciesInsertResponse();

            try
            {
                Vacancy vacancy = _mapper.Map<Vacancy>(rq);
                vacancy.Id = _vacanciesService.VacancyInsert(vacancy);

                rsp = new VacanciesInsertResponse() { ErrorNumber = 0, Message = "Vaga Cadastrada com Successo com o numero: " + vacancy.Id, Data = new { id_vaga = vacancy.Id } };
            }
            catch(Exception ex)
            {
                rsp = new VacanciesInsertResponse() { ErrorNumber = 1, Message = "Erro no servidor" };
            }

            return rsp;
        }

        [Route("{VacancyId:int}/candidaturas/ranking"),HttpGet]
        public List<VacancyPersonApplicationResponse> VacancyConsultApplications(int VacancyId)
        {
            List<VacancyPersonApplicationResponse> applications = _mapper.Map<List<VacancyPersonApplicationResponse>>(_vacanciesService.ConsultVacancyApplications(VacancyId));

            return applications;
        }

    }
}