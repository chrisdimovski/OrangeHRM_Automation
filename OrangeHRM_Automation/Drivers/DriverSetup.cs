using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OrangeHRM_Automation.Drivers
{
    public static class DriverSetup
    {
        public static IWebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized"); // Start Chrome maximized
            options.AddArgument("--disable-extensions"); // Disable extensions for a clean environment
            options.AddArgument("--disable-gpu"); // Disable GPU rendering for compatibility
            return new ChromeDriver(options);
        }
    }
}
