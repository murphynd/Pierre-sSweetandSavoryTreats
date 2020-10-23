using System.Collections.Generic;
using Treat.Models;

namespace Treat.ViewModels
{
  public class ManageUsersViewModel
  {
    public ApplicationUser[] Administrators { get; set; }

    public ApplicationUser[] Everyone { get; set; }
  }
}