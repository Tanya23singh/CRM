using CRM_Web_Api.Models.MarketingCampaignManagement;

namespace CRM_Web_Api.DTO.CampaignManagement
{
    public class DTO_Campaign
    {
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }

        public string Type { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Budget { get; set; }
        public string choice { get; set; }

        public MOD_Campaign converttomodel()
        {
            MOD_Campaign mc = new MOD_Campaign();
            mc.CampaignID = CampaignID;
            mc.CampaignName = CampaignName;
            mc.Type = Type;
            mc.StartDate = StartDate;
            mc.EndDate = EndDate;
            mc.Budget = Budget;
            return mc;

        }
    }
}
