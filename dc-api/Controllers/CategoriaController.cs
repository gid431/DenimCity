using dc_repository.Entities;
using dc_service.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dc_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService services;

        public CategoriaController(ICategoriaService services)
        {
            this.services = services;
        }

        [HttpPost]
        [Route("CreaCategoria")]
        public async Task<IActionResult> CreateAsync([FromBody] Categoria model)
        {
            var categoria = await services.CreateAsync(model);
            return Ok(categoria);
        }

    }
}
