using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            //IDisposable pattern implementation of c#
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                var addedEntity = context.Entry(entity);//gonderilen nesneyi bulur
                addedEntity.State = EntityState.Added;//ekler
                context.SaveChanges();//kaydeder
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);//gonderilen nesneyi bulur
                deletedEntity.State = EntityState.Deleted;//siler
                context.SaveChanges();//kaydeder
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapProjectDatabaseContext context= new ReCapProjectDatabaseContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);//filtreye uygun nesneyi getirir
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                return filter == null ? context.Set<Car>().ToList() //filtre yoksa tum nesneleri getir
                    : context.Set<Car>().Where(filter).ToList(); //filtre varsa filtreye uyan nesneleri getir
            }
            
        }

        public void Update(Car entity)
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                var updatedEntity = context.Entry(entity);//gonderilen nesneyi bulur
                updatedEntity.State = EntityState.Modified;//gunceller
                context.SaveChanges();//kaydeder
            }
        }
    }
}
