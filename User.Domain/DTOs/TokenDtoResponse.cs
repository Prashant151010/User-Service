namespace User.Domain.DTOs
{
    public class TokenDtoResponse
    {
        public int UserID { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? EmailAddr { get; set; }
        public int? IsLoggedIn { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? Disabled { get; set; }
        public bool? IsLocked { get; set; }
        public string? Mobile { get; set; }
        public string? Roles { get; set; }
        public string? Token { get; set; }
        public string? Homepage { get; set; }
        public DateTime? TokenExpiry { get; set; }
        public int SessionTimeout { get; set; }
    }
}
