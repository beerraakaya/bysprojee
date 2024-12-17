using System.ComponentModel.DataAnnotations;

namespace bysprojee.Model
{
    public class ForgotPassword
    { 
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
