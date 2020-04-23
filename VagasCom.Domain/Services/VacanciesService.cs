using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VagasCom.Domain.Interfaces.Repositories;
using VagasCom.Domain.Interfaces.Services;
using VagasCom.Domain.Models;
using VagasCom.Domain.Models.Graphs;

namespace VagasCom.Domain.Services
{
    public class VacanciesService : IVacanciesService
    {
        private readonly IVacanciesRepository _vacanciesRepository;
        private readonly IApplicationsRespository _applicationsRepository;
        public VacanciesService(IVacanciesRepository vacanciesRepository, IApplicationsRespository applicationsRepository)
        {
            _vacanciesRepository = vacanciesRepository;
            _applicationsRepository = applicationsRepository;
        }

        public int VacancyInsert(Vacancy vacancy)
        {
            return _vacanciesRepository.VacancyInsert(vacancy);
        }

        public List<VacancyPersonApplication> ConsultVacancyApplications(int vacancyId)
        {
            Vacancy vacancyInfo = _vacanciesRepository.VacancyConsult(vacancyId);

            List<VacancyPersonApplication> applications = _applicationsRepository.ConsultApplications(vacancyId);

            Graph graph = new Graph();
            var search = new GraphSearch();

            graph.AddPoint("A");
            graph.AddPoint("B");
            graph.AddPoint("C");
            graph.AddPoint("D");
            graph.AddPoint("E");
            graph.AddPoint("F");



            graph.AddConnection("A", "B", 5);
            graph.AddConnection("B", "C", 7);
            graph.AddConnection("B", "D", 3);
            graph.AddConnection("C", "E", 4);
            graph.AddConnection("D", "E", 10);
            graph.AddConnection("D", "F", 8);

            var Alldistances = search.FindAllRouteFromTheStart(graph, vacancyInfo.Location);

            foreach (VacancyPersonApplication vacancyPersonApplication in applications)
            {
                double distance = Alldistances[vacancyPersonApplication.Location];

                int N = 100 - 25 * (vacancyInfo.Level - vacancyPersonApplication.Level);

                int D = 0;

                if (distance <= 20 && distance > 15)
                    D = 25;
                else if (distance <= 15 && distance > 10)
                    D = 50;
                else if (distance <= 10 && distance > 5)
                    D = 75;
                else if (distance <= 5 && distance >= 0)
                    D = 100;

                vacancyPersonApplication.Score = (N + D) / 2;
            }

            return applications.OrderByDescending(i => i.Score).ToList();
        }
    }
}
