using NUnit.Framework;
using OpenQA.Selenium;
using OrangeHRM_Automation.Drivers;
using OrangeHRM_Automation.Pages;

namespace OrangeHRM_Automation.Tests
{
    /// <summary>
    /// Test suite for validating the "Forgot Your Password" functionality on the OrangeHRM demo site.
    /// </summary>
    public class ForgotPasswordTests
    {
        private IWebDriver _driver; // WebDriver instance for browser automation
        private ForgotPasswordPage _forgotPasswordPage; // Page Object Model for the Forgot Password page

        /// <summary>
        /// Sets up the WebDriver and navigates to the login page before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Initialize WebDriver
            _driver = DriverSetup.GetChromeDriver();

            // Navigate to the OrangeHRM demo login page
            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            // Initialize the ForgotPasswordPage object
            _forgotPasswordPage = new ForgotPasswordPage(_driver);
        }

        /// <summary>
        /// Test case for verifying the Forgot Password functionality.
        /// </summary>
        [Test]
        public void TestForgotPassword()
        {
            // Log what this test is doing
            TestContext.WriteLine("Starting Test: TestForgotPassword");
            TestContext.WriteLine("Verifying the Forgot Password workflow.");

            // Step 1: Select "Forgot Your Password?" button
            _forgotPasswordPage.ClickForgotPassword();

            // Step 2: Input "Admin" in the username field
            _forgotPasswordPage.EnterUsername("Admin");

            // Step 3: Select "Reset Password" button
            _forgotPasswordPage.ClickResetPassword();

            // Step 4: Verify the success title
            string actualTitle = _forgotPasswordPage.GetSuccessTitle();
            Assert.That(actualTitle, Is.EqualTo("Reset Password link sent successfully"),
                $"Expected title 'Reset Password link sent successfully', but found '{actualTitle}'.");

            // Log test success
            TestContext.WriteLine("TestForgotPassword completed: Forgot Password workflow verified successfully.");
        }

        /// <summary>
        /// Cleans up the WebDriver instance after each test.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            // Log test cleanup
            TestContext.WriteLine("Tearing down the WebDriver instance.");

            // Dispose of the WebDriver instance
            if (_driver != null)
            {
                _driver.Quit(); // Close the browser
                _driver.Dispose(); // Release WebDriver resources
            }
        }
    }
}
