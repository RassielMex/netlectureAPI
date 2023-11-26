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
        private readonly bool asArray;
        public GradeValue() { }
        public GradeValue(bool asArray)
        {
            this.asArray = asArray;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (asArray)
            {
                try
                {
                    var values = value as string[];
                    if (values.All(Grade.IsGrade))
                    {
                        return ValidationResult.Success;
                    }
                }
                catch (Exception)
                {

                    return new ValidationResult("Valor de grado invalido");
                }
            }


            if (Grade.IsGrade(value as string))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Valor de grado invalido");
        }
    }
}