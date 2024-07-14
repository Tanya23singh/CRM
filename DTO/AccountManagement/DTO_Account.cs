using CRM_Web_Api.Models.AccountManagement;

namespace CRM_Web_Api.DTO.AccountManagement
{
    public class DTO_Account
    {
        public int AccountID { get; set; }

        public string AccountName { get; set; }
        public string choice { get; set; }
        public string Industry { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public MOD_Account converttomodel()
        {
            MOD_Account md=new MOD_Account();
            md.AccountID = AccountID;
            md.AccountName = AccountName;
            md.State = State;
            md.Address = Address;
            md.PostalCode = PostalCode;
            md.Country = Country;
            md.Industry = Industry;
            md.Website = Website;
            md.City = City;
            return md;
        }
    }
}
