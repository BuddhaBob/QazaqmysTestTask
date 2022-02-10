using QazaqmysTestTask.Models.EF;

namespace QazaqmysTestTask.Models.Interfaces
{
    public interface ITable<T>
    {
        public T Get(long ID);

        public void Save(T entity);

        public void Update(T entity);

        public void Delete(long ID);
    }
}
