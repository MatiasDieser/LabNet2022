using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.TP4.EF.Logic.Exceptions
{
    public class ForeignKeyException : Exception
    {
        public static void GetException()
        {          
            try
            {
                throw new ForeignKeyException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public ForeignKeyException() : base("El registro que se está intentando eliminar posee una llave foránea y afectaría a otras tablas")
        {

        }
    }
}
