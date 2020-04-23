using Dapper;
using VagasCom.Domain.Interfaces.Repositories;
using VagasCom.Domain.Models;

namespace VagasCom.Domain.Repositories
{
    /// <summary>
    /// Repository to management the access to People in the database
    /// </summary>
    internal class PeopleRepository : BaseRepository, IPeopleRepository
    {
        /// <summary>
        /// Insert a new Person
        /// </summary>
        /// <param name="person">The Person to insert</param>
        /// <returns>the id of the Person inserted</returns>
        public int PersonInsert(Person person)
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                int result = cnn.QuerySingle<int>(
                    @"
                    INSERT INTO [People]
                               ([Name]
                               ,[Profession]
                               ,[Location]
                               ,[Level])
                         VALUES
                               (@Name
                               ,@Profession
                               ,@Location
                               ,@Level);
                    select last_insert_rowid()
                    ",
                    new
                    {
                        person.Name,
                        person.Profession,
                        person.Location,
                        person.Level
                    });

                return result;
            }
        }
    }
}
