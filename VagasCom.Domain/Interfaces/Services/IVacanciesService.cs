using System.Collections.Generic;
using VagasCom.Domain.Models;

namespace VagasCom.Domain.Interfaces.Services
{
    public interface IVacanciesService
    {
        int VacancyInsert(Vacancy vacancy);
        List<VacancyPersonApplication> ConsultVacancyApplications(int vacancyId);
    }
}
