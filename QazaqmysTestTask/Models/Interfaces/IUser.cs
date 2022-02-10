using QazaqmysTestTask.Models.EF;
using System.Collections.Generic;

namespace QazaqmysTestTask.Models.Interfaces
{
    public interface IUser : ITable<User>
    {
        public List<User> GetUsers();
    }
}
