using System;
using System.Collections.Generic;
namespace Treat.Models
{
  public class Snack
  {
    public Snack()
    {
      this.Flavors = new HashSet<FlavorSnack>();
    }
    public int SnackId { get; set; }
    public string Name { get; set; }
    public string Disc { get; set; }
    public virtual ICollection<FlavorSnack> Flavors { get; set; }
  }
}