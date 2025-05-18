using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.DTOs;

namespace ScreenSoundAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicaController : Controller
    {
        private readonly MusicaDal _musicaDal;
        public MusicaController(MusicaDal musicaDal)
        {
            _musicaDal = musicaDal;
        }

        [HttpGet]
        public IActionResult GetAllMusicas()
        {
            var response = _musicaDal.ListarItens();
            return response is null ? NoContent() : Ok(response);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            MusicaOutput? response = _musicaDal.GetById(id);
            return response is null ? NotFound() : Ok(response);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var response = _musicaDal.GetByName(name);
            return response is null ? NotFound() : Ok(response);
        }

        [HttpPost]
        public IActionResult PostMusica([FromBody] MusicaInput musicaInput)
        {
            _musicaDal.Add(musicaInput);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutMusica(int id, [FromBody] MusicaInput newValue)
        {
            bool response = _musicaDal.Update(id,newValue);
            return response ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            bool response = _musicaDal.Delete(id);
            return response ? Ok() : NotFound();
        }
    }
}
