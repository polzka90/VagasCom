using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace VagasCom.Domain.Repositories
{
    internal class BaseRepository
    {
        internal string DbFile
        {
            get { return Environment.CurrentDirectory + "\\VagasComDb.sqlite"; }
        }

        internal SQLiteConnection SimpleDbConnection()
        {
            return new SQLiteConnection("Data Source=" + DbFile);
        }

        internal  void CreateSchemaDatabase()
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();

                //cnn.Execute(@"DROP TABLE IF EXISTS Vacancies;
                //              DROP TABLE IF EXISTS PEOPLE;
                //              DROP TABLE IF EXISTS Applications;
                //            ");


                cnn.Execute(@"
                                  CREATE TABLE IF NOT EXISTS Vacancies(
                    	          [Id] INTEGER PRIMARY KEY AUTOINCREMENT,
                    	          [Company] [nvarchar](500) NULL,
                    	          [Title] [nvarchar](500) NULL,
                    	          [Description] [nvarchar](500) NULL,
                    	          [Location] [nchar](1) NOT NULL,
                    	          [Level] [int] NOT NULL
                                  ) 
                            ");

                cnn.Execute(@"
                                CREATE TABLE IF NOT EXISTS [People](
                            	[Id] INTEGER PRIMARY KEY AUTOINCREMENT,
                            	[Name] [nvarchar](500) NULL,
                            	[Profession] [nvarchar](500) NULL,
                            	[Location] [nchar](1) NOT NULL,
                            	[Level] [int] NOT NULL
                                ) 
                            ");

                cnn.Execute(@"
                                CREATE TABLE IF NOT EXISTS [Applications](
                            	[VacancyId] [int] NOT NULL,
                            	[PersonId] [int] NOT NULL,
                                PRIMARY KEY (VacancyId, PersonId)
                                ) 
                           ");
            }
        }
    }
}
