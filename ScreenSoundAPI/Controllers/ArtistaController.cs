using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.DTOs;

namespace ScreenSoundAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistaController : ControllerBase
    {
        private readonly ArtistaDal _artistaDal;
        public ArtistaController(ArtistaDal artistaDal)
        {
            _artistaDal = artistaDal;
        }
        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            var response = _artistaDal.GetById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);

        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var response = _artistaDal.GetByName(name);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAllArtistas()
        {
            var response = _artistaDal.ListarItens();
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var response = _artistaDal.Delete(id);
            return response ? Ok() : NotFound();
        }

        [HttpPost]
        public IActionResult PostArtista([FromBody] ArtistaResumo artistaResumo)
        {
            _artistaDal.Add(artistaResumo);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutArtista(int id, [FromBody] ArtistaCompleto newArtista)
        {
            var response = _artistaDal.Update(id, newArtista);
            return response ? Ok() : NotFound();
        }
    }
}
