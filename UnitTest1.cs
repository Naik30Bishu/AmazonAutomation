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
            homepage.SearchProduct("Apple iPhone 13 (128GB) - Green");

            ProductDetails productpage = new ProductDetails(driver);
            productpage.ProductSelection("Apple iPhone 13 (128GB) - Green");
            productpage.ProceedToPayment();
        }

        [Test]
        public void CheckProductPriceOnSearchPage()
        {
            HomePage homepage = new HomePage(driver);
            homepage.SearchProduct("Apple iPhone 13 (128GB) - Green");

            ProductDetails productpage = new ProductDetails(driver);
            String DisplayProductPrice = productpage.getPriceFromSearchPage("Apple iPhone 13 (128GB) - Green");
            Assert.AreEqual("65,999", DisplayProductPrice, "Price does not Match");
        }

        [TestCase("Apple iPhone 13 (128GB) - Green", "65,999")]
        [TestCase("Apple iPhone 12 (64GB) - (Product) RED", "48,999")]
        
        public void CheckProductPriceOnProductPage(String productName , String ExpectedPrice)
        {
            HomePage homepage = new HomePage(driver);
            homepage.SearchProduct(productName);

            ProductDetails productpage = new ProductDetails(driver);
            String ActualPrice = productpage.getPriceFromProductPage(productName);
            Assert.AreEqual(ExpectedPrice, ActualPrice, "Price does not Match");
        }

        //[TestCase("Apple iPhone 13 (128GB) - Green", "65,999")]
        [TestCase(new String[] { "Apple iPhone 13 (128GB) - Green" , "Apple iPhone 13 (128GB) - Green" }, new int[] { 65999, 65999 })]
        [Test]
        public void CheckFinalCartPrice(String[] productName, int[] ExpectedPrice)
        {
            
            int Expectedsum = 0;
            int Actualsum = 0;
            for (int i = 0; i < productName.Length; i++)
            {
                HomePage homepage = new HomePage(driver);
                homepage.SearchProduct(productName[0]);

                ProductDetails productpage = new ProductDetails(driver);
                productpage.ProductSelection(productName[0]);
                Expectedsum = Expectedsum + ExpectedPrice[i];
                homepage.GoToHome();

            }
            Assert.AreEqual(Expectedsum, Actualsum, "Price does not Match");
        }

        [TearDown]
        public void closeBrowser()
        {
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}