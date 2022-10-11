using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.TP8.EF.Logic.Exceptions
{
    public class ObligatoryDataException : Exception
    {
        public static void GetException()
        {
            throw new ObligatoryDataException();
        }
        public ObligatoryDataException() : base("Se intentó insertar datos erróneos o nulos en un campo obligatorio")
        {

        }

    }
}
