using CRM_Web_Api.Models.ContactManagement;

namespace CRM_Web_Api.DTO.ContactManagement
{
    public class DTO_Contact
    {
        public int ContactID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Notes { get; set; }
        public int AccountID { get; set; }

        public string choice { get; set; }

        public MOD_Contact converttomodel()
        {
            MOD_Contact mc = new MOD_Contact();
            mc.ContactID = ContactID;
            mc.FirstName = FirstName;
            mc.LastName = LastName;
            mc.Email= Email;
            mc.PhoneNumber = PhoneNumber;
            mc.Address = Address;
            mc.City = City;
            mc.State = State;
            mc.PostalCode = PostalCode;
            mc.Country = Country;
            mc.Notes = Notes;
            mc.AccountID=AccountID;
            return mc;
        }


    }
}
