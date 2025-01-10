using NUnit.Framework;
using OrangeHRM_Automation.Pages;

namespace OrangeHRM_Automation.Tests
{
    /// <summary>
    /// Test suite for validating logout functionality on the OrangeHRM demo site.
    /// Includes positive test case for logging out after a successful login.
    /// </summary>
    public class LogoutTests : BaseTest
    {
        private DashboardPage _dashboardPage; // Page Object Model for the Dashboard page

        /// <summary>
        /// Sets up the required pages before each test.
        /// </summary>
        [SetUp]
        public void InitializePages()
        {
            // Initialize the DashboardPage object with _driver and _wait
            _dashboardPage = new DashboardPage(_driver, _wait);

            // Reuse the PerformLogin method from BaseTest
            PerformLogin("Admin", "admin123");

            // Verify successful login
            Assert.That(_loginPage.IsDashboardDisplayed(), "Failed to navigate to the dashboard after login.");
        }

        /// <summary>
        /// Test case for verifying successful logout.
        /// </summary>
        [Test]
        public void TestSuccessfulLogout()
        {
            // Log what this test is doing
            TestContext.WriteLine("Starting Test: TestSuccessfulLogout");
            TestContext.WriteLine("Verifying that the user can successfully log out.");

            // Perform the logout
            _dashboardPage.ClickUserDropdown();
            _dashboardPage.ClickLogout();

            // Verification: Assert that the user is redirected to the login page
            Assert.That(_loginPage.IsLoginPageDisplayed(), "Failed to navigate back to the login page after logout.");

            // Log test success
            TestContext.WriteLine("TestSuccessfulLogout completed: User successfully logged out and navigated to the login page.");
        }
    }
}
