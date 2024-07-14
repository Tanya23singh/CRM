namespace CRM_Web_Api.Models.MarketingCampaignManagement
{
    public class MOD_Campaign
    {
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }

        public string Type { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Budget { get; set; }

       
    }
}
