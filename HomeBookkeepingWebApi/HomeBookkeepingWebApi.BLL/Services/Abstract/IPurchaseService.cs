using HomeBookkeepingWebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookkeepingWebApi.BLL.Services.Abstract
{
    public interface IPurchaseService
    {
        Task<Purchase> Create(Purchase category);
        Task<bool> Delete(Guid id);
        Task<Purchase> Get(Guid id);
        Task<IEnumerable<Purchase>> GetAll();
        Task<Purchase> Update(Purchase category);
    }
}
