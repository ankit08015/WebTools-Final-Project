using System;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Linq;
using WordDaze.Shared;
using WordDaze.Shared.Models;

namespace WordDaze.Server
{
    public class BlogPostService
    {
        private List<UserBost> _blogPosts;
        UserDBContext db = new UserDBContext();

        public BlogPostService()
        {
            _blogPosts = new List<UserBost>();
            _blogPosts = GetBlogPosts();
        }

        public List<UserBost> GetBlogPosts() 
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

        //to get list of all blogs by particular user
        public List<UserBost> GetBlogDataByUser(string userId)
        {

            try
            {
                List<UserBost> bl = new List<UserBost>();
                List<UserBost> comBl = db.UserBostRecord.Find(_ => true).ToList();
                foreach (UserBost ub in comBl)
                {
                    if (ub.UserId.Equals(userId))
                    {
                        bl.Add(ub);
                    }
                }
                return bl;

            }
            catch
            {
                throw;
            }
        }

        public UserBost GetBlogPost(string id) 
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

        public UserBost AddBlogPost(UserBost newBlogPost)
        {
            // newBlogPost.Id = _blogPosts.Count + 1;
            try
            {
                db.UserBostRecord.InsertOne(newBlogPost);
            }
            catch
            {
                throw;
            }

            _blogPosts = GetBlogPosts();
            return newBlogPost;
        }

        public void UpdateBlogPost(string postId, string updatedPost, string updateTitle)
        {
            var originalBlogPost = _blogPosts.Find(x => x.Id == postId);
            
            originalBlogPost.Post = updatedPost;
            originalBlogPost.Title = updateTitle;

            try
            {
                db.UserBostRecord.ReplaceOne(filter: g => g.Id == originalBlogPost.Id, replacement: originalBlogPost);
            }
            catch
            {
                throw;
            }

        }

        public void DeleteBlogPost(string postId) 
        {
            var blogPost = _blogPosts.Find(x => x.Id == postId);

            try
            {
                FilterDefinition<UserBost> userBlogData = Builders<UserBost>.Filter.Eq("Id", postId);
                db.UserBostRecord.DeleteOne(userBlogData);
            }
            catch
            {
                throw;
            }

        }
    }
}