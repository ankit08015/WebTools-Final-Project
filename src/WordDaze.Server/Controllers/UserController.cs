using System;
using System.Collections.Generic;
using System.Linq;
using WordDaze.Server.DataAccess;
using WordDaze.Shared.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WordDaze.Server.Controllers
{
    public class UserController : Controller
    {
        UserDetailDataAccessLayer objuser = new UserDetailDataAccessLayer();
        [HttpGet]
        [Route("api/User/Index")]
        public IEnumerable<UserDetails> Index()
        {
            return objuser.GetAllUsers();
        }

        [HttpPost]
        [Route("api/User/Create")]
        public void Create([FromBody] UserDetails user)
        {
            objuser.AddUser(user);
        }

        [HttpGet]
        [Route("api/User/Details/{id}")]
        public UserDetails Details(string id)
        {
            return objuser.GetUserData(id);
        }

        [HttpGet]
        [Route("api/User/LoginDetails/{username}/{password}")]
        public UserDetails LoginDetails(string username, string password)
        {
            return objuser.GetUserLoginData(username,password);
        }


        [HttpPut]
        [Route("api/User/Edit")]
        public void Edit([FromBody]UserDetails user)
        {
            objuser.UpdateUser(user);
        }

        [HttpDelete]
        [Route("api/User/Delete/{id}")]
        public void Delete(string id)
        {
            objuser.DeleteUser(id);
        }

        [HttpDelete]
        [Route("api/Blog/Delete/{id}")]
        public void DeleteBlog(string id)
        {
            objuser.DeleteBlog(id);
        }

        [HttpPut]
        [Route("api/Blog/Edit")]
        public void EditBlog([FromBody]UserBost blog)
        {
            objuser.UpdateUserBlog(blog);
        }

        [HttpGet]
        [Route("api/Blog/Details/{id}")]
        public UserBost BlogDetails(string id)
        {
            return objuser.GetBlogData(id);
        }

        [HttpPost]
        [Route("api/Blog/Create")]
        public void CreateBlog([FromBody] UserBost blog)
        {
            objuser.AddUserBlog(blog);
        }

        [HttpGet]
        [Route("api/Blog/Index")]
        public IEnumerable<UserBost> BlogIndex()
        {
            return objuser.GetBlogData();
        }

        [HttpGet]
        [Route("api/Blog/User/{userId}")]
        public IEnumerable<UserBost> BlogDataByUserId(string id)
        {
            return objuser.GetBlogDataByUser(id);
        }

        //Login api

        [HttpGet]
        [Route("api/Login/Index")]
        public IEnumerable<UserLogin> GetAllLogin(string id)
        {
            return objuser.GetAllLogins();
        }

        [HttpPost]
        [Route("api/Login/Create")]
        public void CreateLogin([FromBody] UserLogin login)
        {
            objuser.AddLogin(login);
        }


        [HttpDelete]
        [Route("api/Login/Delete/{id}")]
        public void DeleteLogin(string id)
        {
            objuser.DeleteLogin(id);
        }






    }
}
