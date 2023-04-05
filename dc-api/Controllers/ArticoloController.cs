using dc_repository.Entities;
using dc_service.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dc_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticoloController : ControllerBase
    {
        private readonly IArticoloService services;

        public ArticoloController(IArticoloService services)
        {
            this.services = services;
        }

        [HttpPost]
        [Route("CreaArticolo")]
        public async Task<IActionResult> CreateAsync([FromBody] Articolo model)
        {
            var articolo = await services.CreateAsync(model);
            return Ok(articolo);
        }

        [HttpDelete]
        [Route("DeleteArticolo")]
        public async Task<IActionResult> DeleteAsync(int idArticolo)
        {
            await services.DeleteAsync(idArticolo);
            return Ok();
        }

        [HttpPut]
        [Route("AggiornaArticolo")]
        public async Task<IActionResult> UpdateAsync([FromBody] Articolo model)
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
