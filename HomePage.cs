using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

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
        
        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        [CacheLookup]
        private IWebElement SearchButton;

        public void SearchProduct(string searchText)
        {
            SearchButton.SendKeys(searchText);
            SearchButton.Submit();
        }
    }
}
