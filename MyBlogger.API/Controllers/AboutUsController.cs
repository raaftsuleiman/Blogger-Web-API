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
    public class AboutUsController : Controller
    {
        private readonly IAboutUsService _aboutUsService ;
        public AboutUsController(IAboutUsService aboutUsService)
        {

           _aboutUsService=aboutUsService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<AboutU>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateAboutUs(AboutU aboutUs)
        {

            return _aboutUsService.CreateAboutUs(aboutUs);
        }

        // Update

        [HttpPut]
        [ProducesResponseType(typeof(List<AboutU>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool  UpdateAboutUs([FromBody] AboutU aboutUs)
        {
             return _aboutUsService.UpdateAboutUs(aboutUs);
        }

        // Delete

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(List<AboutU>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool DeleteAboutUs(int id)
        {
           return _aboutUsService.DeleteAboutUs(id);
        }

        //Get All

        [HttpGet]
        [Route ("GetAllAbout")]
        [ProducesResponseType(typeof(List<AboutU>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public List<AboutU> GetAllAboutUs()
        {
            return _aboutUsService.GetAllAboutUs();
        }

        //Get By Id

        [HttpGet]
        [Route("GetById/{Id}")]
        [ProducesResponseType(typeof(List<AboutU>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<AboutU> GetAboutUsById(int id)
        {
            return _aboutUsService.GetAboutUsById(id);
        }

        [HttpPost]
        [Route("upload")]
        public AboutU Upload()
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
                AboutU item = new AboutU();
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
