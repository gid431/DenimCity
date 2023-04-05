using dc_repository.Entities;
using dc_service.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dc_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoggettoController : ControllerBase
    {
        private readonly ISoggettoService services;

        public SoggettoController(ISoggettoService services)
        {
            this.services = services;
        }

        [HttpPost]
        [Route("CreaSoggetto")]
        public async Task<IActionResult> CreateAsync([FromBody] Soggetto model)
        {
            var soggetto = await services.CreateAsync(model);
            return Ok(soggetto);
        }

        [HttpDelete]
        [Route("DeleteSoggetto")]
        public async Task<IActionResult> DeleteAsync(int idSoggetto)
        {
            await services.DeleteAsync(idSoggetto);
            return Ok();
        }

        [HttpPut]
        [Route("AggiornaSoggetto")]
        public async Task<IActionResult> UpdateAsync([FromBody] Soggetto model)
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
