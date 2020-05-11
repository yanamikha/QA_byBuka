using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace QA_byBuka.Models
{
    public class ProblemRepository : IProblemRepository
    {
        string connection;
        public ProblemRepository(string connection)
        {
            this.connection = connection;
        }
        public void Create(Problem problem)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                var sqlQuery = "INSERT INTO [Problem] (id, author, problem, isPublic, canAddAnswersEverybody, deadline, reference, active, creationDate, maxCountOfAnswers) VALUES(@id, @author, @problem, @isPublic, @canAddAnswersEverybody, @deadline, @reference, @active, @creationDate, @maxCountOfAnswers)";
                db.Execute(sqlQuery, problem);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                var sqlQuery = "DELETE FROM [Problem] WHERE id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Problem Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                return db.Query<Problem>("SELECT * FROM [Problem] WHERE id = @id", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Problem> GetAllMyProblems(int author = 1)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                return db.Query<Problem>("SELECT * FROM [Problem] WHERE author = 1").ToList();
            }
        }

        public IEnumerable<Problem> GetAllProblems()
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                return db.Query<Problem>("SELECT * FROM [Problem]").ToList();
            }
        }

        public void Update(Problem problem)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                var sqlQuery = "UPDATE [Problem] SET author = @author, problem=@problem, isPublic = @isPublic, canAddAnswersEverybody = @canAddAnswersEverybody, deadline = @deadline, reference = @reference,  = @active, creationDate = @creationDate, maxCountOfAnswers = @maxCountOfAnswers WHERE id = @id";
                db.Execute(sqlQuery, problem);
            }
        }
    }
}
