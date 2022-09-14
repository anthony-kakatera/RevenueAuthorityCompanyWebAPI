namespace RevenueAuthorityCompanyWebAPI.Models
{
    public class Employee
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string email { get; set; }
        public Company Company { get; set; }
    }
}
