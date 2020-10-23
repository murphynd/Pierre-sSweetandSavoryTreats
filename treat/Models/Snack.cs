using System;
using System.Collections.Generic;
namespace Treat.Models
{
  public class Snack
  {
    public Snack()
    {
      this.FlavorSnacks = new HashSet<FlavorSnack>();
    }
    public int SnackId { get; set; }
    public string Name { get; set; }
    public string Disc { get; set; }
    public virtual ICollection<FlavorSnack> FlavorSnacks { get; set; }
  }
}