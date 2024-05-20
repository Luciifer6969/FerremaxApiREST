using FerremaxApiData.Repositories;
using FerremaxApiModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FerremaxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMarcaRepository _marcasRepository;

        public MarcasController(DataContext context, IMarcaRepository marcasRepository)
        {
            _context = context;
            _marcasRepository = marcasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMarcas()
        {
            var marcas = await _marcasRepository.GetAllMarcas();
            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarcaDetails(int id)
        {
            var marca = await _marcasRepository.GetMarca(id);
            if (marca == null)
                return NotFound();

            return Ok(marca);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMarca([FromBody] Marca marca)
        {
            if (marca == null)
                return BadRequest("Marca is null");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _marcasRepository.InsertMarca(marca);
            return Created("Created",created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMarca(int id, [FromBody] Marca marca)
        {
            if (marca == null || id != marca.id)
                return BadRequest("Invalid data");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingMarca = await _marcasRepository.GetMarca(id);
            if (existingMarca == null)
                return NotFound();

            await _marcasRepository.UpdateMarca(marca);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            var marca = await _marcasRepository.GetMarca(id);
            if (marca == null)
                return NotFound();

            await _marcasRepository.DeleteMarca(marca);
            return NoContent();
        }
    }
}
