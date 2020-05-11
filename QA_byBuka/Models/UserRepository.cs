using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QA_byBuka.Models
{
    public class UserRepository : IUserRepository
    {
        string connection;
        public UserRepository(string connection)
        {
            this.connection = connection;
        }
        public void Create(User user)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                var sqlQuery = "INSERT INTO [User] (id, login, password) VALUES(@id, @login, @password)";
                db.Execute(sqlQuery, user);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                var sqlQuery = "DELETE FROM [User] WHERE id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public User Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                return db.Query<User>("SELECT * FROM [User] WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                return db.Query<User>("SELECT * FROM [User]").ToList();
            }
        }

        public void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                var sqlQuery = "UPDATE [User] SET login = @login, password = @password";
                db.Execute(sqlQuery, user);
            }
        }
    }
}
