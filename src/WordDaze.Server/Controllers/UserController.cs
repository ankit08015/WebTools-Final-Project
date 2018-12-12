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
