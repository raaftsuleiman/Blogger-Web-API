using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
   public  class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository=categoryRepository;
        }

        public bool CreateCategory(Category category)
        {
            return _categoryRepository.CreateCategory(category);
        }

        public bool DeleteCategory(int id)
        {
            return _categoryRepository.DeleteCategory(id);
        }

        public bool UpdateCategory(Category category)
        {
            return _categoryRepository.UpdateCategory(category);
        }

        public List<Category> GetAllCategory()
        {
            return _categoryRepository.GetAllCategory();
        }

        public List<Category> GetCategoryDetailsById(int id)
        {
            return _categoryRepository.GetCategoryDetailsById(id);
        }

        //Search Category  By its ID or Title 
        public List<Category> SearchCategoryByIdOrTitle(string search)
        {
            return _categoryRepository.SearchCategoryByIdOrTitle(search);
        }
    }
}
