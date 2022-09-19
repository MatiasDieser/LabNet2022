using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioExcepcionesMetodos
{
    public class LogicPersonalizadaException : Exception
    {
        public static void DevolverExcepcion()
        {
            throw new LogicPersonalizadaException();
        }
        public LogicPersonalizadaException() : base("Esta excepción es totalmente personalizada!")
        {

        }
    }
}
