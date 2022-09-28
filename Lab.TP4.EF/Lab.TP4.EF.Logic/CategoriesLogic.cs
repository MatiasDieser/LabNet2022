using Lab.TP4.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab.TP4.EF.Logic.Exceptions;
using System.Threading.Tasks;

namespace Lab.TP4.EF.Logic
{
    public class CategoriesLogic : BaseLogic, ICrudLogic<Categories>
    {
        public void Add(Categories newCategorie)
        {
            context.Categories.Add(newCategorie);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                var categorieAEliminar = context.Categories.Find(id);
                if (categorieAEliminar != null)
                {
                    context.Categories.Remove(categorieAEliminar);
                    context.SaveChanges();
                    Console.WriteLine("Registro eliminado correctamente");
                }
                else
                {
                    NonExistentIdException.GetException();
                }

            }catch(Exception ex)
            {
                Console.WriteLine($"Error :{ex.Message}");
            }
        }

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public void Update(Categories categorie)
        {
            try
            {
                var categoriesUpdate = context.Categories.Find(categorie.CategoryID);
                if (categoriesUpdate != null)
                {
                    context.Entry(categoriesUpdate).CurrentValues.SetValues(categorie);
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
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
