using AutoFixture;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using VagasCom.Domain.Interfaces.Repositories;
using VagasCom.Domain.Interfaces.Services;
using VagasCom.Domain.Models;
using VagasCom.Domain.Services;

namespace VagasCom.Test.ServicesTest
{
    [TestFixture]
    public class VacanciesServiceTest
    {
        private IVacanciesService service;
        private Mock<IVacanciesRepository> _vacanciesRepository;
        private Mock<IApplicationsRespository> _applicationsRepository;
        private Fixture fixture;
        [SetUp]
        public void Setup()
        {

            _vacanciesRepository = new Mock<IVacanciesRepository>();
            _applicationsRepository = new Mock<IApplicationsRespository>();
            service = new VacanciesService(_vacanciesRepository.Object, _applicationsRepository.Object);
            fixture = new Fixture();
        }

        [Test]
        public void TestInsertVacancy()
        {
            Vacancy vacancy = fixture.Create<Vacancy>();
            _vacanciesRepository.Setup(x => x.VacancyInsert(vacancy)).Returns(1);

            int vacancyId = service.VacancyInsert(vacancy);

            if(vacancyId != 1)
                Assert.Fail();

            _vacanciesRepository.VerifyAll();
            Assert.Pass();
        }


        [TestCase("A", 1, "B", 2, 112)]
        [TestCase("C", 1, "F", 4, 100)]
        [TestCase("D", 5, "A", 3, 62)]
        public void TestScoreVacancyApplication(string vacancyLocation, int vacancyLevel, string applicationLocation, int applicationLevel , int expected)
        {
            Vacancy vacancy = fixture.Create<Vacancy>();
            vacancy.Location = vacancyLocation;
            vacancy.Level = vacancyLevel;
            int N = 100 - 25 * (vacancyLevel - applicationLevel);
            VacancyPersonApplication application = fixture.Create<VacancyPersonApplication>();

            application.Location = applicationLocation;
            application.Level = applicationLevel;

            List<VacancyPersonApplication> list = new List<VacancyPersonApplication>();

            list.Add(application);

            _vacanciesRepository.Setup(x => x.VacancyConsult(vacancy.Id)).Returns(vacancy);

            _applicationsRepository.Setup(x => x.ConsultApplications(vacancy.Id)).Returns(list);

            var applications = service.ConsultVacancyApplications(vacancy.Id);

            if (applications.Count <= 0)
                Assert.Fail();

            if (applications.FirstOrDefault().Score != expected)
                Assert.Fail();

            _vacanciesRepository.VerifyAll();
        }
    }
}
