using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Shared.EntityClasses;

public class Player
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string NickName { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public double TimesAttended { get; set; }
    public double TimesDictator { get; set; }
    public double DictatorPrecentage { get; set; }
    public bool Attending { get; set; } = false;
    public bool IsDictator { get; set; } = false;
    public bool Retired { get; set; }
}
