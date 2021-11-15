using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            //IDisposable pattern implementation of C#
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                var addedEntity = context.Entry(entity);//gonderilen nesneyi bulur
                addedEntity.State = EntityState.Added;//ekler
                context.SaveChanges();//kaydeder
            }
        }

        public void Delete(Brand entity)
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);//gonderilen nesneyi bulur
                deletedEntity.State = EntityState.Deleted;//siler
                context.SaveChanges();//kaydeder
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);//filtreye uygun nesneyi getirir
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                return filter == null ? context.Set<Brand>().ToList() //filtre yoksa tum nesneleri getir
                    : context.Set<Brand>().Where(filter).ToList(); //filtre varsa filtreye uyan nesneleri getir
            }
        }

        public void Update(Brand entity)
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
