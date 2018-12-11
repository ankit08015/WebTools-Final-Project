using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using WordDaze.Shared.Models;

namespace WordDaze.Client.Features.Home
{
    public class UserModel : BlazorComponent
    {
        [Inject]
        protected HttpClient Http { get; set; }

        protected List<UserDetails> userList;
        protected List<UserBost> blogList;
        protected List<UserLogin> loginList;

        protected UserDetails user = new UserDetails();
        protected UserBost blog = new UserBost();
        protected string modalTitle { get; set; }
        protected Boolean isDelete = false;
        protected Boolean isAdd = false;

        protected string SearchString { get; set; }

        protected override async Task OnInitAsync()
        {
            
            await GetUsers();
            await GetBlogs();
            await GetLogins();
        }

        protected async Task GetUsers()
        {
            userList = await Http.GetJsonAsync<List<UserDetails>>("api/User/Index");
        }

        protected async Task GetLogins()
        {
            loginList = await Http.GetJsonAsync<List<UserLogin>>("api/Login/Index");
        }

        protected async Task GetBlogs()
        {
            blogList = await Http.GetJsonAsync<List<UserBost>>("api/Blog/Index");
        }

        protected void AddUser()
        {
            user = new UserDetails();
            this.modalTitle = "Add User";
            this.isAdd = true;
        }

        protected async Task EditUser(string ID)
        {
            user = await Http.GetJsonAsync<UserDetails>("api/User/Details/" + ID);
            this.modalTitle = "Edit User";
            this.isAdd = true;
        }

        protected async Task SaveUser()
        {
            if (user.Id != null)
            {
                await Http.SendJsonAsync(HttpMethod.Put, "api/User/Edit", user);
            }
            else
            {
                await Http.SendJsonAsync(HttpMethod.Post, "/api/User/Create", user);

            }
            this.isAdd = false;
            await GetUsers();
        }

        protected async Task DeleteConfirm(string ID)
        {
            user = await Http.GetJsonAsync<UserDetails>("/api/User/Details/" + ID);
            this.isDelete = true;
        }

        protected async Task DeleteUser(string ID)
        {
            await Http.DeleteAsync("api/User/Delete/" + ID);

            this.isDelete = false;
            await GetUsers();
        }
        protected void closeModal()
        {
            this.isAdd = false;
            this.isDelete = false;
        }
    }
}