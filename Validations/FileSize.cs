using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netlectureAPI.Validations
{
    public class FileSize : ValidationAttribute
    {
        private readonly int MaxSizeMB;
        public FileSize(int MaxSizeMB)
        {
            this.MaxSizeMB = MaxSizeMB;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;
            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if (formFile.Length > MaxSizeMB * 1024 * 1024)
            {
                return new ValidationResult($"El peso del archivo no debe ser mayor a {MaxSizeMB}mb");
            }

            return ValidationResult.Success;
        }
    }
}