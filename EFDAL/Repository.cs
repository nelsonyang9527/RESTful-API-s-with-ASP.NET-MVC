using Database;
using System;
using System.Data.Entity;
using System.Linq;

namespace EFDAL
{
    /// <summary>
    /// 資料存取層 (實作 Entity Framework)
    /// </summary>
    class Repository : IRepository
    {
        /// <summary>
        /// 資料庫實體
        /// </summary>
        protected DbContext _context = new Northwind();

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <typeparam name="T">類別模型</typeparam>
        /// <param name="filter">LINQ語句</param>
        /// <returns>未指定資料型別的資料來源</returns>
        public IQueryable<T> GetAll<T>(System.Linq.Expressions.Expression<Func<T, bool>> filter = null) where T : class
        {
            try
            {
                if (filter == null)
                {
                    return _context.Set<T>();
                }
                else
                {
                    return _context.Set<T>().Where(filter);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <typeparam name="T">類別模型</typeparam>
        /// <param name="entity">資料實體模型</param>
        public bool Add<T>(T entity) where T : class
        {
            if (entity != null)
            {
                _context.Set<T>().Add(entity);
                int result = _context.SaveChanges();
                return (result >1) ? true : false;
            }
            return false;
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <typeparam name="T">類別模型</typeparam>
        /// <param name="entity">資料實體模型</param>
        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <typeparam name="T">類別模型</typeparam>
        /// <param name="entity">資料實體模型</param>
        public void Delete<T>(T entity) where T : class
        {
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

    }
}
