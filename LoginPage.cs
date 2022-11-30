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
       
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Hello, sign in')]")]
        [CacheLookup]
        private IWebElement MouseHover;

        [FindsBy(How = How.XPath, Using = "//*[@id='ap_email' and @type='email']")]
        [CacheLookup]
        private IWebElement EmailTextfield;

        [FindsBy(How = How.XPath, Using = "//input[@id='continue' and @class='a-button-input']")]
        [CacheLookup]
        private IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='ap_password' and @class='a-input-text a-span12 auth-autofocus auth-required-field']")]
        [CacheLookup]
        private IWebElement Password;

        [FindsBy(How = How.XPath, Using = "//input[@id='signInSubmit' and @class='a-button-input']")]
        [CacheLookup]
        private IWebElement SigninButton;

        public void Signin(String email, String password)
        {

            MouseHover.Click();
            EmailTextfield.SendKeys(email);
            ContinueButton.Click();
            Password.SendKeys(password);
            SigninButton.Click();

        }
    }
}