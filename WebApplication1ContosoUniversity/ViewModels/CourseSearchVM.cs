using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1ContosoUniversity.Models;

namespace WebApplication1ContosoUniversity.ViewModels
{
    public class CourseSearchVM : IValidatableObject
    {
        [Display(Name = "Judul :")]
        public string Title { get; set; }
        [Display(Name = "Kredit :")]
        public string Credits { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Title) && String.IsNullOrEmpty(Credits))
            {
                yield return new ValidationResult("Masukkan minimal satu kolom pencarian");
            }
        }
    }
}