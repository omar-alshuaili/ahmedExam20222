using System.ComponentModel.DataAnnotations;

namespace RAD302Week5DataLayer.ppowell.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string GameTag { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
