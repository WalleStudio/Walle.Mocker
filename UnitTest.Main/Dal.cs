using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockServer.Core.Domain;
using MockServer.Dal.TCFlyMock;
using MockServer.Core.Domain.TCFlyMock;

namespace UnitTest.Main
{
    [TestClass]
    public class Dal
    {
        [TestMethod]
        public void TestInsert()
        {

            FlightMockProject entity = new FlightMockProject();
            entity.Name = "xxxxx";

            try
            {
                FlightMockProjectDal dal = new FlightMockProjectDal();
                dal.Add(entity);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
