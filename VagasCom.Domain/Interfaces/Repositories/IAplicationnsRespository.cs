using System;
using System.Collections.Generic;
using System.Text;
using VagasCom.Domain.Models;

namespace VagasCom.Domain.Interfaces.Repositories
{
    public interface IApplicationsRespository
    {
        bool ApplicationInsert(Application application);
        List<VacancyPersonApplication> ConsultApplications(int vacancyId);
    }
}
