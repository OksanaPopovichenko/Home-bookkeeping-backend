using HomeBookkeepingWebApi.BLL.Services.Abstract;
using HomeBookkeepingWebApi.DAL.Models;
using HomeBookkeepingWebApi.DAL.Repositories.Absctract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookkeepingWebApi.BLL.Services.Concrete
{
    

    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _genericCategoryRepository;

        public CategoryService(IGenericRepository<Category> genericCategoryRepository)
        {
            _genericCategoryRepository = genericCategoryRepository;
        }

        public Task<Category> Get(Guid id)
        {
            return _genericCategoryRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _genericCategoryRepository.GetAsync();
        }

        public async Task<Category> Create(Category category)
        {
            if (await _genericCategoryRepository.CreateAsync(category))
            {
                return await Get(category.Id);
            }

            return null;
        }

        public async Task<Category> Update(Category category)
        {
            if (await _genericCategoryRepository.UpdateAsync(category))
            {
                return await Get(category.Id);
            }

            return null;
        }

        public async Task<bool> Delete(Guid id)
        {
            var category = await Get(id);

            if (category == null)
            {
                return false;
            }

            return await _genericCategoryRepository.DeleteAsync(category);
        }
    }
}