using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jims_Cars.Data.Models
{
    public enum CarMake
    {
        NA,
        [Display(Name = "Hot Wheels")]
        HotWheels,
        Mattel,
        Disney,
        Generic
    }
}
