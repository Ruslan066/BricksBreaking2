using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksBreaking2Core.Service
{
    public class ScoreServiceEF : IScoreService
    {
        public void AddScore(Score score)
        {
            using (var context = new BricksBreaking2DbContext())
            {
                context.Scores.Add(score);
                context.SaveChanges();
            }
        }

        public IList<Score> GetTopScores()
        {
            using (var context = new BricksBreaking2DbContext())
            {
                return (from s in context.Scores orderby s.Scores descending select s).Take(3)
                    .ToList();
                 
            }
        }

        public void ResetScore()
        {
            using (var context = new BricksBreaking2DbContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Scores");
            }
        }
    }

}
