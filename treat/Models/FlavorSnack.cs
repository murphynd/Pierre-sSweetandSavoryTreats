namespace
Treat.Models
{
  public class FlavorSnack
  {
    public int FlavorSnackId { get; set; }
    public int SnackId { get; set; }
    public int FlavorId { get; set; }
    public virtual Flavor Flavor { get; set; }
    public virtual Snack Snack { get; set; }
  }
}