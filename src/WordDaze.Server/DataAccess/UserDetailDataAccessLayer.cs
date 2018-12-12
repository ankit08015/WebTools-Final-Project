using WordDaze.Shared.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordDaze.Server.DataAccess
{
    public class UserDetailDataAccessLayer
    {
        UserDBContext db = new UserDBContext();

        //To Get all user details       
        public List<UserDetails> GetAllUsers()
        {
            try
            {
                return db.UserRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new user record       
        public void AddUser(UserDetails user)
        {
            try
            {
                db.UserRecord.InsertOne(user);
            }
            catch
            {
                throw;
            }
        }


        //Get the details of a particular user      
        public UserDetails GetUserData(string id)
        {
            try
            {
 
                FilterDefinition<UserDetails> filterUserData = Builders<UserDetails>.Filter.Eq("Id", id);

                return db.UserRecord.Find(filterUserData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        //user details by login
        public UserDetails GetUserLoginData(string username, string password)
        {
            try
            {
                List<UserDetails> ud = GetAllUsers();
                foreach (UserDetails user in ud)
                {
                    if (user.Username.Equals(username)&& user.Password.Equals(password))
                        return user;
                }
                UserDetails noUser = new UserDetails();
                noUser.Name = "NoUser";
                return noUser;
            }
            catch
            {
                throw;
            }
        }


        //To Update the records of a particular user      
        public void UpdateUser(UserDetails user)
        {
            try
            {
                db.UserRecord.ReplaceOne(filter: g => g.Id == user.Id, replacement: user);
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular user      
        public void DeleteUser(string id)
        {
            try
            {
                FilterDefinition<UserDetails> userData = Builders<UserDetails>.Filter.Eq("Id", id);
                db.UserRecord.DeleteOne(userData);
            }
            catch
            {
                throw;
            }
        }


        // To get the list of blogs  
        public List<UserBost> GetBlogData()
        {
            try
            {
                return db.UserBostRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }
        


        //To Add new blog record       
        public void AddUserBlog(UserBost blog)
        {
            try
            {
                db.UserBostRecord.InsertOne(blog);
            }
            catch
            {
                throw;
            }
        }


        //Get the details of a particular blog      
        public UserBost GetBlogData(string id)
        {
            try
            {
                FilterDefinition<UserBost> filterUserBlogData = Builders<UserBost>.Filter.Eq("Id", id);

                return db.UserBostRecord.Find(filterUserBlogData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateBlogPost(int id, string post, string title)
        {
            try
            {
                FilterDefinition<UserBost> filterUserBlogData = Builders<UserBost>.Filter.Eq("Id", id);

                UserBost blog= db.UserBostRecord.Find(filterUserBlogData).FirstOrDefault();
                blog.Post = post;
                blog.Title = title;
                db.UserBostRecord.ReplaceOne(filter: g => g.Id == blog.Id, replacement: blog);

            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particular blog      
        public void UpdateUserBlog(UserBost blog)
        {
            try
            {
                db.UserBostRecord.ReplaceOne(filter: g => g.Id == blog.Id, replacement: blog);
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular user      
        public void DeleteBlog(string id)
        {
            try
            {
                FilterDefinition<UserBost> userBlogData = Builders<UserBost>.Filter.Eq("Id", id);
                db.UserBostRecord.DeleteOne(userBlogData);
            }
            catch
            {
                throw;
            }
        }

        // CRUD of login

        public List<UserLogin> GetAllLogins()
        {
            try
            {
                return db.LoginRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new login record       
        public void AddLogin(UserLogin login)
        {
            try
            {
                db.LoginRecord.InsertOne(login);
            }
            catch
            {
                throw;
            }
        }




        //To Delete the record of a particular login      
        public void DeleteLogin(string id)
        {
            try
            {
                FilterDefinition<UserLogin> loginData = Builders<UserLogin>.Filter.Eq("Id", id);
                db.LoginRecord.DeleteOne(loginData);
            }
            catch
            {
                throw;
            }
        }
    }
}
