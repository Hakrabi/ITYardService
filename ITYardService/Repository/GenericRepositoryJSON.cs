using ITYardService.common;
using ITYardService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ITYardService.Repository
{
    class GenericRepositoryJSON<T> : IGenericRepository<T> where T : EntityBase
    {
        
        public static Dictionary<Guid, T > _general = new Dictionary<Guid, T>();

        public void Serialize()
        {
            //var customer1 = new Customer(Guid.NewGuid(), "Dmitry");

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Dictionary<Guid, T>));
            FileStream buffer = new FileStream($"C:\\ITYardService\\ITYardService\\{typeof(T).Name}.json", FileMode.OpenOrCreate);
            // FileStream buffer = File.Create($"object.json");
            jsonSerializer.WriteObject(buffer, _general);
            //jsonSerializer.WriteObject(buffer, Entity);

            buffer.Close();

            /*// Создаём сериалайзер
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Customer));
            // Создаём поток
            FileStream buffer = File.Create("C:\\ITYardService\\ITYardService\\room.json");
            // Сериализуем объект
            jsonSerializer.WriteObject(buffer, customer1);
            buffer.Close();
            Console.ReadLine();*/
        }

        public IEnumerable<T> All()
        {
            return _general.Values.ToList();
        }

        public Guid[] GetAllID()
        {
            Guid[] array = new Guid[_general.Count];
            int i = 0;

            foreach (var item in _general)
            {
                array[i] = item.Value.Id;
                i++;
            }
            return array;
        }

        public bool Insert(T Entity)
        {
            if (Entity.Validate())
            {
                _general.Add(Entity.Id, Entity);
                Serialize();
                Logger.LogInfo($"{typeof(T).Name}  \t{Entity.Id} was inserted");
                return true;
            }
            return false;
        }

        public T GetById(Guid id)
        {
            return _general[id];
        }

        public bool Update(Guid id, T Entity)
        {
            if (_general.ContainsKey(id))
            {
                _general[id] = Entity;
                return true;
            }
            return false;
        }

        public bool Delete(Guid id)
        {
            if (_general.ContainsKey(id))
            {
                _general.Remove(id);
                Logger.LogInfo($"{typeof(T).Name}  \t{id} was deleted");
                return true;
            }
            Logger.LogError("Id not exist");
            return false;
        }

        public void DisplayEntityInfo(Guid id)
        {
            EntityBase Entity = _general[id] as EntityBase;
            Entity.DisplayEntityInfo();
        }


    }
}
