using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogger.API.Core.Data;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {

            _categoryService = categoryService;       
        }
        // Create  

        [HttpPost]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public bool CreateCategory(Category category)
        {

            return _categoryService.CreateCategory(category);

        }

        // Update

        [HttpPut]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateCategory([FromBody] Category category)
        {
            return _categoryService.UpdateCategory(category);
        }


        // Delete

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool DeleteCategory(int id)
        {
            return _categoryService.DeleteCategory(id);
        }

        // Get All
        [Route("GetAllCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        public List<Category> GetAllCategory()
        {
            return _categoryService.GetAllCategory();
        }

        //Get By Id

        [HttpGet]
        [Route("GetById/{Id}")]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Category> GetCategoryDetailsById(int id)
        {
            return _categoryService.GetCategoryDetailsById(id);
        }

        //Search Category  By its ID or Title 
        [HttpGet]
        [Route("SearchCategoryByIdOrTitle/{search}")]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        public List<Category> SearchCategoryByIdOrTitle(string search)
        {
            return _categoryService.SearchCategoryByIdOrTitle(search);
        }


        [HttpPost]
        [Route("upload")]
        public Category Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                byte[] fileContent;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileContent = ms.ToArray();
                }
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);







                string attachmentFileName = $"{Guid.NewGuid().ToString("N")}_{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                string baseName = Path.GetFileName(file.FileName);


                var fullPath = Path.Combine("C:\\Users\\rawan\\Documents\\rawan\\MyBloger\\MyBlogger\\src\\assets\\images\\UploadedFile", baseName);



                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Category item = new Category();
                item.Image = attachmentFileName;



                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    
    }
}
