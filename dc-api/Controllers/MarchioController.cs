using dc_repository.Entities;
using dc_service.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dc_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarchioController : ControllerBase
    {
        private readonly IMarchioService services;

        public MarchioController(IMarchioService services)
        {
            this.services = services;
        }

        [HttpPost]
        [Route("CreaMarchio")]
        public async Task<IActionResult> CreateAsync([FromBody] Marchio model)
        {
            var marchio = await services.CreateAsync(model);
            return Ok(marchio);
        }

        [HttpDelete]
        [Route("DeleteMarchio")]
        public async Task<IActionResult> DeleteAsync(int idMarchio)
        {
            await services.DeleteAsync(idMarchio);
            return Ok();
        }

        [HttpPut]
        [Route("AggiornaMarchio")]
        public async Task<IActionResult> UpdateAsync([FromBody] Marchio model)
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
