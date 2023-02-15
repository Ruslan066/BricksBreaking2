using System;

namespace BricksBreaking2Core.Service
{
    [Serializable]
    public class Score
    {
        //public string Player { get; set; }
        //public int Points { get; set; }
        //public DateTime PlayedAt { get; set; }

        //public Score(string player, int points, DateTime playedAt)
        //{
        //    Player = player;
        //    Points = points;
        //    PlayedAt = playedAt;
        //}
        public string Players { get; set; }
        public int Scores { get; set; }
        public int Clicks { get; set; }
        public DateTime Dates { get; set; }
    }
}
