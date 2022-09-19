using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioExcepcionesMetodos
{
    public class DivisionException
    {
        
        public static decimal Division(decimal dividendo, decimal divisor)
        {
            try
            {
                decimal resultado = dividendo / divisor;               
                Console.WriteLine(resultado);
                return resultado;
            }
            catch (DivideByZeroException dex)
            {
                Console.WriteLine("Te despertaste motivado eh, pero...");
                Console.WriteLine(dex.Message);
            }          
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion general");
            }
            finally
            {
                
                Console.WriteLine("Operación finalizada");
            }
            return 0;
        }

    }
}
