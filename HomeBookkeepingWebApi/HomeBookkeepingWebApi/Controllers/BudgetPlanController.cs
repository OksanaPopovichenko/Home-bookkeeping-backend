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
    public class BudgetPlanController : ControllerBase
    {
        private readonly IBudgetPlanService _budgetPlanService;

        public BudgetPlanController(IBudgetPlanService budgetPlanService)
        {
            _budgetPlanService = budgetPlanService;
        }

        [HttpPost]
        [Route("api/BudgetPlan/Create")]
        public async Task<IActionResult> Create([FromBody] BudgetPlan budgetPlan)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(x => x.ErrorMessage));
                return BadRequest(errors);
            }

            var entity = await _budgetPlanService.Create(budgetPlan);

            if (entity != null)
            {
                return Ok(entity);
            }

            return StatusCode(500);
        }

        [Route("api/BudgetPlan/Update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BudgetPlan budgetPlan)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(x => x.ErrorMessage));
                return BadRequest(errors);
            }

            var entity = await _budgetPlanService.Update(budgetPlan);

            if (entity != null)
            {
                return Ok(entity);
            }

            return StatusCode(500);
        }

        [Route("api/BudgetPlan/GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _budgetPlanService.GetAll());
        }

        [Route("api/BudgetPlan/GetById")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var budgetPlan = await _budgetPlanService.Get(id);

            if (budgetPlan == null)
            {
                return NotFound(new { message = "BudgetPlan with such id does not exist." });
            }

            return Ok(budgetPlan);
        }

        [Route("api/BudgetPlan/Delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _budgetPlanService.Delete(id))
            {
                return Ok(new { message = "BudgetPlan has been deleted successfuly." });
            }

            return StatusCode(500);
        }
    }
}