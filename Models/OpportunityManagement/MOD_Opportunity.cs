namespace CRM_Web_Api.Models.OpportunityManagement
{
    public class MOD_Opportunity
    {
        public int OpportunityID { get; set; }
        public string OpportunityName { get; set; }

        public int AccountID { get; set; }

        public string Stage { get; set; }

        public string Probability { get; set; }

        public string ExpectedCloseDate{ get; set; }

       
    }
}
