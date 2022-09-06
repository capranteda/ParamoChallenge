using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sat.Recruitment.Model.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The email is required")]
        [EmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "The address is required")]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "The phone is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "The user type is required")]
        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }
        public UserTypeDTO UserType { get; set; }
        
        [Required(ErrorMessage = "The money is required")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "No more than 2 decimal are accepted")]
        [Range(0, 9999999999999999.99, ErrorMessage = "The money must be between 0 and 9999999999999999.99")]
        public decimal Money { get; set; }
    }
}