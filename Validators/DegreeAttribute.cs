using LMS.Models;
using System.ComponentModel.DataAnnotations;

namespace LMS.Validators
{
    public class DegreeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is double degree)
            {
                Course course = (Course)validationContext.ObjectInstance;
                if (course.MinDegree <= degree)
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Degree must be greater than or equal to MinDegree.");
            }
            return new ValidationResult("Invalid degree value.");
        }
    }
}