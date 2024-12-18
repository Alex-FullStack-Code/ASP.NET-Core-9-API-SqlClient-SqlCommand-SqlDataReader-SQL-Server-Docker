namespace HMDB.Models.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int EmployeeId { get; set; }
        public string? SecurityQuestion { get; set; }
        public int LoginId { get; set; }
        public string? Answer { get; set; }
        public int HotelId { get; set; }
        public string? NewUser { get; set; } 
    }
}
