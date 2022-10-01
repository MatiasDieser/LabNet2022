using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.PracticaLINQ.Entities;

namespace Lab.PracticaLINQ.Logic
{
    public class CategoriesLogic : BaseLogic, ICommonMethods<Categories>
    {
        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }
        
    }
}
