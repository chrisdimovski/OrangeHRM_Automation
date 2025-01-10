using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace OrangeHRM_Automation.Pages
{
    /// <summary>
    /// Page Object Model for the Dashboard page of the OrangeHRM demo site.
    /// Includes actions for user interaction and logout functionality.
    /// </summary>
    public class DashboardPage
    {
        private readonly IWebDriver _driver; // WebDriver instance for browser automation
        private readonly WebDriverWait _wait; // Wait instance for explicit waits

        /// <summary>
        /// Initializes a new instance of the DashboardPage class.
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="wait">WebDriverWait instance</param>
        public DashboardPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        // Locators with explicit waits
        private IWebElement UserDropdown => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//p[@class='oxd-userdropdown-name']")));
        private IWebElement LogoutButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[.='Logout']")));

        /// <summary>
        /// Clicks on the user dropdown menu to reveal additional options.
        /// </summary>
        public void ClickUserDropdown()
        {
            Console.WriteLine("Clicking on the user dropdown menu.");
            UserDropdown.Click();
        }

        /// <summary>
        /// Clicks on the Logout button to log out the user.
        /// </summary>
        public void ClickLogout()
        {
            Console.WriteLine("Clicking on the Logout button.");
            LogoutButton.Click();
        }
    }
}
