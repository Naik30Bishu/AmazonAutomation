using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TraningProject1
{
    class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            String test_url = "https://www.amazon.in/";
            driver.Url = test_url;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.Id, Using = "nav-link-accountList-nav-line-1")]
        [CacheLookup]
        private IWebElement MouseHover;

        [FindsBy(How = How.Id, Using = "ap_email")]
        [CacheLookup]
        private IWebElement EmailTextfield;

        [FindsBy(How = How.Id, Using = "continue")]
        [CacheLookup]
        private IWebElement ContinueButton;

        [FindsBy(How = How.Id, Using = "ap_password")]
        [CacheLookup]
        private IWebElement Password;

        [FindsBy(How = How.Id, Using = "signInSubmit")]
        [CacheLookup]
        private IWebElement SigninButton;

        public void Signin(String email,String password)
        {
            
            MouseHover.Click();
            EmailTextfield.SendKeys(email);
            ContinueButton.Click();
            Password.SendKeys(password);
            SigninButton.Click();

        }
    }
}
