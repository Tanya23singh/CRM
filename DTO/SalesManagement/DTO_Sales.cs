using CRM_Web_Api.Models.SalesManagement;

namespace CRM_Web_Api.DTO.SalesManagement
{
    public class DTO_Sales
    {
        public int SalesID { get; set; }
        public int OpportunityID { get; set; }

        public string Amount { get; set; }

        public string CloseDate { get; set; }
        public string choice { get; set; }


        public MOD_Sales converttomodel()
        {
            MOD_Sales ms = new MOD_Sales();
            ms.SalesID=SalesID;
            ms.OpportunityID=OpportunityID; ;
            ms.Amount=Amount;
            ms.CloseDate = CloseDate;

            return ms;

        }
    }
}
