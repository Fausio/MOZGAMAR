using MOZGAMAR.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MOZGAMAR.Repository
{
    public class GenericRepository<Tbl_Entity> : IRepository<Tbl_Entity> where Tbl_Entity : class
    {
        DbSet<Tbl_Entity> _dbset;
        private MOZGAMEREntities _DBEntity;

        public GenericRepository(MOZGAMEREntities entities)
        {
            _DBEntity = entities;
            _dbset = _DBEntity.Set<Tbl_Entity>();
        }
        public void Add(Tbl_Entity entity)
        {
            _dbset.Add(entity);
            _DBEntity.SaveChanges();

        }

        public IEnumerable<Tbl_Entity> GetAllRecords()
        {
            return _dbset.ToList();
        }

        public int GetAllRecordsCount()
        {
            return _dbset.Count();
        }

        public IQueryable<Tbl_Entity> GetAllRecordsIQueryable()
        {
            return _dbset;
        }

        public Tbl_Entity GetFirstOrDefault(int recordId)
        {
            return _dbset.Find(recordId);
        }

        public Tbl_Entity GetFirstOrDefaultByParameter(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
            return _dbset.Where(wherePredict).FirstOrDefault();
        }

        public IEnumerable<Tbl_Entity> GetListParameter(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
            return _dbset.Where(wherePredict).ToList();
        }


        public IEnumerable<Tbl_Entity> GetResultBySqlProcedure(string query, params object[] parameters)
        {
            if (parameters != null)
            {
                return _DBEntity.Database.SqlQuery
                    <Tbl_Entity>(query, parameters).ToList();
            }
            else
            {
                return _DBEntity.Database.SqlQuery<Tbl_Entity>(query).ToList();
            }
        }

        public void InactiveAndDeleteMarkByWhereClouse(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPredict)
        {
            _dbset.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

        public void Remove(Tbl_Entity entity)
        {
            if (_DBEntity.Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
                _dbset.Remove(entity);

            }
        }

        public void RemoveByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
            Remove(_dbset.Where(wherePredict).FirstOrDefault());
        }

        public void RemoveRangeByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
            var entitys = _dbset.Where(wherePredict).ToList();
            foreach (var item in entitys)
            {
                Remove(item);
            }
        }

        public void Update(Tbl_Entity entity)
        {
            _dbset.Attach(entity);
            _DBEntity.Entry(entity).State = EntityState.Modified;
            _DBEntity.SaveChanges();
        }

        public void UpdateByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPredict)
        {
            _dbset.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

        public IEnumerable<Tbl_Entity> GetRecordsToShow(int pageNo, int curentPage, Expression<Func<Tbl_Entity, bool>> wherePredict, Expression<Func<Tbl_Entity, int>> orderByPredict)
        {
            if (wherePredict != null)
            {
                return _dbset.OrderBy(orderByPredict).Where(wherePredict).ToList();
            }
            else
            {
                return _dbset.OrderBy(orderByPredict).ToList();
            }
        }

        public IEnumerable<Tbl_Entity> GetProduct()
        {
            return _dbset.ToList();
        }

    }
}
