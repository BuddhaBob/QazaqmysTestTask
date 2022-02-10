using Microsoft.EntityFrameworkCore;
using QazaqmysTestTask.Data;
using QazaqmysTestTask.Models.EF;
using QazaqmysTestTask.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QazaqmysTestTask.Models.Repositry
{
    public class UserRepository : IUser, IDisposable
    {
        private TelephoneBookContext context = new TelephoneBookContext();
        public void Delete(long ID)
        {
            try
            {
                context.Users.Remove(context.Users.Find(ID));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Logs
            }
        }

        public User Get(long ID)
        {
            return context.Users.Find(ID);
        }

        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public void Save(User entity)
        {
            if (entity != null)
            {
                context.Users.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(User entity)
        {
            if(entity != null)
            {
                context.Users.Update(entity);
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
