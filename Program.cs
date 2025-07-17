using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DynamicScraperConsoleApp;

// TO DO: FIGURE OUT HOW TO USE SELENIUM TO CLICK THE INITIAL OFFICERS TAB THEN SCRAPE

// the URL of the target SOS page
string url = "https://sosbes.sos.ky.gov/BusSearchNProfile/Profile.aspx/?ctr=1374673";

// to initialize the Chrome Web Driver in headless mode
var chromeOptions = new ChromeOptions();
chromeOptions.AddArguments("--headless");
var driver = new ChromeDriver(chromeOptions);

// connecting to the target web page
driver.Navigate().GoToUrl(url);

// Company Info Nodes
var nodes = driver.FindElements(By.XPath("//*[@id='MainContent_pInfo']/div/div/div[position() > 0 and position() < 16]"));

Company company = new Company();
foreach (var node in nodes)
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

// Print out the company object to the console

System.Console.WriteLine("Organization Number: " + company.OrganizationNumber);
System.Console.WriteLine("Name: " + company.Name);
System.Console.WriteLine("Profit or Nonprofit: " + company.ProfitOrNonprofit);
System.Console.WriteLine("Company Type: " + company.CompanyType);
System.Console.WriteLine("Industry: " + company.Industry);
System.Console.WriteLine("Number of Employees: " + company.NumberOfEmployees);
System.Console.WriteLine("Primary County: " + company.PrimaryCounty);
System.Console.WriteLine("Status: " + company.Status);
System.Console.WriteLine("Standing: " + company.Standing);
System.Console.WriteLine("State: " + company.State);
System.Console.WriteLine("File Date: " + company.FileDate);
System.Console.WriteLine("Authority Date: " + company.AuthorityDate);
System.Console.WriteLine("Last Annual Report: " + company.LastAnnualReport);
System.Console.WriteLine("Principal Office: " + company.PrincipalOffice);
System.Console.WriteLine("Registered Agent: " + company.RegisteredAgent);
// Add more fields as needed

// Load the Word Document		

// Click Initial Officers Tab