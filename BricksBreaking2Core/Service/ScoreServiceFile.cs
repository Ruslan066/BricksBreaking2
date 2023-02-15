using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BricksBreaking2Core.Service
{

    public class ScoreServiceFile : IScoreService
    {
        private const string FileName = "score.bin";

        private IList<Score> scoreList = new List<Score>();
        void IScoreService.AddScore(Score score)
        {
            scoreList.Add(score);
            SaveScores();
        }

        IList<Score> IScoreService.GetTopScores()
        {
            LoadScores();
            return scoreList.OrderByDescending(s=>s.Scores).ToList();
        }

        void IScoreService.ResetScore()
        {
            scoreList = new List<Score>();
            File.Delete(FileName);
        }
        private void SaveScores()
        {
            using (var fs = File.OpenWrite(FileName))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, scoreList);
            }
        }

        private void LoadScores()
        {
            if (File.Exists(FileName))
            {
                using (var fs = File.OpenRead(FileName))
                {
                    var bf = new BinaryFormatter();
                    scoreList = (List<Score>)bf.Deserialize(fs);
                }
            }
        }

    }
}
