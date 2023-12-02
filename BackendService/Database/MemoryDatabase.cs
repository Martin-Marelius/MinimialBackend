using System;
using System.Collections.Generic;

namespace BackendService.Database
{
    public class MemoryDatabase<T> : IMemoryDatabase<T>
    {
        public Dictionary<string, T> Database { get; set; }

        public MemoryDatabase()
        {
            Database = new Dictionary<string, T>();
        }

        public T GetById(int id, string type)
        {
            if (Database.TryGetValue(type + "_" + id, out T entity))
            {
                return entity;
            }

            return default(T); // Return null for reference types
        }

        public IEnumerable<IGrouping<string, T>> GetAll()
        {
            var groupedByType = Database
                .GroupBy(entry => GetTypeFromKey(entry.Key), entry => entry.Value);

            return groupedByType;
        }

        private string GetTypeFromKey(string key)
        {
            int separatorIndex = key.IndexOf('_');
            if (separatorIndex >= 0)
            {
                return key.Substring(0, separatorIndex);
            }

            return key;
        }

        public void Add(int id, string type, T entity)
        {
            Database[type + "_" + id] = entity;
        }

        public void Update(int id, string type, T updatedEntity)
        {
            if (Database.ContainsKey(type + id))
            {
                Database[type + "_" + id] = updatedEntity;
            }
            // Handle the case where the entity with the specified ID doesn't exist
        }

        public void Delete(int id, string type)
        {
            if (Database.ContainsKey(type + id))
            {
                Database.Remove(type + "_" + id);
            }
            // Handle the case where the entity with the specified ID doesn't exist
        }

        public IEnumerable<T> GetByType(string type)
        {
            // Filter values based on keys that start with the specified type
            var values = Database.Where(pair => pair.Key.StartsWith(type))
                                 .Select(pair => pair.Value);

            return values;
        }
    }
}
