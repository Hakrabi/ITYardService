using System;
using System.Collections.Generic;
using System.Text;
using ITYardService.Common;
using ITYardService.Models;


namespace ITYardService.Repository
{
    public class GeneralRepositoryJSON //: IRepository
    {

        public static Dictionary<Guid, object> _general = new Dictionary<Guid, object>();

       /* public List<object> All()
        {
            //return _general.Keys.
        }*/

        public void Insert(object obj)
        {
            EntityBase Entity = obj as EntityBase;
            if (Entity.Validate())
            {
                _general.Add(Entity.Id, Entity);
                Logger.LogInfo($"Customer {Entity.Id} was inserted");
            }
        }

        public object GetById(Guid id)
        {
            return _general[id];
        }

        public void Update(Guid id, object obj)
        {
            _general[id] = obj;
        }

        public void Delete(Guid id)
        {
            if (_general.ContainsKey(id))
            {
                _general.Remove(id);
                Logger.LogInfo($"User {id} was deleted");
                return;
            }
            Logger.LogError("Id not exist");
        }

        public void DisplayInfo(Guid id)
        {
            EntityBase Entity = _general[id] as EntityBase;
            Entity.DisplayEntityInfo();
        }


    }
}