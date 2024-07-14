using CRM_Web_Api.Models.LeadManagement;

namespace CRM_Web_Api.DTO.LeadManagement
{
    public class DTO_Lead
    {
        public int LeadID { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Company { get; set; }

        public string? Status { get; set; }

        public string? Source { get; set; }
        public int? AssignedTo { get; set; }
        public string? choice { get; set; }

        public MOD_Lead converttomodel()
        {
            MOD_Lead ml = new MOD_Lead();
            ml.LeadID = LeadID;
            ml.FirstName = FirstName;
            ml.LastName = LastName;
            ml.Email = Email;
            ml.PhoneNumber = PhoneNumber;
            ml.Company = Company;
            ml.Status = Status;
            ml.Source = Source;
            ml.AssignedTo = AssignedTo;

            return ml;
        }
    }
}
