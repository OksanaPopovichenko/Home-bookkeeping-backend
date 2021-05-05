using HomeBookkeepingWebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookkeepingWebApi.BLL.Services.Abstract
{
    public interface IBudgetPlanService
    {
        Task<BudgetPlan> Create(BudgetPlan category);
        Task<bool> Delete(Guid id);
        Task<BudgetPlan> Get(Guid id);
        Task<IEnumerable<BudgetPlan>> GetAll();
        Task<BudgetPlan> Update(BudgetPlan category);
    }
}
