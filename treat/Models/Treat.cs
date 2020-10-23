using System;
using System.Collections.Generic;
namespace Treat.Models
{
  public class Treat
  {
    public Treat()
    {
      this.FlavorTreats = new HashSet<FlavorTreat>();
    }
    public int TreatId { get; set; }
    public string Name { get; set; }
    public string Disc { get; set; }
    public virtual ICollection<FlavorTreat> FlavorTreats { get; set; }
  }
}