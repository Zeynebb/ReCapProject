using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            //IDisposable pattern implementation of c#
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                var addedEntity = context.Entry(entity);//gonderilen nesneyi bulur
                addedEntity.State = EntityState.Added;//ekler
                context.SaveChanges();//kaydeder
            }
        }

        public void Delete(Color entity)
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);//gonderilen nesneyi bulur
                deletedEntity.State = EntityState.Deleted;//siler
                context.SaveChanges();//kaydeder
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);//filtreye uygun nesneyi getirir
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                return filter == null ? context.Set<Color>().ToList() //filtre yoksa tum nesneleri getir
                    : context.Set<Color>().Where(filter).ToList(); //filtre varsa filtreye uyan nesneleri getir
            }
        }

        public void Update(Color entity)
        {
            using(ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                var updatedEntity = context.Entry(entity);//gonderilen nesneyi bulur
                updatedEntity.State = EntityState.Modified;//gunceller
                context.SaveChanges();//kaydeder
            }
        }
    }
}
