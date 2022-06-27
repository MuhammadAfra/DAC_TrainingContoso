using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1ContosoUniversity.Models;

namespace WebApplication1ContosoUniversity.ViewModels
{

    public class EnrollmentSearchVM : IValidatableObject
    {
        [Display(Name = "Judul :")]
        public string Title { get; set; }

        [Display(Name = "Nama Belakang :")]
        public string LastName { get; set; }

        [Display(Name = "Nilai dari :")]
        public Grade? GradeFrom { get; set; }

        [Display(Name = "Nilai sampai :")]
        public Grade? GradeUntil { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Title) && String.IsNullOrEmpty(LastName))
            {
                yield return new ValidationResult("Masukkan minimal satu kolom pencarian !");
            }

            if (GradeFrom == null)
            {
                yield return new ValidationResult("Masukkan minimal satu kolom pencarian Nilai !", new[] {"GradeFrom"});
            }

            if (GradeUntil == null)
            {
                yield return new ValidationResult("Masukkan minimal satu kolom pencarian Nilai !", new[] { "GradeUntil" });
            }
        }
    }
}