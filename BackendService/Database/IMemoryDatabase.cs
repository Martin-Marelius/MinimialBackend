namespace BackendService.Database
{
    public interface IMemoryDatabase<T>
    {
        Dictionary<string, T> Database { get; set; }

        T GetById(int id, string type);

        IEnumerable<T> GetByType(string type);

        IEnumerable<IGrouping<string, T>> GetAll();

        void Add(int id, string type, T entity);

        void Update(int id, string type, T updatedEntity);

        void Delete(int id, string type);
    }
}
