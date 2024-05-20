using FerremaxApiData.Repositories;
using FerremaxApiModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FerremaxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITipoProductoRepository _tipoProductoRepository;

        public TipoProductoController(DataContext context, ITipoProductoRepository tipoProductoRepository)
        {
            _context = context;
            _tipoProductoRepository = tipoProductoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTiposProducto()
        {
            var tiposProducto = await _tipoProductoRepository.GetAllTiposProducto();
            return Ok(tiposProducto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoProducto(int id)
        {
            var tipoProducto = await _tipoProductoRepository.GetTipoProducto(id);
            if (tipoProducto == null)
                return NotFound();

            return Ok(tipoProducto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertTipoProducto([FromBody] TipoProducto tipoProducto)
        {
            if (tipoProducto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _tipoProductoRepository.InsertTipoProducto(tipoProducto);

            return Created("created", created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTipoProducto(int id, [FromBody] TipoProducto tipoProducto)
        {
            if (tipoProducto == null || id != tipoProducto.id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _tipoProductoRepository.UpdateTipoProducto(tipoProducto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoProducto(int id)
        {
            await _tipoProductoRepository.DeleteTipoProducto(new TipoProducto { id = id});
            return NoContent();
        }
      }
    }
