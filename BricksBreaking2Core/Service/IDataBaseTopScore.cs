using BricksBreaking2Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksBreaking2Core.Service
{
    internal interface IDataBaseTopScore
    {
        IList<DataBase> GetTopScores();
    }
}
