using System;
using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebDemo.Service;

namespace WebDemo.Tests
{
    [TestClass]
    public class CustomersControllerTest
    {
        ICustomersService service;

        /// <summary>
        /// 主測試程序 CRUD
        /// </summary>
        [TestMethod]
        public void main()
        {
            this.service = new CustomersService();

            Customers data = new Customers();
            data.CustomerID = Guid.NewGuid().ToString("N").Substring(0, 5);
            data.ContactName = "測試人";
            data.CompanyName = "測試公司";
            // 增
            Add(data);
            // 改
            data.ContactName = "測試人(改)";
            Update(data);
            // 查
            Get(data);
            // 刪
            Delete(data);
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="data"></param>
        private void Add(Customers data)
        {
            bool result = service.AddCustomers(data);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// 改
        /// </summary>
        /// <param name="data"></param>
        private void Update(Customers data)
        {
            bool result = service.UpdateCustomers(data);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// 查
        /// </summary>
        /// <param name="data"></param>
        private void Get(Customers data)
        {
            Customers result = service.GetCustomers(data.CustomerID);
            Assert.IsInstanceOfType(result, typeof(Customers));
        }

        /// <summary>
        /// 刪
        /// </summary>
        /// <param name="data"></param>
        private void Delete(Customers data)
        {
            bool result = service.DeleteCustomers(data.CustomerID);
            Assert.IsTrue(result);
        }
    }
}
