using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace TraningProject1
{
    class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='twotabsearchtextbox' and @class='nav-input nav-progressive-attribute']")]
        [CacheLookup]
        private IWebElement SearchButton;

        public void GoToHome()
        {
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            Thread.Sleep(1000);
        }

        public void SearchProduct(string searchText)
        {
            SearchButton.SendKeys(searchText);
            SearchButton.Submit();
        }
    }
}