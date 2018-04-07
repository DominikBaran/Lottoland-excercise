using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace Lottoland
{
    [TestFixture]
    public class Lottoland
    {
        Model.RegisterPage registerPage = new Model.RegisterPage();
        List<KeyValuePair<string, string>> randomUsers;

        [SetUp]
        public void Setup()
        {
            var browserName = Helpers.ConfigHelper.GetBrowser();
            Helpers.DriverHelper.InitializeDriver(browserName);
            Helpers.DriverHelper.NavigateToPage(Helpers.ConfigHelper.GetTestPageUrl());
            registerPage.InitElements();
        }

        [TearDown]
        public void TearDown()
        {
            var unregisteredUsers = Data.TestUsers.GetUnregisteredUsers(randomUsers);
            Console.WriteLine("List of unregistered users:");
            foreach (var user in unregisteredUsers)
            {
                Console.WriteLine($"First name: {user.Key}, last name: {user.Value}");
            }
            Helpers.DriverHelper.CloseDriver();
        }

        [Test]
        public void RegisterRandomUsers()
        {
            randomUsers = Data.TestUsers.GetRandomUsers(5);
            Console.WriteLine("Users to register:");
            foreach (var user in randomUsers)
            {
                Console.WriteLine($"First name: {user.Key}, last name: {user.Value}");
            }
            foreach (var user in randomUsers)
            {
                Assert.True(registerPage.PageUrlIsValid(), "Page url is invalid.");
                var firstName = user.Key;
                var lastName = user.Value;
                Assert.True(registerPage.RegisterUser(firstName, lastName), $"Cannot register new user: first name: {firstName}, last name: {lastName}");
            }
        }
    }
}
