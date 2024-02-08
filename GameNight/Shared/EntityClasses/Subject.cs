using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameNight.Shared.EntityClasses;

public class Subject
{
    public int Id { get; set; }
    public int LoggId { get; set; }
    [JsonIgnore]
    public Logg? Logg { get; set; } = null!;
    public int SubjectId { get; set; }

}
