using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameApi.Models;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<Models.VideoGame> videoGames = new List<Models.VideoGame>
        {
            new Models.VideoGame { id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo", Publisher = "Nintendo" },
            new Models.VideoGame { id = 2, Title = "God of War", Platform = "PlayStation 4", Developer = "Santa Monica Studio", Publisher = "Sony Interactive Entertainment" },
            new Models.VideoGame { id = 3, Title = "Red Dead Redemption 2", Platform = "PlayStation 4, Xbox One, PC", Developer = "Rockstar Games", Publisher = "Rockstar Games" }
        };

        [HttpGet]

        public ActionResult<List<Models.VideoGame>> Get()
        {
            return Ok(videoGames);
        }

        [HttpGet("{id}")]
        public ActionResult<Models.VideoGame> Get_VideoGame(int id)
        {
            var videoGame = videoGames.FirstOrDefault(game => game.id == id);
            if (videoGame is null)
                return NotFound();
            return Ok(videoGame);
        }
        [HttpPost]
        public ActionResult<VideoGame> AddGame(Models.VideoGame videoGame) {
            if (videoGame == null)
                return BadRequest();
            var newId = videoGames.Max(game => game.id)+1;
            videoGame.id = newId;
            videoGames.Add(videoGame);
            return CreatedAtAction(nameof(Get_VideoGame), new { id = newId} , videoGame);
        }

        [HttpPut("{id}")]
        public ActionResult<VideoGame> EditGame(VideoGame videoGame, int id)
        {
            var OldVideoGame = videoGames.FirstOrDefault(game => game.id == id);
            if (OldVideoGame is null)
                return NotFound();
            var props = OldVideoGame.GetType().GetProperties();
            foreach(var prop in props)
                {
                if (prop.Name =="id")
                    { continue; }
                var value = prop.GetValue(videoGame);
                prop.SetValue(OldVideoGame, value);
                }
            videoGame.id = id; 
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGame (int id) 
        {
            var videoGame = videoGames.FirstOrDefault(game => game.id == id);
            if (videoGame is null)
                return NotFound();
            videoGames.Remove(videoGame);
            return NoContent();
        }


    }
}

