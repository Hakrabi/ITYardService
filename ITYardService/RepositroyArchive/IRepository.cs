using System;
using System.Collections.Generic;
using System.Text;

namespace ITYardService.Repository
{
    interface IRepository
    {
        List<object> All();
        void Insert(object obj);
        object GetById(Guid id);
        void Update(Guid id, object obj);
        void Delete(Guid id);
        void DisplayEntityInfo(Guid id);
    }
}
