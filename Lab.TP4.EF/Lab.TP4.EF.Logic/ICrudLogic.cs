using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.TP4.EF.Logic
{
    public interface ICrudLogic<T> 
    {
        List<T> GetAll();
        void Add(T newEntitie);
        void Update(T newEntitie);
        void Delete(int id);

        T Find(int id);
    }
}
