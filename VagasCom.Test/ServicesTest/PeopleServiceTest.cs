using AutoFixture;
using Moq;
using NUnit.Framework;
using VagasCom.Domain.Interfaces.Repositories;
using VagasCom.Domain.Interfaces.Services;
using VagasCom.Domain.Models;
using VagasCom.Domain.Services;

namespace VagasCom.Test.ServicesTest
{
    [TestFixture]
    public class PeopleServiceTest
    {
        private IPeopleService service;
        private Mock<IPeopleRepository> _peopleRepository;
        private Fixture fixture;

        [SetUp]
        public void Setup()
        {
            _peopleRepository = new Mock<IPeopleRepository>();
            service = new PeopleService(_peopleRepository.Object);
            fixture = new Fixture();
        }

        [Test]
        public void TestInsertPerson()
        {
            Person person = fixture.Create<Person>();
            _peopleRepository.Setup(x => x.PersonInsert(person)).Returns(1);

            int personId = service.PersonInsert(person);

            if (personId != 1)
                Assert.Fail();

            _peopleRepository.VerifyAll();
            Assert.Pass();
        }
    }
}
