using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalSectorManager.ViewModels
{
    // Custom Validation for the select list to validate whether at least one item is selected.
	public class AtLeastOneItemAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is List<int> list && list.Count > 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "At least one item should be selected.");
        }
    }
}

