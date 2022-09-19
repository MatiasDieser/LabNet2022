using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioExcepcionesMetodos
{
    class Program
    {
        static void Main(string[] args)
        {
            int respuesta = 0;
            do
            {
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Ejercicio métodos de extensión y excepciones (+ Unit tests)");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Elija una opción:");
                Console.WriteLine("1- División por cero");
                Console.WriteLine("2- Método división con excepciones");
                Console.WriteLine("3- Excepción logic");
                Console.WriteLine("4- Excepción personalizada");
                Console.WriteLine("5- Salir");
                Console.WriteLine("-----------------------------------------------------------");
                try
                {
                    respuesta = int.Parse(Console.ReadLine());
                }
                catch (FormatException fex)
                {
                    Console.WriteLine(fex.Message);
                    Console.ReadKey();
                }
                Console.Clear();
                switch (respuesta)
                {
                    case 1:
                        int x = 0;
                        Console.WriteLine("Ingrese un número a dividir: ");
                        try
                        {
                            x = int.Parse(Console.ReadLine());
                            x.DividirPorCero();
                            
                        }
                        catch (FormatException fex)
                        {
                            Console.WriteLine(fex.Message);
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("Ingrese el dividendo: ");
                            var num = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("Ingrese el divisor: ");
                            var num2 = Convert.ToDecimal(Console.ReadLine());
                            DivisionException.Division(num, num2);

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Argumento no válido (debe ingresarse un número!)");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Console.ReadKey();
                        respuesta = 0;
                        Console.Clear();
                        break;
                    case 3:
                        try
                        {
                            LogicException.DevolverExcepcion();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Mensaje de la excepción: {0}", ex.Message);
                            Console.WriteLine("Tipo de la exepción : {0}", ex.GetType());
                        }
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 4:
                        try
                        {
                            LogicPersonalizadaException.DevolverExcepcion();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Mensaje de la excepción: {0}", ex.Message);
                        }
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 5:
                        respuesta = 5;
                        break;
                    default:
                        break;
                }
            } while (respuesta !=5);
            Console.WriteLine("Hasta luego!");
            Console.ReadKey();
        }
    }
}



 
