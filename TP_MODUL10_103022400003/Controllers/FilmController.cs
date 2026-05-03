using Microsoft.AspNetCore.Mvc;
using TP_MODUL10_103022400003.Models;

namespace TP_MODUL10_103022400003.Controllers
{
    [ApiController]
    [Route("api/Film")]
    public class FilmController : ControllerBase
    {
        private static List<Film> filmList = new List<Film>
        {
            new Film { Judul = "Inception", Sutradara = "Christopher Nolan", Tahun = "2010", Genre = "Sci-Fi", Rating = "9.0" },
            new Film { Judul = "Interstellar", Sutradara = "Christopher Nolan", Tahun = "2014", Genre = "Sci-Fi", Rating = "8.7" },
            new Film { Judul = "Parasite", Sutradara = "Bong Joon-ho", Tahun = "2019", Genre = "Thriller", Rating = "8.6" }
        };

        [HttpGet]
        public ActionResult<List<Film>> GetAll()
        {
            return Ok(filmList);
        }

        [HttpGet("{index}")]
        public ActionResult<Film> GetByIndex(int index)
        {
            if (index < 1 || index > filmList.Count)
            {
                return NotFound();
            }
            return Ok(filmList[index - 1]);
        }

        [HttpPost]
        public ActionResult AddFilm([FromBody] Film film)
        {
            filmList.Add(film);
            return Ok();
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteFilm(int index)
        {
            if (index < 1 || index > filmList.Count)
            {
                return NotFound();
            }
            filmList.RemoveAt(index - 1);
            return Ok();
        }
    }
}
