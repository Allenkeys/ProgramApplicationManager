using System.ComponentModel.DataAnnotations;

namespace ProgramApplicationManager.Domain.DTOs.Request
{
    public class CreateUserRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
    }
}
