using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRM_Automation.Drivers;
using OrangeHRM_Automation.Pages;
using SeleniumExtras.WaitHelpers;
using System;

namespace OrangeHRM_Automation.Tests
{
    /// <summary>
    /// BaseTest provides common setup, teardown, and utility methods for all test classes.
    /// This class ensures reusability and maintainability across the framework.
    /// </summary>
    public abstract class BaseTest
    {
        protected IWebDriver _driver; // WebDriver instance for browser automation
        protected LoginPage _loginPage; // Page Object Model for the Login page
        protected WebDriverWait _wait; // Wait instance for explicit waits

        /// <summary>
        /// Setup method executed before each test.
        /// Initializes the WebDriver, Wait instance, and LoginPage object.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Initialize WebDriver (e.g., ChromeDriver) from DriverSetup
            _driver = DriverSetup.GetChromeDriver();

            // Initialize explicit wait with a timeout of 10 seconds
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            // Navigate to the OrangeHRM login page
            TestContext.WriteLine("Navigating to the OrangeHRM login page.");
            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            // Initialize the LoginPage object
            TestContext.WriteLine("Initializing LoginPage object.");
            _loginPage = new LoginPage(_driver, _wait);
        }

        /// <summary>
        /// Performs a login operation using the provided credentials.
        /// Ensures successful navigation to the dashboard page.
        /// </summary>
        /// <param name="username">The username to log in</param>
        /// <param name="password">The password to log in</param>
        protected void PerformLogin(string username, string password)
        {
            TestContext.WriteLine($"Attempting login with username: {username}");

            // Use LoginPage's Login method to enter credentials and submit
            _loginPage.Login(username, password);

            // Verify successful navigation to the dashboard
            bool isDashboardDisplayed = _loginPage.IsDashboardDisplayed();
            Assert.That(isDashboardDisplayed, "Failed to navigate to the dashboard after login.");

            TestContext.WriteLine("Login successful: Navigated to the dashboard.");
        }

        /// <summary>
        /// Teardown method executed after each test.
        /// Ensures the WebDriver instance is properly disposed to free up resources.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            TestContext.WriteLine("Tearing down WebDriver instance.");

            // Dispose of the WebDriver instance
            if (_driver != null)
            {
                _driver.Quit(); // Close the browser
                _driver.Dispose(); // Release resources
                TestContext.WriteLine("WebDriver instance successfully disposed.");
            }
        }
    }
}
