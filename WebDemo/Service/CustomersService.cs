using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;
using EFDAL;

namespace WebDemo.Service
{
    public class CustomersService : ServiceBase
    {
        /// <summary>
        /// 取得客戶資料
        /// </summary>
        /// <param name="CustomerID">客戶ID</param>
        /// <returns></returns>
        public Customers GetCustomers(string CustomerID)
        {
            IQueryable<Customers> CustomersBase = base.Lookup<Customers>(x => x.CustomerID == CustomerID);
            return (CustomersBase.Any()) ? CustomersBase.FirstOrDefault() : null;
        }

        /// <summary>
        /// 新增客戶資料
        /// </summary>
        /// <param name="createCustomers">新增資料</param>
        /// <returns></returns>
        public bool AddCustomers(Customers createCustomers)
        {
            createCustomers.CustomerID = Guid.NewGuid().ToString("N").Substring(0, 5);
            return base.Insert<Customers>(createCustomers);
        }

        /// <summary>
        /// 修改客戶資料
        /// </summary>
        /// <param name="updateCustomers">修改資料</param>
        /// <returns></returns>
        public bool UpdateCustomers(Customers updateCustomers)
        {
            IQueryable<Customers> CustomersBase = base.Lookup<Customers>(x => x.CustomerID == updateCustomers.CustomerID);
            if(false == CustomersBase.Any()) { return false; }
            Customers UpdateData = CustomersBase.FirstOrDefault();
            UpdateData.ContactName = updateCustomers.ContactName;
            return base.Update<Customers>(UpdateData);
        }

        /// <summary>
        /// 刪除客戶資料
        /// </summary>
        /// <param name="CustomerID">客戶ID</param>
        /// <returns></returns>
        public bool DeleteCustomers(string CustomerID)
        {
            Customers deleteData = GetCustomers(CustomerID);
            if (null == deleteData) { return false; }
            return base.Delete<Customers>(deleteData);
        }
    }
}