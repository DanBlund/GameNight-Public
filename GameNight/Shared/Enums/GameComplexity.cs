using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Shared.Enums;

public enum GameComplexity
{
    [Display(Name = "Party")]
    Party,
    [Display(Name = "Light")]
    Light,
    [Display(Name = "Medium")]
    Medium,
    [Display(Name = "Heavy")]
    Heavy
}
