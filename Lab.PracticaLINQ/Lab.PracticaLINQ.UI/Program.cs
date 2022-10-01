using Lab.PracticaLINQ.Entities;
using Lab.PracticaLINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.PracticaLINQ.UI
{
    public class Program
    {

        static void Main(string[] args)
        {
            int respuesta = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Ejercicio práctica LINQ");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Elija una opción:");
                Console.WriteLine("1- Query para devolver objeto customer");
                Console.WriteLine("2- Query para devolver todos los productos sin stock");
                Console.WriteLine("3- Query para devolver todos los productos que tienen stock y que cuestan " +
                    "más de 3 por unidad");
                Console.WriteLine("4- Query para devolver todos los customers de la Región WA");
                Console.WriteLine("5- Query para devolver el primer elemento o nulo de una lista" +
                    " de productos donde el ID de producto sea igual a 789");
                Console.WriteLine("6- Query para devolver los nombre de los Customers." +
                    " Mostrarlos en Mayuscula y en Minuscula");
                Console.WriteLine("7- Query para devolver Join entre Customers y Orders donde los customers" +
                    " sean de la  Región WA y la fecha de orden sea mayor a 1 / 1 / 1997");
                Console.WriteLine("8- Query para devolver los primeros 3 Customers de la  Región WA");
                Console.WriteLine("9- Query para devolver lista de productos ordenados por nombre");
                Console.WriteLine("10- Query para devolver lista de productos ordenados " +
                    "por unit in stock de mayor a menor.");
                Console.WriteLine("11- Query para devolver las distintas categorías asociadas a los productos");
                Console.WriteLine("12- Query para devolver el primer elemento de una lista de productos");
                Console.WriteLine("13- Query para devolver los customer con la cantidad de ordenes asociadas");
                Console.WriteLine("14-Salir");
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
                        Ejercicio1();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 2:
                        Ejercicio2();
                        Console.ReadKey();
                        respuesta = 0;
                        Console.Clear();
                        break;
                    case 3:
                        Ejercicio3();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 4:
                        Ejercicio4();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 5:
                        Ejercicio5();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 6:
                        Ejercicio6();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 7:
                        Ejercicio7();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 8:
                        Ejercicio8();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 9:
                        Ejercicio9();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 10:
                        Ejercicio10();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 11:
                        Ejercicio11();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 12:
                        Ejercicio12();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 13:
                        Ejercicio13();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 14:                        
                        respuesta = 14;
                        break;
                    default:
                        Console.WriteLine("El número o letra que ingresaste no es válido");
                        break;
                }
            } while (respuesta != 14);
            Console.WriteLine("Hasta luego!");
            Console.ReadKey();
        }
        public static void Ejercicio1()
        {
            CustomersLogic customersLogic = new CustomersLogic();
            foreach (Customers customer in customersLogic.GetCustomer())
            {
                Console.WriteLine($"ID:{customer.CustomerID}" +
                    $"\nNombre:{customer.ContactName}" +
                    $"\nCompañía:{customer.CompanyName}" +
                    $"\nTítulo de contacto:{customer.ContactTitle}" +
                    $"\nFax:{customer.Fax}" +
                    $"\nCódigo postal:{customer.PostalCode}" +
                    $"\nDirección:{customer.Address}" +
                    $"\nCiudad:{customer.City}" +
                    $"\nRegión:{customer.Region}" +
                    $"\nTeléfono:{customer.Phone}");
            }
        }
        public static void Ejercicio2()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            foreach (Products products in productsLogic.GetNonStockProducts())
            {
                Console.WriteLine($"Nombre del producto: {products.ProductName}" +
                                 $" || Stock:{products.UnitsInStock}");
            }
        }
        public static void Ejercicio3()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            foreach (Products products in productsLogic.GetStockedProducts())
            {
                Console.WriteLine($"{products.ProductName}" +
                                  $"|| Precio: {products.UnitPrice}");
            }
        }
        public static void Ejercicio4()
        {
            CustomersLogic customersLogic = new CustomersLogic();
            foreach (Customers customers in customersLogic.GetWACustomers())
            {                
                    Console.WriteLine($"Nombre: {customers.ContactName} - Region: {customers.Region}");               
            }
        }
        public static void Ejercicio5()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            if(productsLogic.GetProductByID().Count > 0)
            {
                foreach (Products products in productsLogic.GetProductByID())
                {
                    Console.WriteLine($"{products.ProductName}- ID: {products.ProductID}");
                }
            }
            else
            {
                Console.WriteLine("NULL");
            }
        }
        public static void Ejercicio6()
        {
            CustomersLogic customersLogic = new CustomersLogic();
            foreach (Customers customers in customersLogic.GetCustomersName())
            {
                Console.WriteLine($"{customers.ContactName.ToUpper()} / {customers.ContactName.ToLower()}");
            }
        }
        public static void Ejercicio7()
        {
            OrdersLogic ordersLogic = new OrdersLogic();
            foreach (Orders orders in ordersLogic.GetCustomersOrders())
            {
                Console.WriteLine($"Customer ID: {orders.CustomerID} || Fecha de orden: {orders.OrderDate}");
            }
        }

        public static void Ejercicio8()
        {
            CustomersLogic customersLogic = new CustomersLogic();
            foreach (Customers customers in customersLogic.GetFirstThree())
            {
                Console.WriteLine($"Nombre: {customers.ContactName} - Region: {customers.Region}");
            }
        }
        public static void Ejercicio9()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            foreach(Products products in productsLogic.GetOrderedProducts())
            {
                Console.WriteLine($"{products.ProductName}");
            }
        }
        public static void Ejercicio10()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            foreach (Products products in productsLogic.GetProductsByStock())
            {
                Console.WriteLine($"{products.ProductName} || Stock: {products.UnitsInStock}");
            }
        }
        public static void Ejercicio11()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            foreach(Products products in productsLogic.GetAssociatedCategories())
            {
                Console.WriteLine($"{products.ProductName}: {products.Categories.CategoryName}");
            }
        }
        public static void Ejercicio12()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            foreach (Products products in productsLogic.GetFirstProduct())
            {
                Console.WriteLine($"{products.ProductName}, ID: {products.ProductID}");
            }
        }
        public static void Ejercicio13()
        {
            CustomersLogic customersLogic = new CustomersLogic();
            var customersQuery = from customers in customersLogic.GetAll()
                                 select new { ContactName = customers.ContactName,
                                              Orders = customers.Orders.Count()};

            foreach(var customer in customersQuery)
            {
                Console.WriteLine($"{customer.ContactName}, Número de órdenes: {customer.Orders}");
            }
        }
    }
}
