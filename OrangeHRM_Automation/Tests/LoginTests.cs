using NUnit.Framework;
using OrangeHRM_Automation.Pages;

namespace OrangeHRM_Automation.Tests
{
    /// <summary>
    /// Test suite for validating the login functionality (positive and negative scenarios) on the OrangeHRM demo site.
    /// Inherits common setup and teardown functionality from BaseTest.
    /// </summary>
    public class LoginTests : BaseTest
    {
        /// <summary>
        /// Test case for verifying successful login with valid credentials.
        /// </summary>
        [Test]
        public void TestSuccessfulLogin()
        {
            // Log what this test is about to do
            TestContext.WriteLine("Starting Test: TestSuccessfulLogin");
            TestContext.WriteLine("Verifying login with valid credentials (Admin / admin123).");

            // Reuse the PerformLogin method from BaseTest
            PerformLogin("Admin", "admin123");

            // Verification: Assert successful navigation to the dashboard
            Assert.That(_loginPage.IsDashboardDisplayed(), "Failed to navigate to the dashboard after login.");

            // Log test success
            TestContext.WriteLine("TestSuccessfulLogin completed: User successfully navigated to the dashboard.");
        }

        /// <summary>
        /// Test case for verifying login with invalid credentials.
        /// </summary>
        [Test]
        public void TestInvalidLogin()
        {
            // Log what this test is about to do
            TestContext.WriteLine("Starting Test: TestInvalidLogin");
            TestContext.WriteLine("Verifying login with invalid credentials (InvalidUser / InvalidPassword).");

            // Perform login with invalid credentials
            _loginPage.Login("InvalidUser", "InvalidPassword");

            // Verification: Assert that the error message is displayed
            string actualErrorMessage = _loginPage.GetErrorMessage();
            Assert.That(actualErrorMessage, Is.EqualTo("Invalid credentials"),
                $"Expected error message 'Invalid credentials', but found '{actualErrorMessage}'.");

            // Log test success
            TestContext.WriteLine("TestInvalidLogin completed: Error message displayed as expected.");
        }
    }
}
