using QazaqmysTestTask.Models.EF;
using System.Collections.Generic;

namespace QazaqmysTestTask.Models.Interfaces
{
    public interface INumber : ITable<Number>
    {
        public List<Number> GetNumbers();
    }
}
