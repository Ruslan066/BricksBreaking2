using System;
using System.Collections.Generic;
using System.Text;

namespace BricksBreaking2Core.Service
{
    public interface IScoreService
    {
        void AddScore(Score score);
        IList<Score> GetTopScores();
        void ResetScore();
    }
}
