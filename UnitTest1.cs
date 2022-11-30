using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Globalization;
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
            LoginPage loginpage = new LoginPage(driver);
            loginpage.Signin("6239593362", "Password1");
        }

        [Test]
        public void AddFirstProductToCart()
        {
            HomePage homepage = new HomePage(driver);
            homepage.SearchProduct("Apple iPhone 14 128GB Purple");
            ProductDetails productpage = new ProductDetails(driver);
            productpage.ProductSelection("Apple iPhone 14 128GB Purple");
            productpage.ProceedToPayment();
        }

        [Test]
        public void CheckProductPriceOnSearchPage()
        {
            HomePage homepage = new HomePage(driver);
            homepage.SearchProduct("Apple iPhone 13 Mini (256 GB) - Green");
            ProductDetails productpage = new ProductDetails(driver);
            String DisplayProductPrice = productpage.getPriceFromSearchPage("Apple iPhone 13 Mini (256 GB) - Green");
            Assert.AreEqual("74,900", DisplayProductPrice, "Price does not Match");
        }

        [TestCase("Apple iPhone 13 Pro (256GB) - Gold", "1,17,900")]
        [TestCase("Apple iPhone 13 Mini (256GB) - Starlight", "74,900")]

        public void CheckProductPriceOnProductPage(string productName, String ExpectedPrice)
        {
            HomePage homepage = new HomePage(driver);
            homepage.SearchProduct(productName);
            ProductDetails productpage = new ProductDetails(driver);
            String ActualPrice = productpage.getPriceFromProductPage(productName);
            Assert.AreEqual(ExpectedPrice, ActualPrice, "Price does not Match");
        }


        [TestCase(new String[] { "Apple iPhone 14 256GB Midnight", "Ikigai: The Japanese secret to a long and happy life" }, new int[] { 88400, 350 })]
        [Test]
        public void CheckFinalCartPrice(String[] productName, int[] ExpectedPrice)
        {

            int Expectedsum = 0;
            for (int i = 0; i < productName.Length; i++)
            {
                HomePage homepage = new HomePage(driver);
                homepage.SearchProduct(productName[i]);
                ProductDetails productpage = new ProductDetails(driver);
                productpage.ProductSelection(productName[i]);
                Expectedsum = Expectedsum + ExpectedPrice[i];
                homepage.GoToHome();

            }
            Cart cartpage = new Cart(driver);
            string output = cartpage.GetCartPrice();
            string newActualamount = output.Replace(",", "");
            newActualamount = newActualamount.Replace(" ", "");
            int index = newActualamount.IndexOf('.');
            newActualamount = newActualamount.Substring(0, index);
            int newIntActualAmount = int.Parse(newActualamount);
            Assert.AreEqual(Expectedsum, newIntActualAmount, output);
        }

        [TearDown]
        public void closeBrowser()
        {
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}