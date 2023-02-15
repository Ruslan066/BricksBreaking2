using BricksBreaking2Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksBreaking2Core.Service
{
    internal class DataBaseEF : IDataBaseTopScore
    {
        public IList<DataBase> GetTopScores()
        {
            using (var context = new BricksBreaking2DbContext())
            {
                return (from s in context.DBScores orderby s.Scores descending select s).Take(3)
                    .ToList();
            }
        }
    }
}
