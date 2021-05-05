using HomeBookkeepingWebApi.BLL.Services.Abstract;
using HomeBookkeepingWebApi.DAL.Models;
using HomeBookkeepingWebApi.DAL.Repositories.Absctract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookkeepingWebApi.BLL.Services.Concrete
{
    

    public class BudgetPlanService : IBudgetPlanService
    {
        private readonly IGenericRepository<BudgetPlan> _genericBudgetPlanRepository;

        public BudgetPlanService(IGenericRepository<BudgetPlan> genericBudgetPlanRepository)
        {
            _genericBudgetPlanRepository = genericBudgetPlanRepository;
        }

        public Task<BudgetPlan> Get(Guid id)
        {
            return _genericBudgetPlanRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<BudgetPlan>> GetAll()
        {
            return await _genericBudgetPlanRepository.GetAsync();
        }

        public async Task<BudgetPlan> Create(BudgetPlan budgetPlan)
        {
            if (await _genericBudgetPlanRepository.CreateAsync(budgetPlan))
            {
                return await Get(budgetPlan.Id);
            }

            return null;
        }

        public async Task<BudgetPlan> Update(BudgetPlan budgetPlan)
        {
            if (await _genericBudgetPlanRepository.UpdateAsync(budgetPlan))
            {
                return await Get(budgetPlan.Id);
            }

            return null;
        }

        public async Task<bool> Delete(Guid id)
        {
            var budgetPlan = await Get(id);

            if (budgetPlan == null)
            {
                return false;
            }

            return await _genericBudgetPlanRepository.DeleteAsync(budgetPlan);
        }
    }
}