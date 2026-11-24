using PizzaLib.Models;
using PizzaLib.Services;
using PizzaLib.Exceptions;

namespace RepositoryTests
{
    [TestClass]
    public sealed class CustomerRepositoryTest
    {
        CustomerRepository repo;

        private void Arrange()
        {
            repo = new CustomerRepository();
        }
        
        [TestMethod]
        public void RemoveCustomerTest()
        {
            Arrange();
            repo.AddCustomer(new Customer("test", "test", "test"));
            double countBefore = repo.Count;

            repo.RemoveCustomer("test");
            double countAfter = repo.Count;

            Assert.AreEqual(countBefore - 1, countAfter, 0.01, "Fail RemoveCustomer");
        }

        [TestMethod]
        public void AddCustomerTest()
        {
            Arrange();
            double countBefore = repo.Count;

            repo.AddCustomer(new Customer("test", "test", "test"));
            double countAfter = repo.Count;

            Assert.AreEqual(countBefore + 1, countAfter, 0.01, "Fail AddCustomer");
        }

        [TestMethod]
        public void AddCustomerExceptionTest()
        {
            Arrange();
            repo.AddCustomer(new Customer("test", "test", "test"));

            Assert.ThrowsExactly<CustomerMobileNumberExistsException>(() =>
            {
                repo.AddCustomer(new Customer("test", "test", "test"));
            }, "Fail AddCustomerException");
        }

        [TestMethod]
        public void GetByAreaTest()
        {
            Arrange();
            repo.AddCustomer(new Customer("test", "test", "test"));
            int expectedResult = 1;

            int actualResult = repo.GetByArea("test").Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetByAreaEmptyTest()
        {
            Arrange();
            int expectedResult = 0;

            int actualResult = repo.GetByArea("test").Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
