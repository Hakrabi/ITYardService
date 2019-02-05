using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using ITYardService.common;
using ITYardService.Models;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ITYardService.Repository
{
    public class GeneralRepository // : IRepository
    {
        public static Dictionary<Guid, object> _general = new Dictionary<Guid, object>();

      /*  public List<object> All()
        {
            return _general.Keys.
        }*/

        public void Insert(object obj)
        {


            EntityBase Entity = obj as EntityBase;
            if (Entity.Validate())
            {
                _general.Add(Entity.Id, Entity);
                Logger.LogInfo($"Customer {Entity.Id} was inserted");

                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(object[]));

                using (FileStream fs = new FileStream("object.json", FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, obj);
                }
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