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
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionTest()
        {
            //arrange
            decimal dividendo = 10;
            decimal divisor = 0;

            //act
            DivisionException.Division(dividendo, divisor);
            
        }
    }
}