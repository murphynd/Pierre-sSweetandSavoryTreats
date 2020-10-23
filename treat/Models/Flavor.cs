using System;
using System.Collections.Generic;
namespace Treat.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.FlavorTreats = new HashSet<FlavorTreat>();
    }
    public int FlavorId { get; set; }
    public string Name { get; set; }
    public string Disc { get; set; }
    public virtual ICollection<FlavorTreat> FlavorTreats { get; set; }
  }
}