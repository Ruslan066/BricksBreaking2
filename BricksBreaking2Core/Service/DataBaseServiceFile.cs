using BricksBreaking2Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BricksBreaking2Core.Service
{
    internal class DataBaseServiceFile : IDataBaseTopScore
    {
        private const string FileName = "score.bin";

        private IList<DataBase> scoreList = new List<DataBase>();
        IList<DataBase> IDataBaseTopScore.GetTopScores()
        {
            LoadScores();
            return scoreList.OrderByDescending(s => s.Scores).ToList();
        }

        private void LoadScores()
        {
            if (File.Exists(FileName))
            {
                using (var fs = File.OpenRead(FileName))
                {
                    var bf = new BinaryFormatter();
                    scoreList = (List<DataBase>)bf.Deserialize(fs);
                }
            }
        }

    }
}
