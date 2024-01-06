using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MyBlogger.API.Core.Data;
using MyBlogger.Core.DTO;
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
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("CountOfUsers")]
        //Function to Get Count Of All Users
        public int CountOfUsers()
        {
            return _usersService.CountOfUsers();
        }

        //Function to Get All Users 
        [HttpGet]
        [Route("GetAllUsers")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]

        public List<User> GetAllUsers()
        {
            return _usersService.GetAllUsers();
        }


        //Function To Create Anew User
        [HttpPost]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateUser(User user)
        {
            return _usersService.CreateUser(user);
        }


        //Function to Get Last  User
        [HttpGet]
        [Route("GetLastUser")]
        public List<User> GetLastUser()
        {
            return _usersService.GetLastUser();
        }


        //Function To Edite User Record 
        [HttpPut]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateUser(User user)
        {
            return _usersService.UpdateUser(user);
        }

        //Function To Delete User Record 

        [Route("DeleteUser/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool DeleteUser(int id)
        {
            return _usersService.DeleteUser(id);
        }


        //Function To Search About User 

        [HttpGet]
        [Route("UserSearch/{search}")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]

        public List<User> SearchAboutUserByFnameLnameOrEmail(string search)
        {
            return _usersService.SearchAboutUserByFnameLnameOrEmail(search);
        }


        [HttpGet]
        [Route("CheckByEmail/{email}")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]

        public List<User> CheckByEmail(string email)
        {
            return _usersService.CheckByEmail(email);
        }
        //Function to Get User By Id

        [HttpGet]
        [Route("GetUserById/{Id}")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        public List<User> GetUserById(int Id)
        {
            return _usersService.GetUserById(Id);
        }



        [HttpPost]
        [Route("upload")]
        public User Upload()
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
                User item = new User();
                item.Image = attachmentFileName;



                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("MailSetting")]
        public async Task<CheckUsersDTO> SendResetPasswordEmailAsync(CheckUsersDTO checkUsersDTO)
        {
            var randomCode = new Random().Next(1, 10000);

            checkUsersDTO.code = randomCode;
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Blogger",
           "evotingteams@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(checkUsersDTO.email, "" + checkUsersDTO.email + "");
            message.To.Add(to);

            message.Subject = "Reset Password";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody =
                "<p> Dear Ms/Ms" + checkUsersDTO.FullName + " ,</p>" +
                "<p>Please enter this code " + checkUsersDTO.code + "to reset your password </p>" +
            "Regards" +
            "<p>MyBlogger Teams</p>";
            message.Body = bodyBuilder.ToMessageBody();

            using (var clinte = new SmtpClient())
            {

                clinte.Connect("smtp.gmail.com", 587, false);
                clinte.Authenticate("rawanalomari372@gmail.com", "Alomari654321#"); //Sender 

                clinte.Send(message);
                clinte.Disconnect(true);
            }
            return checkUsersDTO;

        }

    }
}
