using Lab.TP4.EF.Entities;
using Lab.TP4.EF.Logic;
using Lab.TP4.EF.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab.TP4.EF.UI
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
                Console.WriteLine("Ejercicio práctica Entity Framework");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Elija una opción:");
                Console.WriteLine("1- Consulta simple");
                Console.WriteLine("2- Insert");
                Console.WriteLine("3- Update");
                Console.WriteLine("4- Delete");
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
                        ConsultaSimple();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 2:
                        InsertarRegistro();
                        Console.ReadKey();
                        respuesta = 0;
                        Console.Clear();
                        break;
                    case 3:
                        ActualizarRegistro();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 4:
                        EliminarRegistro();
                        Console.ReadKey();
                        Console.Clear();
                        respuesta = 0;
                        break;
                    case 5:
                        respuesta = 5;
                        break;
                    default:
                        Console.WriteLine("El número o letra que ingresaste no es válido");
                        break;
                }
            } while (respuesta != 5);
            Console.WriteLine("Hasta luego!");
            Console.ReadKey();
        }

        private static bool ValidarCamposObligatorios(string primerCampo, string segundoCampo)
        {
            var registroInvalido = "";
            bool validacionPrimerRegistro = registroInvalido.Contains(primerCampo);
            bool validacionSegundoRegistro = registroInvalido.Contains(segundoCampo);
            return validacionPrimerRegistro || validacionSegundoRegistro;
        }
        public static void ConsultaSimple()
        {
            int eleccion = 0;
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Seleccione la tabla que desea consultar");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("1- Empleados");
            Console.WriteLine("2- Customers");
            Console.WriteLine("3- Categorías");
            Console.WriteLine("4- Shippers");
            Console.WriteLine("5- Volver");
            Console.WriteLine("-----------------------------------------------------------");
            try
            {
                eleccion = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            switch (eleccion)
            {
                case 1:
                    EmployeesLogic employeesLogic = new EmployeesLogic();
                    foreach (Employees employees in employeesLogic.GetAll())
                    {
                        Console.WriteLine($"{employees.LastName}, {employees.FirstName}|ID :{employees.EmployeeID}, {employees.HireDate}");
                    }
                    break;
                case 2:
                    CustomersLogic customersLogic = new CustomersLogic();
                    foreach (Customers customers in customersLogic.GetAll())
                    {
                        Console.WriteLine($"{customers.ContactName} - {customers.CompanyName} - ID: {customers.CustomerID}");
                    }
                    break;
                case 3:
                    CategoriesLogic categoriesLogic = new CategoriesLogic();
                    foreach (Categories categories in categoriesLogic.GetAll())
                    {
                        Console.WriteLine($"{categories.CategoryName}/{categories.Description}/ ID: {categories.CategoryID}");
                    }
                    break;
                case 4:
                    ShippersLogic shippersLogic = new ShippersLogic();
                    foreach (Shippers shippers in shippersLogic.GetAll())
                    {
                        Console.WriteLine($"{shippers.CompanyName}/{shippers.Phone}/ID: {shippers.ShipperID}");
                    }
                    break;
                case 5:
                    Console.WriteLine("Presione cualquier tecla para volver al menú");
                    break;
                default:
                    Console.WriteLine("El número o letra que ingresaste no es válido");
                    break;

            }
        }
        public static void InsertarRegistro()
        {
            int eleccion = 0;
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Seleccione la tabla a la que desea agregar un registro");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("1- Empleados");
            Console.WriteLine("2- Customers");
            Console.WriteLine("3- Categorías");
            Console.WriteLine("4- Shippers");
            Console.WriteLine("5- Volver");
            Console.WriteLine("-----------------------------------------------------------");
            try
            {
                eleccion = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            switch (eleccion)
            {
                case 1:
                    string employeeName = "";
                    string employeeLastName = "";
                    string employeeCountry = "";
                    try
                    {
                        Console.WriteLine("Ingrese el nombre del empleado:");
                        employeeName = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido del empleado:");
                        employeeLastName = Console.ReadLine();
                        
                        if (ValidarCamposObligatorios(employeeName, employeeLastName))
                        {
                            ObligatoryDataException.GetException();
                        }

                        Console.WriteLine("Ingrese el país al que pertenece el empleado:");
                        employeeCountry = Console.ReadLine();                       
                        EmployeesLogic employeesLogic = new EmployeesLogic();
                        employeesLogic.Add(new Employees
                        {
                            FirstName = employeeName,
                            LastName = employeeLastName,
                            Country = employeeCountry,
                            HireDate = DateTime.Now
                        }) ;
                        Console.WriteLine("Empleado agregado correctamente");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    break;
                case 2:
                    string customerContactName = "";
                    string customerCity = "";
                    string customerCompanyName = "";
                    string customerID = "";

                    try
                    {
                        Console.WriteLine("Ingrese el nombre de contacto del cliente:");
                        customerContactName = Console.ReadLine();
                        Console.WriteLine("Ingrese el nombre de la compañía cliente:");
                        customerCompanyName = Console.ReadLine();
                        Console.WriteLine("Ingrese el ID del cliente (abreviatura del nombre --> 5 Letras):");
                        customerID = Console.ReadLine(); // el customerID no es obligatorio en la base de datos pero 
                                                         // es necesario para poder borrarlo por ID
                        if (ValidarCamposObligatorios(customerCompanyName, customerID))
                        {
                            ObligatoryDataException.GetException();
                        }
                        Console.WriteLine("Ingrese la ciudad del cliente:");
                        customerCity = Console.ReadLine();
                        CustomersLogic customersLogic = new CustomersLogic();
                        customersLogic.Add(new Customers
                        {
                            CustomerID = customerID,
                            CompanyName = customerCompanyName,
                            City = customerCity,
                            ContactName = customerContactName
                        });
                        Console.WriteLine("Cliente agregado correctamente");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    break;
                case 3:
                    string categoryName = "";
                    string categoryDescription = "";
                    try
                    {
                        Console.WriteLine("Ingrese el nombre de la categoría:");
                        categoryName = Console.ReadLine();
                        if (ValidarCamposObligatorios(categoryName,"secondValue"))
                        {
                            ObligatoryDataException.GetException();
                        }
                        Console.WriteLine("Ingrese la descripción de la categoría:");
                        categoryDescription = Console.ReadLine();
                        CategoriesLogic categoriesLogic = new CategoriesLogic();
                        categoriesLogic.Add(new Categories
                        {
                            CategoryName = categoryName,
                            Description = categoryDescription
                        });
                        Console.WriteLine("Categoría agregada correctamente");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    break;
                case 4:
                    string shipperCompanyName = "";
                    string phone = "";
                    try
                    {
                        Console.WriteLine("Ingrese el nombre de la nueva compañía de distribución:");
                        shipperCompanyName = Console.ReadLine();
                        if (ValidarCamposObligatorios(shipperCompanyName, "secondValue"))
                        {
                            ObligatoryDataException.GetException();
                        }
                        Console.WriteLine("Ingrese el número de teléfono:");
                        phone = Console.ReadLine();
                        ShippersLogic shippersLogic = new ShippersLogic();
                        shippersLogic.Add(new Shippers
                        {
                            CompanyName = shipperCompanyName,
                            Phone = phone
                        });
                        Console.WriteLine("Compañía agregada correctamente");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error:  {ex.Message}");
                    }
                    break;
                case 5:
                    Console.WriteLine("Presione cualquier tecla para volver al menú");                   
                    break;
                default:
                    Console.WriteLine("(El número o letra que ingresaste no es válido)");
                    break;
            }
        }
        public static void EliminarRegistro()
        {
            int eleccion = 0;
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Seleccione la tabla a la que desea eliminar un registro");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("1- Empleados");
            Console.WriteLine("2- Customers");
            Console.WriteLine("3- Categorías");
            Console.WriteLine("4- Shippers");
            Console.WriteLine("5- Volver");
            Console.WriteLine("-----------------------------------------------------------");
            try
            {
                eleccion = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            switch (eleccion)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("Ingrese el id del registro que desea eliminar:");
                        int idRegistro = int.Parse(Console.ReadLine());
                        EmployeesLogic employeesLogic = new EmployeesLogic();
                        employeesLogic.Delete(idRegistro);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error : {ex.Message}");
                    }

                    break;
                case 2:
                    
                    try
                    {
                        Console.WriteLine("Ingrese el id del registro que desea eliminar (abreviatura del nombre --> 5 Letras):");
                        string idRegistro = Console.ReadLine();
                        CustomersLogic customersLogic = new CustomersLogic();
                        customersLogic.DeleteByString(idRegistro);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error : {ex.Message}");
                    }

                    break;
                case 3:                    
                    try
                    {
                        Console.WriteLine("Ingrese el id del registro que desea eliminar:");
                        int idRegistro = int.Parse(Console.ReadLine());
                        CategoriesLogic categoriesLogic = new CategoriesLogic();
                        categoriesLogic.Delete(idRegistro);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error :{ex.Message}");
                    }

                    break;
                case 4:
                    try
                    {
                        Console.WriteLine("Ingrese el id del registro que desea eliminar:");
                        int idRegistro = int.Parse(Console.ReadLine());
                        ShippersLogic shippersLogic = new ShippersLogic();
                        shippersLogic.Delete(idRegistro);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;
                case 5:
                    Console.WriteLine("Presione cualquier tecla para volver al menú");
                    break;
                default:
                    Console.WriteLine("(El número o letra que ingresaste no es válido)");
                    break;

            }
        }
        public static void ActualizarRegistro()
        {
            int eleccion = 0;
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Seleccione la tabla a la que desea actualizarle un registro");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("1- Empleados");
            Console.WriteLine("2- Customers");
            Console.WriteLine("3- Categorías");
            Console.WriteLine("4- Shippers");
            Console.WriteLine("5- Volver");
            Console.WriteLine("-----------------------------------------------------------");
            try
            {
                eleccion = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            switch (eleccion)
            {
                case 1:
                    string employeeFirstName = "";
                    string employeeLastName = "";
                    try
                    {
                        Console.WriteLine("Ingrese el id del registro que desea modificar:");
                        int idRegistro = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el nombre del empleado:");
                        employeeFirstName = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido del empleado:");
                        employeeLastName = Console.ReadLine();
                        if (ValidarCamposObligatorios(employeeFirstName,employeeLastName))
                        {
                            ObligatoryDataException.GetException();
                        }
                        EmployeesLogic employeesLogic = new EmployeesLogic();
                        employeesLogic.Update(new Employees
                        {
                            EmployeeID = idRegistro,
                            FirstName = employeeFirstName,
                            LastName = employeeLastName,
                            HireDate = DateTime.Now
                        });
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    break;
                case 2:
                    string customerContactName = "";
                    string customerCompanyName = "";
                    try
                    {
                        Console.WriteLine("Ingrese el id del registro que desea modificar (Formato: abreviación de 5 letras):");
                        string idRegistro = Console.ReadLine();
                        CustomersLogic customersLogic = new CustomersLogic();
                        foreach (Customers customers in customersLogic.GetAll())
                        {
                            if(idRegistro == customers.CustomerID)
                            {
                                Console.WriteLine("Ingrese el nombre del cliente:");
                                customerContactName = Console.ReadLine();
                                Console.WriteLine("Ingrese el nombre de la compañía del cliente:");
                                customerCompanyName = Console.ReadLine();
                                if (ValidarCamposObligatorios(customerCompanyName,"secondValue"))
                                {
                                    ObligatoryDataException.GetException();
                                }
                                customersLogic.Update(new Customers
                                {
                                    CustomerID = idRegistro,
                                    ContactName = customerContactName,
                                    CompanyName = customerCompanyName
                                });
                                Console.WriteLine("Registro actualizado correctamente");
                            }
                        }
                         
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    break;
                case 3:
                    string categoriesCategoryName = "";
                    string categoriesDescription = "";
                    try
                    {
                        Console.WriteLine("Ingrese el id del registro que desea modificar:");
                        int idRegistro = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el nombre de la categoría:");
                        categoriesCategoryName = Console.ReadLine();
                        if (ValidarCamposObligatorios(categoriesCategoryName,"secondValue"))
                        {
                            ObligatoryDataException.GetException();
                        }
                        Console.WriteLine("Ingrese la descripción de la categoría:");
                        categoriesDescription = Console.ReadLine();
                        CategoriesLogic categoriesLogic = new CategoriesLogic();
                        categoriesLogic.Update(new Categories
                        {
                            CategoryID = idRegistro,
                            CategoryName = categoriesCategoryName,
                            Description = categoriesDescription
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    break;
                case 4:
                    string shipperCompanyName = "";
                    try
                    {
                        Console.WriteLine("Ingrese el id del registro que desea modificar:");
                        int idRegistro = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el nombre de la compañía");
                        shipperCompanyName = Console.ReadLine();
                        if (ValidarCamposObligatorios(shipperCompanyName, "secondValue"))
                        {
                            ObligatoryDataException.GetException();
                        }
                        ShippersLogic shippersLogic = new ShippersLogic();
                        shippersLogic.Update(new Shippers
                        {
                            ShipperID = idRegistro,
                            CompanyName = shipperCompanyName                           
                        });

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;
                case 5:
                    Console.WriteLine("Presione cualquier tecla para volver al menú");
                    break;
                default:
                    Console.WriteLine("(El número o letra que ingresaste no es válido)");
                    break;
            }
        }
    }
}


