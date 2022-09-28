using Lab.TP4.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab.TP4.EF.Logic.Exceptions;
using System.Threading.Tasks;
using Moq;
using Lab.TP4.EF.Datos;

namespace Lab.TP4.EF.Logic
{
    public class ShippersLogic : BaseLogic, ICrudLogic<Shippers>
    {
        public ShippersLogic()
        {

        }
        public void Add(Shippers newShipper)
        {
            context.Shippers.Add(newShipper);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                var shipperAEliminar = context.Shippers.Find(id);
                if(shipperAEliminar != null)
                {
                    context.Shippers.Remove(shipperAEliminar);
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
                Console.WriteLine($"{ex.Message}");
            }
        }
       


        public List<Shippers> GetAll()
        {
            return context.Shippers.ToList();
        }

        public void Update(Shippers shipper)
        {
            try
            {
                var shipperUpdate = context.Shippers.Find(shipper.ShipperID);
                if(shipperUpdate != null)
                {
                    context.Entry(shipperUpdate).CurrentValues.SetValues(shipper);
                    context.SaveChanges();
                    Console.WriteLine("Registro actualizado correctamente");
                }
                else
                {
                    NonExistentIdException.GetException();
                }
            }catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public ShippersLogic(NorthwindContext @Objects)
        {

        }
    }
}
