using System;
using System.Linq;

namespace EFDAL
{
    /// <summary>
    /// 資料存取層
    /// </summary>
    interface IRepository
    {
        /// <summary>
        /// 取得資料
        /// </summary>
        /// <typeparam name="T">類別模型</typeparam>
        /// <param name="filter">LINQ語句</param>
        /// <returns>未指定資料型別的資料來源</returns>
        IQueryable<T> GetAll<T>(System.Linq.Expressions.Expression<Func<T, bool>> filter = null) where T : class;

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <typeparam name="T">類別模型</typeparam>
        /// <param name="entity">資料實體模型</param>
        bool Add<T>(T entity) where T : class;

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <typeparam name="T">類別模型</typeparam>
        /// <param name="entity">資料實體模型</param>
        bool Update<T>(T entity) where T : class;

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <typeparam name="T">類別模型</typeparam>
        /// <param name="entity">資料實體模型</param>
        bool Delete<T>(T entity) where T : class;

    }
}
