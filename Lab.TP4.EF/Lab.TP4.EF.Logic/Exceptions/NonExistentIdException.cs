using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.TP8.EF.Logic.Exceptions
{
    
    public class NonExistentIdException : Exception
    {
        public static void GetException()
        {
            throw new NonExistentIdException();
        }
        public NonExistentIdException() : base("El id ingresado no tiene el formato correcto o no existe")
        {

        }
    }
}
