using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioExcepcionesMetodos
{
    class LogicException : Exception
    {
        public static void DevolverExcepcion()
        {
            throw new LogicException();
        }
        public LogicException() : base()
        {

        }
    }
}
