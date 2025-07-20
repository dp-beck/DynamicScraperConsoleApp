namespace DynamicScraperConsoleApp
{
    public class Company
    {
        public string? OrganizationNumber { get; set; }
        public string? Name { get; set; }
        public string? ProfitOrNonprofit { get; set; }
        public string? CompanyType { get; set; }
        public string? Industry { get; set; }
        public string? NumberOfEmployees { get; set; }
        public string? PrimaryCounty { get; set; }
        public string? Status { get; set; }
        public string? Standing { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? FileDate { get; set; }
        public string? AuthorityDate { get; set; }
        public string? LastAnnualReport { get; set; }
        public string? PrincipalOffice { get; set; }
        public string? ManagedBy { get; set; }
        public string? RegisteredAgent { get; set; }
        public string? Organizer { get; set; }

        public override string ToString()
        {
            return $"Organization Number: {OrganizationNumber ?? "Not Provided"} \n" +
                    $"Name: {Name ?? "Not Provided"} \n" +
                    $"Profit or Non-Profit: {ProfitOrNonprofit ?? "Not Provided"} \n" +
                    $"Company Type: {CompanyType ?? "Not Provided"} \n" +
                    $"Industry: {Industry ?? "Not Provided"} \n" +
                    $"Number of Employees: {NumberOfEmployees ?? "Not Provided"} \n" +
                    $"Primary County: {PrimaryCounty ?? "Not Provided"} \n" +
                    $"Status: {Status ?? "Not Provided"} \n" +
                    $"Standing: {Standing ?? "Not Provided"} \n" +
                    $"State: {State ?? "Not Provided"} \n" +
                    $"Country: {Country ?? "Not Provided"} \n" +
                    $"File Date: {FileDate ?? "Not Provided"} \n" +
                    $"Authority Date: {AuthorityDate ?? "Not Provided"} \n" +
                    $"Last Annual Report: {LastAnnualReport ?? "Not Provided"} \n" +
                    $"Principal Office: {PrincipalOffice ?? "Not Provided"} \n" +
                    $"Registered Agent: {RegisteredAgent ?? "Not Provided"} \n" +
                    $"Managed By: {ManagedBy ?? "Not Provided"} \n" +
                    $"Organizer: {Organizer ?? "Not Provided"} \n";
        }
    }
}

