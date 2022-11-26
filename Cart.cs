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
        private WebDriverWait wait;
        public Cart(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//div[@data-name= 'Subtotals']//span[@class = 'a-size-medium a-color-base sc-price sc-white-space-nowrap'])")]
        [CacheLookup]
        private IWebElement subTotal;

        public String GetCartPrice()
        {
            driver.Navigate().GoToUrl("https://www.amazon.in/gp/cart/view.html?ref_=nav_cart");
            String TotalSum = subTotal.Text;
            return TotalSum;
        }

    }
}
