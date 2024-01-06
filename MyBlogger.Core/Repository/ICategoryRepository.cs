using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Repository
{
    public interface ICategoryRepository
    {
        public bool CreateCategory(Category category);

        public bool DeleteCategory(int id);

        public bool UpdateCategory(Category category);

        public List<Category> GetAllCategory();

        public List<Category> GetCategoryDetailsById(int id);

        //Search Category  By its ID or Title 
        public List<Category> SearchCategoryByIdOrTitle(string search);

    }
}
