using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class UserCreateModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100)]
        [Display(Name = "Username:")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat Password:")]
        public string RepeatPassword { get; set; }
    }
}
