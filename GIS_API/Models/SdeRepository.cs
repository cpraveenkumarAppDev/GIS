using GIS_API.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

using System.Threading.Tasks;

namespace GIS_API.Models
{

    public class SdeRepository<T> : IRepository<T> where T : class
    {
        public static List<T> GetAll()
        {
            using (var databaseContext = new OracleSdeContext())
            {
                var query = databaseContext.Set<T>();
                return query.ToList();
            }
        }

        public static List<T> GetAll(OracleSdeContext databaseContext)
        {
            var query = databaseContext.Set<T>();
            return query.ToList();
        }
        public static List<T> GetList(Expression<Func<T, bool>> predicate)
        {
          
            using (var databaseContext = new OracleSdeContext())
            {
                return databaseContext.Set<T>().Where(predicate).ToList();
            }
        }

        //public static List<T> GetListReader(Expression<Func<T, bool>> predicate)
        //{

        //    using (var databaseContext = new OracleReader())
        //    {
        //        return databaseContext.Set<T>().Where(predicate).ToList();
        //    }
        //}

        public static List<T> GetList(Expression<Func<T, bool>> predicate, Expression<Func<T, byte>> orderByPredicate)
        {
            using (var databaseContext = new OracleSdeContext())
            {
                var query = databaseContext.Set<T>().Where(predicate).OrderBy(orderByPredicate);
                return query.ToList();
            }
        }

         public static List<T> GetList(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal>> orderByPredicate, int count)
        {
            using (var databaseContext = new OracleSdeContext())
            {
                var query = databaseContext.Set<T>().Where(predicate).OrderByDescending(orderByPredicate).Take(count);
                return query.ToList();
            }
        }

        public static IEnumerable<T> GetList(Expression<Func<T, bool>> predicate, OracleSdeContext databaseContext)
        {
            var query = databaseContext.Set<T>().Where(predicate);
            return query;
        }

        public static T Get(Expression<Func<T, bool>> predicate)
        {
            using (var databaseContext = new OracleSdeContext())
            {
                var query = databaseContext.Set<T>().FirstOrDefault(predicate);
                return query;
            }
        }

        public static T Get(Expression<Func<T, bool>> predicate, OracleSdeContext databaseContext)
        {
            var query = databaseContext.Set<T>().FirstOrDefault(predicate);
            return query;
        }

        public static void Add(T entity)
        {
            using (var databaseContext = new OracleSdeContext())
            {
                databaseContext.Set<T>().Add(entity);
                databaseContext.SaveChanges();
            }
        }

        public static void AddAll(List<T> entity)
        {
            using (var databaseContext = new OracleSdeContext())
            {
                databaseContext.Set<T>().AddRange(entity);
                databaseContext.SaveChanges();
            }
        }

        public static void Add(T entity, OracleSdeContext databaseContext)
        {
            databaseContext.Set<T>().Add(entity);
        }

        public static void Remove(T entity, OracleSdeContext databaseContext)
        {
            databaseContext.Set<T>().Remove(entity);
        }

        public static List<T> ExecuteStoredProcedure(string sqlStatement, params object[] parameters)
        {
            using (var databaseContext = new OracleSdeContext())
            {
                if (parameters == null)
                    return databaseContext.Database.SqlQuery<T>(sqlStatement).ToList();
                return databaseContext.Database.SqlQuery<T>(sqlStatement, parameters).ToList();
            }
        }
        public static void ExecuteEmptyStoredProcedure(string sqlStatement, params object[] parameters)
        {
            using (var databaseContext = new OracleSdeContext())
            {
                if (parameters == null)
                    databaseContext.Database.ExecuteSqlCommand(sqlStatement);
                databaseContext.Database.ExecuteSqlCommand(sqlStatement, parameters);
            }
        }

    }
}
