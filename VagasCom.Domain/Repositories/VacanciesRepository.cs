using Dapper;
using VagasCom.Domain.Interfaces.Repositories;
using VagasCom.Domain.Models;

namespace VagasCom.Domain.Repositories
{
    /// <summary>
    /// Repository to management the access to Vacancies in the database
    /// </summary>
    internal class VacanciesRepository : BaseRepository, IVacanciesRepository
    {
        /// <summary>
        /// Insert a new Vacancy
        /// </summary>
        /// <param name="vacancy">The Vacancy to insert</param>
        /// <returns>the id of the Vacancy inserted</returns>
        public int VacancyInsert(Vacancy vacancy)
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                int result = cnn.QuerySingle<int>(
                    @"
                    INSERT INTO [Vacancies]
                               ([Company]
                               ,[Title]
                               ,[Description]
                               ,[Location]
                               ,[Level])
                         VALUES
                               (@Company
                               ,@Title
                               ,@Description
                               ,@Location
                               ,@Level);
                    select last_insert_rowid()
                    ", 
                    new { 
                        vacancy.Company, 
                        vacancy.Title, 
                        vacancy.Description, 
                        vacancy.Location, 
                        vacancy.Level 
                    });

                return result;
            }
        }

        public Vacancy VacancyConsult(int vacancyId)
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                Vacancy result = cnn.QuerySingle<Vacancy>(
                    @"
                    SELECT * FROM [Vacancies] 
                    WHERE Id = @vacancyId
                    ",
                    new
                    {
                        vacancyId
                    });

                return result;
            }
        }
    }
}
