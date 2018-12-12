using Microsoft.AspNetCore.Blazor.Components;
using WordDaze.Shared.Models;

namespace WordDaze.Client.Features.Home
{
    public class BlogPostPreviewModel : BlazorComponent
    {
        [Parameter] protected UserBost blogPost { get; set; }
    }
}