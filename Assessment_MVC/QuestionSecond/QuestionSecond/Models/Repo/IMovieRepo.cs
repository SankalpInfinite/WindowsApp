using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionSecond.Models
{
    public interface IMovieRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);  //a particular product
        void Insert(T obj);
        void Update(T obj);
        void Delete(Object Id);
        void Save();
    }
}
