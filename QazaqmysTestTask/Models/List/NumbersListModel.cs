using QazaqmysTestTask.Models.EF;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QazaqmysTestTask.Models.List
{
    public class NumbersListModel
    {
        [Required]
        [RegularExpression(@"(\+7|8|\b)[\(\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[)\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)", ErrorMessage = "Please enter valid phone number")]
        [MinLength(5, ErrorMessage = "Minimum length of number must be 5 digits"), MaxLength(15, ErrorMessage = "Maximum length of number is 15 digits")]
        public string Number { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Minimum length of title must be 2"), MaxLength(20, ErrorMessage = "Maximum length of title is 20")]
        public string Title { get; set; }

        [Required]
        public long UserID { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        public List<Number> Numbers { get; set; }
    }
}
