using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//using System.Web.Mvc;

namespace NMUG.ValidationAttributes
{

        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public sealed class ValidTitle : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                var _context = new Data.ApplicationDbContext();
                var TitleCount = _context.Directors.Where(t => t.TitleID == (int)value).Count(); 
                if (TitleCount > 0 )
                    {
                        return new ValidationResult("The same Title cannot be entered twice.");
                    }
                }
                return ValidationResult.Success;
            }
        }
    }

