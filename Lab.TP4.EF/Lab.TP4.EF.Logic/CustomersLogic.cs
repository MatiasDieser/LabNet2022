using System;
using System.Collections.Generic;
using System.Linq;
using Lab.TP4.EF.Entities;
using System.Text;
using Lab.TP4.EF.Logic.Exceptions;
using System.Threading.Tasks;

namespace Lab.TP4.EF.Logic
{
    public class CustomersLogic : BaseLogic, ICrudLogic<Customers>
    {
        public void Add(Customers newCustomer)
        {
            context.Customers.Add(newCustomer);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
        }
        public void DeleteByString(string customerID)
        {
            try
            {
                var customerAEliminar = context.Customers.Find(customerID);
                if(customerAEliminar != null)
                {
                    context.Customers.Remove(customerAEliminar);
                    context.SaveChanges();
                    Console.WriteLine("Registro eliminado correctamente");
                }
                else
                {
                    NonExistentIdException.GetException();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }

        public void Update(Customers customer)
        {
            var customerUpdate = context.Customers.Find(customer.CustomerID);
            context.Entry(customerUpdate).CurrentValues.SetValues(customer);
            context.SaveChanges();
        }

        public Customers Find(int id)
        {
            try
            {
                return context.Customers.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Customers Find(string id)
        {
            try
            {
                return context.Customers.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
