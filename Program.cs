using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DynamicScraperConsoleApp;
using OpenQA.Selenium.Interactions;

// TO DO: NOW ENABLE SCRAPING OF CURRENT OFFICERS [Make it all conditional based on the presence of the button]

// to initialize the Chrome Web Driver in headless mode
var chromeOptions = new ChromeOptions();
chromeOptions.AddArguments("--headless");
var driver = new ChromeDriver(chromeOptions);


// Set the implicit wait time to allow elements to load
// This is useful for pages that load elements dynamically
// Adjust the time as necessary based on the page load speed
driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

string userInput = string.Empty;

do
{
    System.Console.WriteLine("Enter the URL of the Kentucky company profile page. Type 'exit' to quit.");
    userInput = Console.ReadLine()!;

    if (userInput.ToLower() == "exit")
    {
        System.Console.WriteLine("Exiting the program.");
        break;
    }

    try
    {
        // connecting to the target web page
        driver.Navigate().GoToUrl(userInput);
    }
    catch (System.UriFormatException)
    {
        System.Console.WriteLine("Invalid URL format. Please try again.");
        userInput = "";
    }

} while (userInput == "");


Company company = new Company();

// Company Info Nodes
var companyInfoNodes = driver.FindElements(By.XPath("//*[@id='MainContent_pInfo']/div/div/div[position() > 0 and position() < 16]"));

foreach (var node in companyInfoNodes)
{
    // Extracting the property name and value
    var propertyName = node.FindElement(By.XPath("div[1]")).Text.Trim();
    var propertyValue = node.FindElement(By.XPath("div[2]")).Text.Trim();

    switch (propertyName)
    {
        case "Organization Number":
            company.OrganizationNumber = propertyValue;
            break;
        case "Name":
            company.Name = propertyValue;
            break;
        case "Profit or Non-Profit":
            company.ProfitOrNonprofit = propertyValue;
            break;
        case "Company Type":
            company.CompanyType = propertyValue;
            break;
        case "Industry":
            company.Industry = propertyValue;
            break;
        case "Number of Employees":
            company.NumberOfEmployees = propertyValue;
            break;
        case "Primary County":
            company.PrimaryCounty = propertyValue;
            break;
        case "Status":
            company.Status = propertyValue;
            break;
        case "Standing":
            company.Standing = propertyValue;
            break;
        case "State":
            company.State = propertyValue;
            break;
        case "File Date":
            company.FileDate = propertyValue;
            break;
        case "Authority Date":
            company.AuthorityDate = propertyValue;
            break;
        case "Last Annual Report":
            company.LastAnnualReport = propertyValue;
            break;
        case "Principal Office":
            company.PrincipalOffice = propertyValue;
            break;
        case "Registered Agent":
            company.RegisteredAgent = propertyValue;
            break;
        case "Country":
            company.Country = propertyValue;
            break;
        case "Managed By":
            company.ManagedBy = propertyValue;
            break;
    }
}

// Try-Catch -- Get the Initial Officers Button
try
{
    IWebElement OpenInitialOfficersTab = driver.FindElement(By.Id("MainContent_BtnInitial"));
    // Scroll to the Initial Officers Button
new Actions(driver)
                .ScrollToElement(OpenInitialOfficersTab)
                .Perform();

// Click the Initial Officers Button
OpenInitialOfficersTab.Click();

// Get Nodes for Initial Officers
var officerNodes = driver.FindElements(By.XPath("//*[@id='MainContent_pInitial']/div/div[position() > 0 and position() < 4]"));

foreach (var officerNode in officerNodes)
{
    // Extracting the officer's name and title
    var propertyName = officerNode.FindElement(By.XPath("div[1]")).Text.Trim();
    var propertyValue = officerNode.FindElement(By.XPath("div[2]")).Text.Trim();

    switch (propertyName)
    {
        case "Organizer":
            company.Organizer = propertyValue;
            break;
            // Add more cases for other officer properties if needed
            // For example, if there are titles or roles, you can add them here
            // case "Title":
            //     company.Title = propertyValue;
            //     break;
    }
}

}
catch (System.Exception)
{
    System.Console.WriteLine("Initial Officers Button not found. Skipping initial officers extraction.");
}

// Print out the company object to the console; Print out only the fields that are not null or empty

System.Console.WriteLine(company.ToString());

// Load the Word Document		
