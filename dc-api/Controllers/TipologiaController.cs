using dc_repository.Entities;
using dc_service.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dc_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipologiaController : ControllerBase
    {
        private readonly ITipologiaService services;

        public TipologiaController(ITipologiaService services)
        {
            this.services = services;
        }

        [HttpPost]
        [Route("CreaTipologia")]
        public async Task<IActionResult> CreateAsync([FromBody] Tipologia model)
        {
            var tipologia = await services.CreateAsync(model);
            return Ok(tipologia);
        }

        [HttpDelete]
        [Route("DeleteTipologia")]
        public async Task<IActionResult> DeleteAsync(int idTipologia)
        {
            await services.DeleteAsync(idTipologia);
            return Ok();
        }

        [HttpPut]
        [Route("AggiornaTipologia")]
        public async Task<IActionResult> UpdateAsync([FromBody] Tipologia model)
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
