using AutoFixture;
using Moq;
using NUnit.Framework;
using VagasCom.Domain.Interfaces.Repositories;
using VagasCom.Domain.Interfaces.Services;
using VagasCom.Domain.Models;
using VagasCom.Domain.Services;

namespace VagasCom.Test.ServicesTest
{
    public class AplicationnsServiceTest
    {
        private IApplicationsService service;
        private Mock<IApplicationsRespository> _applicationsRepository;
        private Fixture fixture;
        [SetUp]
        public void Setup()
        {
            _applicationsRepository = new Mock<IApplicationsRespository>();
            service = new ApplicationsService(_applicationsRepository.Object);
            fixture = new Fixture();
        }

        [Test]
        public void TestInsertApplication()
        {
            Application application = fixture.Create<Application>();
            _applicationsRepository.Setup(x => x.ApplicationInsert(application)).Returns(true);

            bool applicationInserted = service.ApplicationInsert(application);

            if (!applicationInserted)
                Assert.Fail();

            _applicationsRepository.VerifyAll();
            Assert.Pass();
        }
    }
}
