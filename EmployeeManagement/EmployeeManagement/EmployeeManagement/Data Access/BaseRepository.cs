using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManagement.Entities;
using System.Data.Entity;
using System.Linq.Expressions;

namespace EmployeeManagement.Data_Access
{
    public abstract class BaseRepository <T> where T: BaseEntity
    {

        private DbContext context;
        private DbSet<T> dbSet;

        public BaseRepository()
        {
            context = new EmployeesManagementDBContext();
            dbSet = context.Set<T>();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter).ToList();
        }
        public List<T> GetAll()
        {

            return dbSet.ToList();
        }

        public T GetbyId(int id)
        {

            return dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }


        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

    }
}