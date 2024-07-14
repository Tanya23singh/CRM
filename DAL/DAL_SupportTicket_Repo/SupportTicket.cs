namespace CRM_Web_Api.DAL.DAL_SupportTicket_Repo
{
    public class SupportTicket
    {
        private readonly string _connectionstring;
        public SupportTicket(string connectionString)
        {
            _connectionstring = connectionString;
        }
    }
}
