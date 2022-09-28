using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.TP4.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;
using Lab.TP4.EF.Entities;
using Lab.TP4.EF.Datos;

namespace Lab.TP4.EF.Logic.Tests
{
    [TestClass()]
    public class ShippersLogicTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var data = new List<Shippers>
            {
                new Shippers { CompanyName = "AAA" },
                new Shippers { CompanyName = "BBB" },
                new Shippers { CompanyName = "ZZZ" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Shippers>>();
            mockSet.As<IQueryable<Shippers>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Shippers>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Shippers>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Shippers>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(c => c.Shippers).Returns(mockSet.Object);

            var service = new ShippersLogic(mockContext.Object);
            var blogs = service.GetAll();

            Assert.AreEqual(7, blogs.Count);
            Assert.AreEqual("Speedy Express", blogs[0].CompanyName);
            Assert.AreEqual("The Boring Company", blogs[1].CompanyName);
            Assert.AreEqual("Federal Shipping", blogs[2].CompanyName);
        }
    }
}