using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace TraningProject1
{
    internal class Cart
    {
        private IWebDriver driver;
        public Cart(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//div[@data-name= 'Subtotals']//child::span[@class = 'a-size-medium a-color-base sc-price sc-white-space-nowrap'])")]
        [CacheLookup]
        private IWebElement subTotal;

        [FindsBy(How = How.XPath, Using = "//*[@id='nav-cart' and @class='nav-a nav-a-2 nav-progressive-attribute']")]
        [CacheLookup]
        private IWebElement CartPage;

        public String GetCartPrice()
        {
            CartPage.Click();
            String TotalSum = subTotal.Text;
            return TotalSum;
        }

    }
}