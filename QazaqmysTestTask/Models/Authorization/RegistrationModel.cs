using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QazaqmysTestTask.Models.Authorization
{
    public class RegistrationModel
    {
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Enter your nickname to sign up")]
        [MinLength(length: 6, ErrorMessage = "Nickname length must be at least 6 characters"), MaxLength(length: 12, ErrorMessage = "Nickname length must not be more than 12 characters")]
        [RegularExpression(pattern: @"^[a-zA-Z0-9]+$", ErrorMessage = "Incorrect value for nickname")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type your password")]
        [RegularExpression(pattern: @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{6,12}$", ErrorMessage = "Password must contain at least 1 lower//uppercase letter, number and it must fit from 6 to 12 characters")]
        [MinLength(length: 6, ErrorMessage = "Please, enter your password correctly"), MaxLength(length: 12, ErrorMessage = "Please, enter your password correctly")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Choose role")]
        public bool Role { get; set; }
    }
}
