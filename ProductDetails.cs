using System;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace TraningProject1
{
    class ProductDetails
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public ProductDetails(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//span[starts-with(@class,'a-size-medium a-color-base a-text-normal')])[1]")]
        [CacheLookup]
        private IWebElement Product1;

        [FindsBy(How = How.XPath, Using = "(//input[starts-with(@id,'add-to-cart-button')])")]
        [CacheLookup]
        private IWebElement AddToCart;

        [FindsBy(How = How.XPath, Using = "(//*[@id='sc-buy-box-ptc-button']/span/input)")] 
        [CacheLookup]
        private IWebElement ProceedToPay;


        public void ProductSelection()
        {
            Product1.Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement Search = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//input[starts-with(@id,'add-to-cart-button')])")));
            IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(AddToCart));
            AddToCart.Submit();
            
        }

        public void ProceedToPayment()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement ProceedButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ProceedToPay));
            ProceedToPay.Submit();
        }
    }
}
