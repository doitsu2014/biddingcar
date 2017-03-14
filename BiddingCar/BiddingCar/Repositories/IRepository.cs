using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingCar.Repositories
{
    interface IRepository<T> where T : class
    {
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void DeleteById(int id);
        T FindById(int id);

    }
}
