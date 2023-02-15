using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksBreaking2Core.Entity
{
    [Serializable]
    public class DataBase
    {
        public string Players { get; set; }
        public int Scores { get; set; }
        public int Clicks { get; set; }
        //rating
        public DateTime Dates { get; set; }
        public string Comment { get; set; }

    }

}
