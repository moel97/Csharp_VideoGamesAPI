using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private List<Models.VideoGame> videoGames = new List<Models.VideoGame>
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
    }
}

