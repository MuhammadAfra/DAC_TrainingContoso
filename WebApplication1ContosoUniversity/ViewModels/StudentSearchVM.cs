using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1ContosoUniversity.ViewModels
{
    public class StudentSearchVM : IValidatableObject
    {
        [Display(Name = "Nama Belakang")]
        public string LastName { get; set; }

        [Display(Name = "Nama Depan Tengah")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Tanggal Pendaftaran dari :")]
        public DateTime? EnrollmentDateFrom { get; set; } // ? (NULLABLE)

        [DataType(DataType.Date)]
        [Display(Name = "Tanggal Pendaftaran sampai :")]
        public DateTime? EnrollmentDateUntil { get; set; } // ? (NULLABLE)

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(String.IsNullOrEmpty(LastName) && String.IsNullOrEmpty(FirstMidName))
            {
                yield return new ValidationResult("Masukkan minimal satu kolom pencarian!");
                //Memberi validation jika sebuah kolom pencarian tidak diisi!
            }
            else if (String.IsNullOrEmpty(FirstMidName))
            {
                yield return new ValidationResult("Masukkan minimal satu kolom pencarian!");
            }
            if (EnrollmentDateFrom == null)
            {
                yield return new ValidationResult("Masukkan Kolom Tanggal Dari ", new[] { "EnrollmentDateFrom" });
                //Memberi validation ke variable yang dituju!
            }
            if (EnrollmentDateUntil == null)
            {
                yield return new ValidationResult("Masukkan Kolom Tanggal Sampai", new[] { "EnrollmentDateUntil" });
                //Memberi validation ke variable yang dituju!
            }
        }
    }
}