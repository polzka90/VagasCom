using System;
using System.Collections.Generic;
using System.Text;
using VagasCom.Domain.Interfaces.Repositories;
using VagasCom.Domain.Interfaces.Services;
using VagasCom.Domain.Models;

namespace VagasCom.Domain.Services
{
    public class ApplicationsService : IApplicationsService
    {
        private readonly IApplicationsRespository _applicationsRepository;
        public ApplicationsService(IApplicationsRespository applicationsRepository)
        {
            _applicationsRepository = applicationsRepository;
        }

        public bool ApplicationInsert(Application application)
        {
            return _applicationsRepository.ApplicationInsert(application);
        }
    }
}
