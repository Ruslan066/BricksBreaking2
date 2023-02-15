using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BricksBreaking2Core;
using BricksBreaking2Core.Service;

namespace BricksBreaking2Web.Models
{
    public class BrickseModel
    {
        public Field Field { get; set; }

        public IList<Score> Scores { get; set; }
    }
}

