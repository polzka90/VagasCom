using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VagasCom.Api.Models.Request;
using VagasCom.Api.Models.Response;
using VagasCom.Domain.Models;
using VagasCom.Domain.Models.Request;

namespace VagasCom.Api.Models.Profiles
{
    public class VagasComApiProfile : Profile
    {
        public VagasComApiProfile()
        {
            CreateMap<ApplicationInsertRequest, Application>().ReverseMap();
            CreateMap<PeopleInsertRequest, Person>().ReverseMap();
            CreateMap<VacanciesInsertRequest, Vacancy>().ReverseMap();
            CreateMap<VacancyPersonApplication, VacancyPersonApplicationResponse>().ReverseMap();
        }
    }
}
