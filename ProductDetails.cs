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

        [FindsBy(How = How.XPath, Using = "(//input[starts-with(@id,'add-to-cart-button')])")]
        [CacheLookup]
        private IWebElement AddToCart;

        
        [FindsBy(How = How.XPath, Using = "(//*[@value='Proceed to checkout'])")]
        [CacheLookup]
        private IWebElement ProceedToPay;

        private void SearchProducts(String productName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            int trail = 0;

            while (trail < 5)
            {
                try
                {
                    IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='" + productName + "']")));
                    SearchResult.Click();
                    break;
                }
                catch (Exception ex)
                {
                    driver.Navigate().Refresh();
                    trail++;
                    continue;
                }
            }
            driver.SwitchTo().Window(driver.WindowHandles[1]);
        }

        public void ProductSelection(String productName)
        {
            SearchProducts(productName);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement Search = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//input[starts-with(@id,'add-to-cart-button')])")));
            IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(AddToCart));
            AddToCart.Submit();

        }

        public String getPriceFromSearchPage(String productName)
        {
            IWebElement DisplayPriceElement = driver.FindElement(By.XPath("//span[contains(text() ,'" + productName + "') ]/ancestor::div[contains(@class, 'a-section a-spacing-small a-spacing-top-small')]//span[contains(@class, 'a-price-whole')]"));
            String priceElement = DisplayPriceElement.Text;
            return priceElement;
        }

        public String getPriceFromProductPage(String productName)
        {
            SearchProducts(productName);
            Thread.Sleep(1000);
            IWebElement DisplayPriceElement = driver.FindElement(By.XPath("//*[@id='corePriceDisplay_desktop_feature_div']//span[contains(@class, 'a-price-whole')]"));
            String priceElement = DisplayPriceElement.Text;
            return priceElement;
        }

        public String getPriceFromCheckoutPage(String productName)
        {
            ProductSelection(productName);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement Search = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='attach-accessory-cart-subtotal']")));
            String priceElement = Search.Text;
            return priceElement;
        }

        public void ProceedToPayment()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement ProceedButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ProceedToPay));
            ProceedToPay.Submit();
        }
    }
}