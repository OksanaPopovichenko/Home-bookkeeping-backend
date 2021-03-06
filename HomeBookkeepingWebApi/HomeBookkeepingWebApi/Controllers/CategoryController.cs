using HomeBookkeepingWebApi.BLL.Services.Abstract;
using HomeBookkeepingWebApi.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBookkeepingWebApi.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("api/Category/Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(x => x.ErrorMessage));
                return BadRequest(errors);
            }

            var entity = await _categoryService.Create(category);

            if (entity != null)
            {
                return Ok(entity);
            }

            return StatusCode(500);
        }

        [Route("api/Category/Update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(x => x.ErrorMessage));
                return BadRequest(errors);
            }

            var entity = await _categoryService.Update(category);

            if (entity != null)
            {
                return Ok(entity);
            }

            return StatusCode(500);
        }

        [Route("api/Category/GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }

        [Route("api/Category/GetById")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await _categoryService.Get(id);

            if (category == null)
            {
                return NotFound(new { message = "Category with such id does not exist." });
            }

            return Ok(category);
        }

        [Route("api/Category/Delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _categoryService.Delete(id))
            {
                return Ok(new { message = "Category has been deleted successfuly." });
            }

            return StatusCode(500);
        }
    }
}