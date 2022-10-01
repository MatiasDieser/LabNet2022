using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.PracticaLINQ.Entities;

namespace Lab.PracticaLINQ.Logic
{
    public class CustomersLogic : BaseLogic,ICommonMethods<Customers>
    {
        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }
        public List<Customers> GetCustomer()
        {
            var customersQuery = from customer in context.Customers
                                where customer.CustomerID == "ALFKI"
                                select customer;
            
            return customersQuery.ToList();
        }
        public List<Customers> GetWACustomers()
        {
            var customersQuery = context.Customers.Where(c => c.Region == "WA").
                                 OrderBy(c=>c.ContactName).
                                 Select(c=> c);
            
            return customersQuery.ToList();
        }
        public List<Customers> GetCustomersName()
        {
            var customersQuery = context.Customers.OrderBy(c=>c.ContactName).
                                 Select(c=>c);

            return customersQuery.ToList();
        }

        public List<Customers> GetFirstThree()
        {
            var customersQuery = (from customers in context.Customers
                                 where customers.Region == "WA"
                                 select customers).Take(3);

            return customersQuery.ToList();
        }
       
    }
}
