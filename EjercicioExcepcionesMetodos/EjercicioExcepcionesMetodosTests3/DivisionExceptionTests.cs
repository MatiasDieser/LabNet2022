using Microsoft.VisualStudio.TestTools.UnitTesting;
using EjercicioExcepcionesMetodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioExcepcionesMetodos.Tests
{
    [TestClass()]
    public class DivisionExceptionTests
    {
        [TestMethod()]
        public void DivisionTest()
        {
            //arrange
            decimal dividendo = 10;
            decimal divisor = 5;
            decimal valorEsperado = 2;

            //act 
            DivisionException.Division(dividendo, divisor);
            decimal resultado = dividendo / divisor;

            //assert
            Assert.AreEqual(valorEsperado, resultado);
        }
    }
}