﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1ContosoUniversity.ViewModels
{
    public class EnrollmentDateGroup
    {
        
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }

}
