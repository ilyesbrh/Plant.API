using System.ComponentModel.DataAnnotations;

namespace Plant.API.DTOs
{
    public class RegistrationDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(16,MinimumLength=8,ErrorMessage="denial password")]
        public string Password { get; set; }
    }

        public class LoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(16,MinimumLength=8,ErrorMessage="denial password")]
        public string Password { get; set; }
    }
}