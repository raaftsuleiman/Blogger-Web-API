using Microsoft.AspNetCore.Hosting;
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
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostController(IPostService postService, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment; //to get path from Api to upload image 
            _postService = postService;
        }

        //Function to Get Count Of All Posts 
        [HttpGet]
        [Route("CountOfPost")]
        public int CountOfPost()
        {
            return _postService.CountOfPost();
        }

        // Function to  Get Lastes 5 postes (Title and Contant )
        [HttpGet]
        [Route("GetLastesPost")]
        public List<Post> GetLastesPost()
        {
            return _postService.GetLastesPost();
        }

        // Function to  Get Lastes 5 postes
        [HttpGet]
        [Route("GetTop5")]
        public List<Post> GetTop5()
        {
            return _postService.GetTop5();
        }

        // Create  

        [HttpPost]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public bool CreatePost(Post post)
        {

            return _postService.CreatePost(post);

        }

        // Update

        [HttpPut]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdatePost([FromBody] Post post)
        {
            return _postService.UpdatePost(post);
        }

        // Delete

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool DeletePost(int id)
        {
            return _postService.DeletePost(id);
        }


        // Get All

        [HttpGet]
        [Route("GetAllPost")]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Post> GetAllPost()
        {
            return _postService.GetAllPost();
        }


        // Get By ID

        [HttpGet]
        [Route("GetPostById/{Id}")]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Post> GetPostDetailsById(int id)
        {
            return _postService.GetPostDetailsById(id);
        }

        //Remove All Post Befor specific Date
        [HttpDelete]
        [Route("RemoveAllPostBeforDate/{Date}")]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool RemoveAllPostBeforDate(DateTime Date)
        {
            return _postService.RemoveAllPostBeforDate(Date);
        }
        // Remove All post has Negative Rate (stares < =2)
        [HttpDelete]
        [Route("RemoveAllposthasNegativeRate")]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool RemoveAllposthasNegativeRate()
        {
            return _postService.RemoveAllposthasNegativeRate();
        }

        //[HttpPost]
        //[Route("upload")]
        //public Post Upload() // use name of controler as type
        //{
        //    try
        //    {
        //        var file = Request.Form.Files[0]; // using I/O library to define Files and Path and MemoryStream
        //        byte[] fileContent;
        //        using (var ms = new MemoryStream())
        //        {
        //            file.CopyTo(ms);
        //            fileContent = ms.ToArray();
        //        }
        //        var fileName = Path.GetFileNameWithoutExtension(file.FileName);


        //        string attachmentFileName = $"{Guid.NewGuid().ToString("N")}_{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";

        //        var fullPath = Path.Combine("C:\\Users\\rawan\\source\\Documents\\rawan\\MyBloger\\MyBlogger\\src\\assets\\" +"images\\UploadedFile", attachmentFileName);
        //        using (var stream = new FileStream(fullPath, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }
        //        Post item = new Post(); //define object from controler 
        //        item.Image = attachmentFileName;  // use the proparity from data (Image)
        //        //item.Image = fileName;



        //        return item;
        //    }
        //    catch (Exception ex) // define catch 
        //    {
        //        return null;
        //    }



        //}

        [HttpPost]
        [Route("upload")]
        public Post Upload()
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


                var fullPath = Path.Combine("C:\\Users\\raaft\\Desktop\\FinalRafat\\MyBloger\\MyBlogger\\src\assets\\images\\UploadedFile", baseName);



                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Post item = new Post();
                item.Image = attachmentFileName;



                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("UploadsImage")]
        public ActionResult UploadImage(IFormFile file)
        {
            if (file != null)
            {
                var rootPath = _webHostEnvironment.ContentRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = Path.Combine(rootPath, "UploadsImage", fileName);
                FileStream fileStream = new FileStream(path, FileMode.Create);
                file.CopyTo(fileStream);
                fileStream.Close();
                return Ok(fileName);
            }
            return Ok();
        }



        [HttpGet("getimage/{imageName}")]
        public async Task<IActionResult> getimage(string imageName)
        {
            var rootPath = _webHostEnvironment.ContentRootPath;
            var path = Path.Combine(rootPath, "UploadsImage", imageName);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {

                var content = await System.IO.File.ReadAllBytesAsync(path);
                var contentType = "application/octet-stream";
                var fileName = imageName;
                return Ok(File(content, contentType, fileName));
            }
            return BadRequest();

        }





    } }
