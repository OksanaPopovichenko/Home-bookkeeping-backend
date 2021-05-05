using HomeBookkeepingWebApi.BLL.Services.Abstract;
using HomeBookkeepingWebApi.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBookkeepingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(x => x.ErrorMessage));
                return BadRequest(errors);
            }

            var entity = await _purchaseService.Create(purchase);

            if (entity != null)
            {
                return Ok(entity);
            }

            return StatusCode(500);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(x => x.ErrorMessage));
                return BadRequest(errors);
            }

            var entity = await _purchaseService.Update(purchase);

            if (entity != null)
            {
                return Ok(entity);
            }

            return StatusCode(500);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _purchaseService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var purchase = await _purchaseService.Get(id);

            if (purchase == null)
            {
                return NotFound(new { message = "Purchase with such id does not exist." });
            }

            return Ok(purchase);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _purchaseService.Delete(id))
            {
                return Ok(new { message = "Purchase has been deleted successfuly." });
            }

            return StatusCode(500);
        }
    }
}