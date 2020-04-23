using System;
using System.Collections.Generic;
using System.Text;
using VagasCom.Domain.Models;

namespace VagasCom.Domain.Interfaces.Repositories
{
    public interface IVacanciesRepository
    {
        int VacancyInsert(Vacancy vacancy);
        Vacancy VacancyConsult(int vacancyId);
    }
}
