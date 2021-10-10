namespace Core.Interfaces
{
    public interface IUnitofWork<T> where T : class
    {
        IGenericRepository<T> Entity { get; }
        void Save();

    }
}
