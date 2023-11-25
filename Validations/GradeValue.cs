using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using netlectureAPI.Models;

namespace netlectureAPI.Validations
{
    public class GradeValue : ValidationAttribute
    {
        //private readonly string grade;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (Grade.IsGrade(value as string))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Valor de grado invalido");
        }
    }
}