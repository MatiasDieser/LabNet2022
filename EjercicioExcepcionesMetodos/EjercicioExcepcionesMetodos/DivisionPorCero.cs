using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioExcepcionesMetodos
{
    public static class DivisionPorCero
    {
        public static void DividirPorCero(this int valor)
        {
            try
            {
                valor = valor / 0;
            }
            catch (DivideByZeroException dex)
            {
                Console.WriteLine(dex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Console.WriteLine("Operación finalizada");
                Console.ReadKey();
            }
        }
    }
}
