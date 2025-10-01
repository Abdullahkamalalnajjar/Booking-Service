using Microsoft.AspNetCore.Identity;

namespace Project.Data.Entities
{
    public sealed class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public bool IsDisable { get; set; } = false;
        public int? ServiceId { get; set; }
        public string? StripeAccountId { get; set; }
        public ServiceCategory? Service { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
