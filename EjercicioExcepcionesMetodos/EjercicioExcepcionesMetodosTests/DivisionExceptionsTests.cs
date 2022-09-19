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
    public class DivisionExceptionsTests
    {
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividirTest()
        {
            DivisionExceptions.DividirPorCero(3);
        }
    }
}