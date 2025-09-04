using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VideoGameApi.Data;
using VideoGameApi.Models;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController (VideoGameDBContext context)  : ControllerBase
    {
        private readonly VideoGameDBContext _dbContext = context;
        [HttpGet]

        public async Task<ActionResult<List<Models.VideoGame>>> Get()
        {
            var videoGames = await _dbContext.VideoGames.AsNoTracking().ToArrayAsync();
            return Ok(videoGames);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> Get_VideoGame(int id)
        {
            var videoGame = await _dbContext.VideoGames.AsNoTracking().FirstOrDefaultAsync(g => g.id == id);
            if (videoGame is null)
                return NotFound();
            return Ok(videoGame);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddGame(VideoGame videoGame)
        {
            if (videoGame == null)
                return BadRequest();
            var newVideoGame = new VideoGame
            {
                Title = videoGame.Title,
                Platform = videoGame.Platform,
                Developer = videoGame.Developer,
                Publisher = videoGame.Publisher
            };
            _dbContext.VideoGames.Add(newVideoGame);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get_VideoGame), new { Id = videoGame.id }, videoGame);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VideoGame>> EditGame(VideoGame videoGame, int id)
        {
            var SelectedVideoGame = await _dbContext.VideoGames.FindAsync(id);
            if (SelectedVideoGame is null)
                return NotFound();
            var props = SelectedVideoGame.GetType().GetProperties();
            foreach (var prop in props)
            {
                if (prop.Name == "id")
                { continue; }
                var value = prop.GetValue(videoGame);
                prop.SetValue(SelectedVideoGame, value);
                Console.WriteLine(value);
            }
            videoGame.id = id;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var videoGame = await _dbContext.VideoGames.FindAsync(id);
            if (videoGame is null)
                return NotFound();
            _dbContext.VideoGames.Remove(videoGame);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }


    }
}

