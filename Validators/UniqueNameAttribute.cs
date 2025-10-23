using LMS.Context;
using LMS.Models;
using System.ComponentModel.DataAnnotations;

namespace LMS.Validators
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string name)
            {
                var context = (LMSContext)validationContext.GetService(typeof(LMSContext));

                var course = (Course)validationContext.ObjectInstance;
                var c = context.Courses.Any(c => c.Name == name && c.Id != course.Id);
                if (c == true)
                    return new ValidationResult("name must be uniqe");
                else
                    return ValidationResult.Success;
            }
            return new ValidationResult("Invalid name");
        }
    }
}