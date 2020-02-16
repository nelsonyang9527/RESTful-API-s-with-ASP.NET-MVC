using Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFDAL
{
    public class ServiceBase
    {
        private Repository _Repository = new Repository();
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <typeparam name="T">類別模型</typeparam>
        /// <param name="entity">類別</param>
        /// <returns></returns>
        public bool Insert<T>(T entity) where T : class
        {
            try
            {
                if (entity == null) { return false; }

                return _Repository.Add<T>(entity);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <typeparam name="T">方法型別</typeparam>
        /// <param name="filter">LINQ 表達式</param>
        /// <returns></returns>
        public IQueryable<T> Lookup<T>(System.Linq.Expressions.Expression<Func<T, bool>> filter = null) where T : class
        {
            return _Repository.GetAll<T>(filter);
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        /// <typeparam name="T">方法型別</typeparam>
        /// <param name="entity">類別</param>
        /// <returns></returns>
        public bool Update<T>(T entity) where T : class
        {
            try
            {
                if (entity == null) { return false; }
                _Repository.Update<T>(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <typeparam name="T">方法型別</typeparam>
        /// <param name="entity">類別</param>
        /// <returns></returns>
        public bool Delete<T>(T entity) where T : class
        {
            try
            {
                if (entity == null) { return false; }
                _Repository.Delete<T>(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
