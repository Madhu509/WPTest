using FluentAssertions;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using System;
using System.Collections;
using System.IO;
using WPTest.Dictionaries;
using WPTest.Models;
using WPTest.Pages;

namespace WPTest.Tests
{
    class RegistrationTests : BaseTest
    {
        public RegistrationTests(Browser browser, string version) : base(browser, version) { }

        HomePage homePage;

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage(Driver);
        }

        [TestCaseSource(nameof(UserRegistrationTestData), new object[] { "Registration" }), Order(1)]
        public void UserRegistrationTest(User userDetails, String status)
        {
            homePage.Register.Click();
            RegistrationPage registration = new RegistrationPage(Driver);
            registration.EnterUserRegistrationDetails(userDetails);
            registration.GetRegistrationMessage.Should().Be(registration.successMessage);
        }

        [TestCaseSource(nameof(UserRegistrationTestData), new object[] { "Login" }), Order(2)]
        public void UserLoginTest(User userDetails)
        {
            homePage.LoginUser(userDetails);
            RegistrationPage registration = new RegistrationPage(Driver);
            Assert.True(registration.Profile.Displayed);
            Assert.True(registration.Logout.Displayed);
        }

        [Description("User Logout Test")]
        [Test, Order(3)]
        public void UserLogoutTest()
        {
            RegistrationPage registration = new RegistrationPage(Driver);

            registration.Logout.Click();
            Assert.True(homePage.Login.Displayed);
        }

        public static IEnumerable UserRegistrationTestData(string type)
        {
            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\testData\\UserRegistration_TestData.csv")), true))
            {
                while (csv.ReadNextRecord())
                {
                    if ((type.Equals("Login") && csv["validData"].Equals("true")) || type.Equals("Registration"))
                        yield return new TestCaseData(new User()
                        {
                            Login = csv["Login"],
                            FirstName = csv["FirstName"],
                            LastName = csv["LastName"],
                            Password = csv["Password"],
                            ConfirmedPassword = csv["ConfirmPassword"]
                        }).SetName(type + " " + csv["TestDescription"]);
                }
            }
        }


    }
}
