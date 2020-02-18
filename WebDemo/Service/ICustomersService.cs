using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;
using EFDAL;

namespace WebDemo.Service
{
    public interface ICustomersService
    {
        /// <summary>
        /// 取得客戶資料
        /// </summary>
        /// <param name="CustomerID">客戶ID</param>
        /// <returns></returns>
        Customers GetCustomers(string CustomerID);

        /// <summary>
        /// 新增客戶資料
        /// </summary>
        /// <param name="createCustomers">新增資料</param>
        /// <returns></returns>
        bool AddCustomers(Customers createCustomers);

        /// <summary>
        /// 修改客戶資料
        /// </summary>
        /// <param name="updateCustomers">修改資料</param>
        /// <returns></returns>
        bool UpdateCustomers(Customers updateCustomers);

        /// <summary>
        /// 刪除客戶資料
        /// </summary>
        /// <param name="CustomerID">客戶ID</param>
        /// <returns></returns>
        bool DeleteCustomers(string CustomerID);
    }
}