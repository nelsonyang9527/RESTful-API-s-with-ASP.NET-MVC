using Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebDemo.Service;

namespace WebDemo.Controllers
{
    public class CustomersController : ApiController
    {
        CustomersService service = new CustomersService();

        /// <summary>
        /// 取得客戶資料
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        [HttpGet]
        public string Get(string CustomerID)
        {
            Customers result = service.GetCustomers(CustomerID);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 新增客戶資料
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public string Post(Customers value)
        {
            value.CustomerID = Guid.NewGuid().ToString("N").Substring(0, 5);
            bool result = service.AddCustomers(value);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 修改客戶資料
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public string Put(Customers value)
        {
            bool result = service.UpdateCustomers(value);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 刪除客戶資料
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        [HttpDelete]
        public string Delete(string CustomerID)
        {
            bool result = service.DeleteCustomers(CustomerID);
            return JsonConvert.SerializeObject(result);
        }
    }
}
