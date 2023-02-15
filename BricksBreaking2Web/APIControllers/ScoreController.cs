using BricksBreaking2Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BricksBreaking2Web.APIControllers
{
    //https://localhost:44319/api/Score
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private IScoreService _scoreService = new ScoreServiceEF();

        //GET: /api/Score
        [HttpGet]
        public IEnumerable<Score> GetScores()
        {
            return _scoreService.GetTopScores();
        }

        //POST: /api/Score
        [HttpPost]
        public void PostScore(Score score)
        {
            score.Dates = DateTime.Now;
            _scoreService.AddScore(score);
        }
    }

}
