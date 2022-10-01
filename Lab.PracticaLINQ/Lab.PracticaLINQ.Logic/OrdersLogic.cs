using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.PracticaLINQ.Entities;

namespace Lab.PracticaLINQ.Logic
{
    public class OrdersLogic : BaseLogic, ICommonMethods<Orders>
    {
        public List<Orders> GetAll()
        {
            return context.Orders.ToList();
        }

        public List<Orders> GetCustomersOrders()
        {

            var queryCustomersOrders = from customers in context.Customers
                                       join orders in context.Orders
                                       on customers.CustomerID equals orders.CustomerID
                                       where customers.Region == "WA" && orders.OrderDate > new DateTime(1997,01,01)
                                       orderby customers.CustomerID ascending
                                       select orders;

            return queryCustomersOrders.ToList();
        }
    }
}
