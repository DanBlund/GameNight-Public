using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Shared.Enums
{
    public enum GameRatings
    {
        IG,
        Gm,
        G,
        Gp,
        VGm,
        VG,
        VGp,
        [Display(Name = "MVG")]
        MVG
    }
}
