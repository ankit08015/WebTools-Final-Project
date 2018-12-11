using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using WordDaze.Shared.Models;
using WordDaze.Shared;

namespace WordDaze.Client.Features.Home
{
    public class UserHomeModel : BlazorComponent
    {
        [Inject] private HttpClient _httpClient { get; set; }

        protected List<BlogPost> blogPosts { get; set; } = new List<BlogPost>();

        protected override async Task OnInitAsync()
        {
            await LoadBlogPosts();
        }

        private async Task LoadBlogPosts()
        {
            var blogPostsResponse = await _httpClient.GetJsonAsync<List<BlogPost>>(Urls.BlogPosts);
            blogPosts = blogPostsResponse.OrderByDescending(p => p.Posted).ToList();
        }
    }
}