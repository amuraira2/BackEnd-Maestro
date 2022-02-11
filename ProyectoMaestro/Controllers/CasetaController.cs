
using AutoMapper;
using Datos;
using Datos.ModelosBusqueda.Catalogos;
using Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoMaestro.ModelosVista;

namespace ProyectoMaestro.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CasetaController : ControllerBase
    {
        private readonly ICasetaRepositorio _repository;
        private readonly IMapper _mapper;
        private ILogger<CasetaController> _logger;

        public CasetaController(IMapper mapper, ICasetaRepositorio repository, ILogger<CasetaController> logger)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var caseta = await _repository.ObtenerCasetaAsync(id);

                var CasetaModeloVista = _mapper.Map<CasetaModeloVista>(caseta);
                return Ok(CasetaModeloVista);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener cliente: {0}", ex);
            }
            return BadRequest("Fallo al obtener cliente");
        }

        [HttpGet("")]
        public async Task<IActionResult> ObtenerLista([FromQuery] CasetaModeloBusqueda mb)
        {
            try
            {
                var caseta = await _repository.ObtenerCasetas(mb);

                var casetaModeloVista = _mapper.Map<List<CasetaModeloVista>>(caseta);

                return Ok(casetaModeloVista);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener Cliente: {0}", ex);
                return BadRequest("Falla al obtener Cliente");
            }
        }

        [HttpGet("tabla")]
        public async Task<IActionResult> ObtenerListaTabla([FromQuery] CasetaModeloBusqueda mb)
        {
            try
            {
                var casetas = await _repository.ObtenerCasetasTabla(mb);

                return Ok(casetas);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener cuentas: {0}", ex);
                return BadRequest("Falla al obtener cuentas");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Insertar([FromBody] CasetaModeloVista model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var caseta = new Caseta
                    {
                        Nombre = model.Nombre,
                        FechaAlta = DateTime.Now,
                        Rfc = model.Rfc,
                        BActivo = true
                    };

                    _repository.Add(caseta);

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<CasetaModeloVista>(caseta));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al grabar Cliente: {0}", ex);
                    ModelState.AddModelError("", $"Falla al grabar Cliente: {ex.Message}");
                }
            }

            return BadRequest();
        }

        [HttpPut("")]
        public async Task<IActionResult> Actualizar([FromBody] CasetaModeloVista model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var caseta = await _repository.ObtenerCasetaAsync(model.Id);

                    caseta.Nombre = model.Nombre;
                    caseta.Rfc = model.Rfc;

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<CasetaModeloVista>(caseta));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al grabar Cliente: {0}", ex);
                    ModelState.AddModelError("", $"Falla al grabar Cliente: {ex.Message}");
                }
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var caseta = await _repository.ObtenerCasetaAsync(id);
                    caseta.BActivo = false;

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al eliminar el cliente: {0}", ex);
                    ModelState.AddModelError("", $"Falla al eliminar el cliente: {ex.Message}");
                }
            }
            return BadRequest("Falla al eliminar el cliente.");
        }
    }
}
