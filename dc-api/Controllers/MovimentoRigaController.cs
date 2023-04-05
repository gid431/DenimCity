﻿using dc_repository.Entities;
using dc_service.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dc_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoRigaController : ControllerBase
    {
        private readonly IMovimentoRigaService services;

        public MovimentoRigaController(IMovimentoRigaService services)
        {
            this.services = services;
        }

        [HttpPost]
        [Route("CreaMovimentoRiga")]
        public async Task<IActionResult> CreateAsync([FromBody] MovimentoRiga model)
        {
            var movimentoRiga = await services.CreateAsync(model);
            return Ok(movimentoRiga);
        }

        [HttpDelete]
        [Route("DeleteMovimentoRiga")]
        public async Task<IActionResult> DeleteAsync(int idMovimentoRiga)
        {
            await services.DeleteAsync(idMovimentoRiga);
            return Ok();
        }

        [HttpPut]
        [Route("AggiornaMovimentoRiga")]
        public async Task<IActionResult> UpdateAsync([FromBody] MovimentoRiga model)
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
