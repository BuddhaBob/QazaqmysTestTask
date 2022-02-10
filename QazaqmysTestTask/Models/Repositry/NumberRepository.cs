using QazaqmysTestTask.Data;
using QazaqmysTestTask.Models.EF;
using QazaqmysTestTask.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QazaqmysTestTask.Models.Repositry
{
    public class NumberRepository : INumber, IDisposable
    {
        private TelephoneBookContext context = new TelephoneBookContext();

        public void Delete(long ID)
        {
            try
            {
                context.Numbers.Remove(context.Numbers.Find(ID));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Logs
            }
        }

        public Number Get(long ID)
        {
            return context.Numbers.Find(ID);
        }

        public List<Number> GetNumbers()
        {
            return context.Numbers.ToList();
        }

        public void Save(Number entity)
        {
            if (entity != null)
            {
                context.Numbers.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(Number entity)
        {
            if (entity != null)
            {
                context.Numbers.Update(entity);
                context.SaveChanges();
            }
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
