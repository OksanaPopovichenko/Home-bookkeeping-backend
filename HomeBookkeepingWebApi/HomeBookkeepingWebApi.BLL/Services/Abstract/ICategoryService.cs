using HomeBookkeepingWebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookkeepingWebApi.BLL.Services.Abstract
{
    public interface ICategoryService
    {
        Task<Category> Create(Category category);
        Task<bool> Delete(Guid id);
        Task<Category> Get(Guid id);
        Task<IEnumerable<Category>> GetAll();
        Task<Category> Update(Category category);
    }
}
