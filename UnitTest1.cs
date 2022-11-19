using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TraningProject1
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            LoginPage loginpage = new LoginPage(driver);
            loginpage.Signin("email", "Password1");

            HomePage homepage = new HomePage(driver);
            homepage.SearchProduct("Mobile");

            ProductDetails productpage = new ProductDetails(driver);
            productpage.ProductSelection();
            productpage.ProceedToPayment();
        }

        [TearDown]
        public void closeBrowser()
        {
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}