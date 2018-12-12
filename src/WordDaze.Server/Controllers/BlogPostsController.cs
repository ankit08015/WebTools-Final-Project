using WordDaze.Shared;
using WordDaze.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WordDaze.Server.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly BlogPostService _blogPostService;

        public BlogPostsController(BlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet(Urls.BlogPosts)]
        public IActionResult GetBlogPosts()
        {
            return Ok(_blogPostService.GetBlogPosts());
        }

        [HttpGet(Urls.BlogPost)]
        public IActionResult GetBlogPostById(string id)
        {
            var blogPost = _blogPostService.GetBlogPost(id);

            if (blogPost == null)
                return NotFound();

            return Ok(blogPost);
        }

        [Authorize]
        [HttpPost(Urls.AddBlogPost)]
        public IActionResult AddBlogPost([FromBody]UserBost newBlogPost)
        {
            newBlogPost.Author = Request.HttpContext.User.Identity.Name;
            var savedBlogPost = _blogPostService.AddBlogPost(newBlogPost);

            return Created(new Uri(Urls.BlogPost.Replace("{id}", savedBlogPost.Id.ToString()), UriKind.Relative), savedBlogPost);
        }

        [Authorize]
        [HttpPut(Urls.UpdateBlogPost)]
        public IActionResult UpdateBlogPost(string id, [FromBody]UserBost updatedBlogPost)
        {
            _blogPostService.UpdateBlogPost(id, updatedBlogPost.Post, updatedBlogPost.Title);

            return Ok();
        }

        [Authorize]
        [HttpDelete(Urls.DeleteBlogPost)]
        public IActionResult DeleteBlogPost(string id)
        {
            _blogPostService.DeleteBlogPost(id);

            return Ok();
        }
    }
}
