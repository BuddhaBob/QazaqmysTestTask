using System.ComponentModel.DataAnnotations;

namespace QazaqmysTestTask.Models.Authorization
{
    public class LoginModel
    {
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Type your nickname to sign in")]
        [MinLength(length: 6, ErrorMessage = "Please, enter your nickname correctly"), MaxLength(length: 12, ErrorMessage = "Please, enter your nickname correctly")]
        [RegularExpression(pattern: "^[a-zA-Z0-9]+$", ErrorMessage = "Incorrect value for nickname")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type your password")]
        [RegularExpression(pattern: @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{6,12}$", ErrorMessage = "Format of password is unacceptable")]
        [MinLength(length: 6, ErrorMessage = "Please, enter your password correctly"), MaxLength(length: 12, ErrorMessage = "Please, enter your password correctly")]
        public string Password { get; set; }
    }
}
