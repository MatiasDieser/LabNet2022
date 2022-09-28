using System;
using System.Collections.Generic;
using System.Linq;
using Lab.TP4.EF.Entities;
using System.Text;
using Lab.TP4.EF.Logic.Exceptions;
using System.Threading.Tasks;

namespace Lab.TP4.EF.Logic
{
    public class EmployeesLogic : BaseLogic, ICrudLogic<Employees>
    {
        public void Add(Employees newEmployees)
        {           
             context.Employees.Add(newEmployees);
             context.SaveChanges();                  
        }

        public void Delete(int id)
        {
            try
            {
                var employeesAEliminar = context.Employees.Find(id);
                if(employeesAEliminar != null)
                {
                    context.Employees.Remove(employeesAEliminar);
                    context.SaveChanges();
                    Console.WriteLine("Registro eliminado correctamente");
                }
                else
                {
                    NonExistentIdException.GetException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:  {ex.Message}");
            }
        }

        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public void Update(Employees employees)
        {
            try
            {
                var employeesUpdate = context.Employees.Find(employees.EmployeeID);
                if(employeesUpdate != null)
                {
                    context.Entry(employeesUpdate).CurrentValues.SetValues(employees);
                    context.SaveChanges();
                    Console.WriteLine("Registro actualizado correctamente");
                }
                else
                {
                    NonExistentIdException.GetException();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:  {ex.Message}");
            }
        }
    }
}
