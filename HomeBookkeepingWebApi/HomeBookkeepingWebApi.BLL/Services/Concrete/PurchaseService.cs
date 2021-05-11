using HomeBookkeepingWebApi.BLL.Services.Abstract;
using HomeBookkeepingWebApi.DAL.Models;
using HomeBookkeepingWebApi.DAL.Models.DTOs;
using HomeBookkeepingWebApi.DAL.Repositories.Absctract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public PurchasesListDto GetByDate(string userEmail, DateTime startDate, DateTime endDate)
        {
            var res = new PurchasesListDto();

            var purchases = _genericPurchaseRepository.Get(x => x.UserEmail == userEmail && x.Date >= startDate && x.Date <= endDate, null, purchases => purchases.Include(s => s.Category)).ToList();

            res.Purchases = purchases;
            res.TotalPrice = purchases.Sum(x => x.Price);

            res.TotalPriceByGroup = new Dictionary<string, decimal>();

            purchases.ForEach(p =>
            {
                if (!res.TotalPriceByGroup.ContainsKey(p.Category.Name))
                {
                    res.TotalPriceByGroup.Add(p.Category.Name, 0);
                }
                else
                {
                    res.TotalPriceByGroup[p.Category.Name] += p.Price;
                }
            });

            return res;
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