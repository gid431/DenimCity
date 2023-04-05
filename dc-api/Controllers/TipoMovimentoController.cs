using dc_repository.Entities;
using dc_service.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dc_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimentoController : ControllerBase
    {
        private readonly ITipoMovimentoService services;

        public TipoMovimentoController(ITipoMovimentoService services)
        {
            this.services = services;
        }

        [HttpPost]
        [Route("CreaTipoMovimento")]
        public async Task<IActionResult> CreateAsync([FromBody] TipoMovimento model)
        {
            var tipoMovimento = await services.CreateAsync(model);
            return Ok(tipoMovimento);
        }

        [HttpDelete]
        [Route("DeleteTipoMovimento")]
        public async Task<IActionResult> DeleteAsync(int idTipoMovimento)
        {
            await services.DeleteAsync(idTipoMovimento);
            return Ok();
        }

        [HttpPut]
        [Route("AggiornaTipoMovimento")]
        public async Task<IActionResult> UpdateAsync([FromBody] TipoMovimento model)
        {
            return Ok(await services.UpdateAsync(model));
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GettAllAsync()
        {
            return Ok(await services.GetAll());
        }

        [HttpGet]
        [Route("Pagination/{numPag}/{filtro}")]
        public async Task<IActionResult> Pagination(int numPag, string filtro, int recPag = 10)
        {
            return Ok(await services.Pagination(numPag, filtro, recPag));
        }
    }
}
