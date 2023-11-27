using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MaraphonApp;
using MaraphonApp.Controllers;
using MaraphonApp.Models;

namespace UserControllerTests
{

    [TestClass]
    public class UnitTest1
    {
        Core context = new Core();

        [TestMethod]
        public void TestMethod1()
        {
            string email = "abcd@gmail.com";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string role = "Бегун";
            string gender = "Мужской";
            string password = "Password123*";

            DataBaseController obj = new DataBaseController();

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Marathon_db;Integrated Security=True";
            obj.DataBaseConnect(connectionString);
                
            UserController obj1 = new UserController();
            bool result = obj1.SaveRunnerData(email, firstName, lastName, role, gender, password);

            Assert.IsTrue(result);
        }
    }
}
