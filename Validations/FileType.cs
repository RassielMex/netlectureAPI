using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using netlectureAPI.Models;

namespace netlectureAPI.Validations
{
    public class FileType : ValidationAttribute
    {
        private readonly string[] types;
        public FileType(string[] types)
        {
            this.types = types;

        }

        public FileType(ValidFileType validFileType)
        {
            if (validFileType == ValidFileType.IMAGE)
            {

                types = new string[] { "image/jpeg", "image/png", "image/gif", "image/jpg" };
            }

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

            if (!types.Contains(formFile.ContentType))
            {
                return new ValidationResult($"El tipo de archivo debe ser {String.Join(",", types)}");
            }

            return ValidationResult.Success;
        }
    }
}