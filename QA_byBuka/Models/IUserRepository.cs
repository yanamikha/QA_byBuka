using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QA_byBuka.Models
{
    public interface IUserRepository
    {
        void Create(User user);
        void Delete(int id);
        User Get(int id);
        IEnumerable<User> GetAllUsers();
        void Update(User user);
    }
}
