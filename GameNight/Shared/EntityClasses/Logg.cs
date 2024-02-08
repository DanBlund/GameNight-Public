using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Shared.EntityClasses;

public class Logg
{
    public int Id { get; set; }
    public Player? Dictator { get; set; }
    public int? DictatorId { get; set; }
    public DateTime DateOfEvent { get; set; }
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
  }
