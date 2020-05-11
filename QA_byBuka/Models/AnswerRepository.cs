using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QA_byBuka.Models
{
    public class AnswerRepository : IAnswerRepository
    {
        string connection;
        public AnswerRepository(string connection)
        {
            this.connection = connection;
        }
        public void Create(Answer answer)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                var sqlQuery = "INSERT INTO Answer (id, problem, answer) VALUES(@id, @problem, @answer)";
                db.Execute(sqlQuery, answer);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                var sqlQuery = "DELETE FROM Answer WHERE id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Answer Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                return db.Query<Answer>("SELECT * FROM Answer WHERE id = @id", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Answer> GetAllAnswers(int problemid)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                return db.Query<Answer>("SELECT * FROM [Answer] WHERE problem = "+problemid.ToString()).ToList();
            }
        }

        public void Update(Answer answer)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                var sqlQuery = "UPDATE Answer SET problem = @problem, answer = @answer";
                db.Execute(sqlQuery, answer);
            }
        }
    }
}