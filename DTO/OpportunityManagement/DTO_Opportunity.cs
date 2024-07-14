using CRM_Web_Api.Models.OpportunityManagement;

namespace CRM_Web_Api.DTO.OpportunityManagement
{
    public class DTO_Opportunity
    {
        public int OpportunityID { get; set; }
        public string OpportunityName { get; set; }

        public int AccountID { get; set; }

        public string Stage { get; set; }

        public string Probability { get; set; }

        public string ExpectedCloseDate { get; set; }
        public string choice { get; set; }

        public MOD_Opportunity converttomodel()
        {
            MOD_Opportunity mo = new MOD_Opportunity();
            mo.OpportunityID = OpportunityID;
            mo.OpportunityName = OpportunityName;
            mo.AccountID=AccountID;
            mo.Stage = Stage;
            mo.Probability = Probability;   
            mo.ExpectedCloseDate=ExpectedCloseDate;
            return mo;

        }
    }
}
