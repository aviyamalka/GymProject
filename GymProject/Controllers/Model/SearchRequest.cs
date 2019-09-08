using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.Controllers.Model
{
    public class SearchRequest
    {
      public string city { get; set; }

      public string train { get; set; }
      public DateTime date { get; set; }
    }
}
