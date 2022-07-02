using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class UserLoginModel
    {
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }
    }
}
