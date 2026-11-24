using PizzaLib.Exceptions;
using PizzaLib.Interfaces;
using PizzaLib.Models;
using PizzaLib.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryTests
{
    [TestClass]
    public sealed class MenuItemRepositoryTest
    {
        private MenuItemRepository repo;

        private void Arrange()
        {
            repo = new MenuItemRepository();
        }

        [TestMethod]
        public void RemoveMenuItemTest()
        {
            Arrange();
            IMenuItem testItem = new MenuItem("test", 10, "test", MenuType.PIZZECLASSICHE);
            repo.AddMenuItem(testItem);
            double countBefore = repo.Count;

            repo.RemoveMenuItem(testItem.No);
            double countAfter = repo.Count;

            Assert.AreEqual(countBefore - 1, countAfter, 0.01, "Fail RemoveMenuItem");
        }

        [TestMethod]
        public void AddMenuItemTest()
        {
            Arrange();
            double countBefore = repo.Count;

            repo.AddMenuItem(new MenuItem("test", 10, "test", MenuType.PIZZECLASSICHE));
            double countAfter = repo.Count;

            Assert.AreEqual(countBefore + 1, countAfter, 0.01, "Fail AddMenuItem");
        }

        [TestMethod]
        public void GetItemsByTypeTest()
        {
            Arrange();
            repo.AddMenuItem(new MenuItem("test1", 10, "test", MenuType.SANDWICHES));
            repo.AddMenuItem(new MenuItem("test2", 10, "test", MenuType.SANDWICHES));
            repo.AddMenuItem(new MenuItem("test3", 10, "test", MenuType.SANDWICHES));
            repo.AddMenuItem(new MenuItem("test4", 10, "test", MenuType.SANDWICHES));
            int expectedResult = 4;

            int actualResult = repo.GetItemsByType(MenuType.SANDWICHES).Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
