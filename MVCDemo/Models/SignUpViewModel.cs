using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.Models
{
    public class SignUpViewModel
    {
        [Required]
        [RegularExpression(@"^[A-Z][^*|\"":<>[\]{}?#`\%_\()'=;@&$!]+$", ErrorMessage = "Not a valid name!")]
        [MaxLength(17)]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z][^*|\"":<>[\]{}?#`\%_\()'=;@&$!]+$", ErrorMessage = "Not a valid name!")]
        [MaxLength(17)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Not a valid Email Address")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(12)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
