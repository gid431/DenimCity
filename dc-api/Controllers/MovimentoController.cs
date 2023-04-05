using dc_repository.Entities;
using dc_service.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dc_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoController : ControllerBase
    {
        private readonly IMovimentoService services;

        public MovimentoController(IMovimentoService services)
        {
            this.services = services;
        }

        [HttpPost]
        [Route("CreaMovimento")]
        public async Task<IActionResult> CreateAsync([FromBody] Movimento model)
        {
            var movimento = await services.CreateAsync(model);
            return Ok(movimento);
        }

        [HttpDelete]
        [Route("DeleteMovimento")]
        public async Task<IActionResult> DeleteAsync(int idMovimento)
        {
            await services.DeleteAsync(idMovimento);
            return Ok();
        }

        [HttpPut]
        [Route("AggiornaMovimento")]
        public async Task<IActionResult> UpdateAsync([FromBody] Movimento model)
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
