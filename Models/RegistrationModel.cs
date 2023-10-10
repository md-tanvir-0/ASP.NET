using System;
using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s.\-]+$", ErrorMessage = "Name can only contain letters, spaces, dots, and dashes")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z]{2})(?=.*[0-9])(?=.*[@#$%^&*])[A-Za-z0-9@#$%^&*]+$", ErrorMessage = "Invalid password format")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ID is required")]
        [RegularExpression(@"^\d{2}-\d{5}-\d$", ErrorMessage = "Invalid ID format. Correct format is XX-XXXXX-X with numbers only.")]
        public string ID { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\d{2}-\d{5}-\d@student\.aiub\.edu$", ErrorMessage = "Invalid email format. Correct format is XX-XXXXX-X@student.aiub.edu with numbers only.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [CustomAgeValidation(ErrorMessage = "You must be at least 18 years old.")]
        public DateTime Birthday { get; set; }

        private class CustomAgeValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is DateTime dateOfBirth)
                {
                    var today = DateTime.Today;
                    var age = today.Year - dateOfBirth.Year;

                    // Adjust age if the birthday hasn't occurred this year yet
                    if (dateOfBirth.Date > today.AddYears(-age))
                        age--;
                    if (age >= 18)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("You must be at least 18 years old.");
                    }
                }

                return new ValidationResult("Invalid date format.");
            }

        }
    }
}
