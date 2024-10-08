﻿using dc_repository.Entities;
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

        [HttpDelete]
        [Route("DeleteCategoria")]
        public async Task<IActionResult> DeleteAsync(int idCategoria)
        {
            await services.DeleteAsync(idCategoria);
            return Ok();
        }

        [HttpPut]
        [Route("AggiornaCategoria")]
        public async Task<IActionResult> UpdateAsync([FromBody] Categoria model)
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
