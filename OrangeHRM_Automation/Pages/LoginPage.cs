using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace OrangeHRM_Automation.Pages
{
    /// <summary>
    /// Page Object Model for the Login page of the OrangeHRM demo site.
    /// Includes actions for login, error handling, and validations.
    /// </summary>
    public class LoginPage
    {
        private readonly IWebDriver _driver; // WebDriver instance for browser automation
        private readonly WebDriverWait _wait; // Wait instance for explicit waits

        /// <summary>
        /// Initializes a new instance of the LoginPage class.
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="wait">WebDriverWait instance</param>
        public LoginPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        // Locators with explicit waits
        private IWebElement UsernameField => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='username']")));
        private IWebElement PasswordField => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='password']")));
        private IWebElement LoginButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--main orangehrm-login-button']")));
        private IWebElement ErrorMessage => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='oxd-alert-content oxd-alert-content--error']")));

        /// <summary>
        /// Performs a login action using the provided credentials.
        /// </summary>
        /// <param name="username">The username to log in</param>
        /// <param name="password">The password to log in</param>
        public void Login(string username, string password)
        {
            // Log the login action
            Console.WriteLine($"Attempting to log in with username: {username}");

            // Enter username
            UsernameField.Clear();
            UsernameField.SendKeys(username);

            // Enter password
            PasswordField.Clear();
            PasswordField.SendKeys(password);

            // Click login button
            LoginButton.Click();

            Console.WriteLine("Login button clicked.");
        }

        /// <summary>
        /// Gets the error message displayed on the login page.
        /// </summary>
        /// <returns>The error message text</returns>
        public string GetErrorMessage()
        {
            Console.WriteLine("Fetching the error message displayed on the login page.");
            return ErrorMessage.Text;
        }

        /// <summary>
        /// Validates if the dashboard page is displayed after a successful login.
        /// </summary>
        /// <returns>True if the dashboard is displayed; otherwise, false</returns>
        public bool IsDashboardDisplayed()
        {
            Console.WriteLine("Validating if the dashboard page is displayed.");
            return _driver.Url.Contains("/dashboard");
        }

        /// <summary>
        /// Validates if the login page is displayed.
        /// </summary>
        /// <returns>True if the login page is displayed; otherwise, false</returns>
        public bool IsLoginPageDisplayed()
        {
            Console.WriteLine("Validating if the login page is displayed.");
            return _driver.Url.Contains("/auth/login");
        }
    }
}
