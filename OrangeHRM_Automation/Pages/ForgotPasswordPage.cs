using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace OrangeHRM_Automation.Pages
{
    public class ForgotPasswordPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // Constructor
        public ForgotPasswordPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }

        // Locators with Explicit Waits
        private IWebElement ForgotPasswordLink => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//p[@class='oxd-text oxd-text--p orangehrm-login-forgot-header']")));
        private IWebElement UsernameField => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='username']")));
        private IWebElement ResetPasswordButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='oxd-button oxd-button--large oxd-button--secondary orangehrm-forgot-password-button orangehrm-forgot-password-button--reset']")));
        private IWebElement SuccessTitle => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h6[@class='oxd-text oxd-text--h6 orangehrm-forgot-password-title']")));

        // Actions
        public void ClickForgotPassword()
        {
            ForgotPasswordLink.Click(); // Click the "Forgot Your Password?" button
        }

        public void EnterUsername(string username)
        {
            UsernameField.SendKeys(username); // Enter the username into the input field
        }

        public void ClickResetPassword()
        {
            ResetPasswordButton.Click(); // Click the "Reset Password" button
        }

        public string GetSuccessTitle()
        {
            return SuccessTitle.Text; // Return the text of the success title
        }
    }
}
