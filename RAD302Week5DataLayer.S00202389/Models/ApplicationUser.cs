

using Microsoft.AspNetCore.Identity;

namespace WebApplicationGames.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int XP { get; set; }
        public string GamerTag { get; set; }

    }
}
