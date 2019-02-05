using System;
using System.Collections.Generic;
using System.Text;

namespace ITYardService.Repository
{
    interface IGenericRepository<T>
    {
        IEnumerable<T> All();
        bool Insert(T entity);
        T GetById(Guid id);
        bool Update(Guid id, T entity);
        bool Delete(Guid id);
        void DisplayEntityInfo(Guid id);//
    }
}
