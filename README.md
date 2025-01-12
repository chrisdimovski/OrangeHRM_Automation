
OrangeHRM Automation Project
============================

Automated testing for the OrangeHRM Demo site using NUnit, Selenium WebDriver, and C#.
This project uses the Page Object Model (POM) design pattern for better test scalability and maintenance.

-----------------------------------
Project Structure:
-----------------------------------
OrangeHRM_Automation/
│
├── Pages/                  # Page Object Model classes
│   ├── LoginPage.cs
│   ├── DashboardPage.cs
│   └── ForgotPasswordPage.cs
│
├── Tests/                  # Test Scripts
│   ├── LoginTests.cs
│   ├── LogoutTests.cs
│   └── ForgotPasswordTests.cs
│
├── Drivers/                # WebDriver setup
│   └── WebDriverManager.cs
│
├── Utils/                  # Utility classes (if needed)
│
├── README.txt               # Project setup and test execution instructions
│
├── OrangeHRM_Automation.csproj  # Project configuration file
│
├── .gitignore
└── packages.config          # NuGet package references

-----------------------------------
Setup Instructions:
-----------------------------------
1. Prerequisites:
   - Visual Studio Code installed
   - .NET SDK installed
   - Chrome browser installed

2. Clone the Repository:
   git clone <repository-url>
   cd OrangeHRM_Automation

3. Install Required Packages:
   dotnet add package NUnit
   dotnet add package NUnit3TestAdapter
   dotnet add package Microsoft.NET.Test.Sdk
   dotnet add package Selenium.WebDriver
   dotnet add package Selenium.WebDriver.ChromeDriver
   dotnet add package Selenium.Support

4. Build the Project:
   dotnet build

5. Run Tests:
   - Using Terminal: dotnet test
   - Using Test Explorer in VS Code: View > Test Explorer > Run All Tests

-----------------------------------
Page Object Model (POM) Explanation:
-----------------------------------
The project uses POM to separate test logic from UI interaction.
1. Pages: Contains individual page classes with UI elements and actions.
2. Tests: Contains test logic using the page classes.
3. Drivers: Handles WebDriver setup and teardown.

-----------------------------------
Assumptions & Best Practices:
-----------------------------------
- Selenium WebDriver used for automation
- NUnit for test execution and assertions
- Chrome Browser as default
- Page Factory implemented with Selenium.Support

-----------------------------------
Troubleshooting:
-----------------------------------
- Driver Not Found? Update ChromeDriver using:
  dotnet add package Selenium.WebDriver.ChromeDriver

- Tests Not Discovered? Ensure NUnit3TestAdapter and Microsoft.NET.Test.Sdk are installed.
