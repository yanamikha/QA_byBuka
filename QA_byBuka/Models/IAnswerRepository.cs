using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QA_byBuka.Models
{
    interface IAnswerRepository
    {
        void Create(Answer answer);
        void Delete(int id);
        Answer Get(int id);
        IEnumerable<Answer> GetAllAnswers(int problem);
        void Update(Answer answer);
    }
}
