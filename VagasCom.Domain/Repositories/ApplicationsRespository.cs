using Dapper;
using System.Collections.Generic;
using System.Linq;
using VagasCom.Domain.Interfaces.Repositories;
using VagasCom.Domain.Models;

namespace VagasCom.Domain.Repositories
{
    /// <summary>
    /// Repository to management the access to Application in the database
    /// </summary>
    internal class ApplicationsRespository : BaseRepository, IApplicationsRespository
    {
        /// <summary>
        /// Insert a new Application
        /// </summary>
        /// <param name="application">The Application to insert</param>
        /// <returns>the id of the application inserted</returns>
        public bool ApplicationInsert(Application application)
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                int result = cnn.Execute(
                    @"
                    INSERT INTO [Applications]
                               (VacancyId
                               ,PersonId)
                         VALUES
                               (@VacancyId
                               ,@PersonId)
                    ",
                    new
                    {
                        application.VacancyId,
                        application.PersonId
                    });

                return result > 0; 
            }
        }

        public List<VacancyPersonApplication> ConsultApplications(int vacancyId)
        {
            

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                List<VacancyPersonApplication> result = cnn.Query<VacancyPersonApplication>(
                    @"
                    SELECT P.Id,P.Name,P.Profession,P.Location,P.Level FROM  People AS P
                    INNER JOIN Applications AS A ON P.Id = A.PersonId
                    WHERE A.VacancyId = @vacancyId
                    ",
                    new
                    {
                        vacancyId
                    }).ToList();

                return result;
            }
        }
    }
}
