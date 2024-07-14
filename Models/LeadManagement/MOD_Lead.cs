namespace CRM_Web_Api.Models.LeadManagement
{
    public class MOD_Lead
    {
        public int LeadID { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Company { get; set; }

        public string? Status { get; set; }

        public string? Source{ get; set; }
        public int? AssignedTo { get; set; }  
    }
}
