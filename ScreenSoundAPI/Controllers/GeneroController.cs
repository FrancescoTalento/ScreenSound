using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Shared.Data.Banco;
using ScreenSound.Shared.Modelos.DTOs;

namespace ScreenSoundAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : Controller
    {
        private readonly GeneroDal _generoDal;
        public GeneroController(GeneroDal generoDal)
        {
            this._generoDal = generoDal;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _generoDal.ListarItens();
            return Ok(response);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            var response = _generoDal.GetById(id);
            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var response = _generoDal.GetByName(name);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            bool response = _generoDal.Delete(id);
            if (response) return Ok();
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutGenero(int id, [FromBody] GeneroRequest newContent) 
        {
            bool response = _generoDal.Update(newContent, id);
            if(response) return Ok();   
            return NotFound(id);
        }

        [HttpPost]
        public IActionResult PostGenero([FromBody] GeneroRequest newGenero)
        {
            bool response = _generoDal.Add(newGenero);
            return response ? Ok() : Conflict("Genero already exists");
        }


    }
}
