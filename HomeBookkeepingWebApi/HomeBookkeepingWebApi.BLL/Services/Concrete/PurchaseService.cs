using HomeBookkeepingWebApi.BLL.Services.Abstract;
using HomeBookkeepingWebApi.DAL.Models;
using HomeBookkeepingWebApi.DAL.Repositories.Absctract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookkeepingWebApi.BLL.Services.Concrete
{
    

    public class PurchaseService : IPurchaseService
    {
        private readonly IGenericRepository<Purchase> _genericPurchaseRepository;

        public PurchaseService(IGenericRepository<Purchase> genericPurchaseRepository)
        {
            _genericPurchaseRepository = genericPurchaseRepository;
        }

        public Task<Purchase> Get(Guid id)
        {
            return _genericPurchaseRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Purchase>> GetAll()
        {
            return await _genericPurchaseRepository.GetAsync();
        }

        public async Task<Purchase> Create(Purchase purchase)
        {
            if (await _genericPurchaseRepository.CreateAsync(purchase))
            {
                return await Get(purchase.Id);
            }

            return null;
        }

        public async Task<Purchase> Update(Purchase purchase)
        {
            if (await _genericPurchaseRepository.UpdateAsync(purchase))
            {
                return await Get(purchase.Id);
            }

            return null;
        }

        public async Task<bool> Delete(Guid id)
        {
            var purchase = await Get(id);

            if (purchase == null)
            {
                return false;
            }

            return await _genericPurchaseRepository.DeleteAsync(purchase);
        }
    }
}