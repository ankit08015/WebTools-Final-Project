using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using WordDaze.Shared;
using System.Text;
using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;
using WordDaze.Shared.Models;

namespace WordDaze.Client.Features.Login
{
    public class SigninModel : BlazorComponent
    {
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject] private AppState _appState { get; set; }
        [Inject] private IUriHelper _uriHelper { get; set; }

        protected LoginDetails LoginDetails { get; set; } = new LoginDetails();
        protected bool ShowLoginFailed { get; set; }
        protected UserDetails user= new UserDetails();
        protected UserLogin login = new UserLogin();

        protected async Task Login()
        {


          
                //string login = LoginDetails.Username + "+" + LoginDetails.Password;
            user = await Http.GetJsonAsync<UserDetails>("api/User/LoginDetails/" + LoginDetails.Username + "/"+ LoginDetails.Password);
            bool isLoggedIn = true;
            if (user.Name.Equals("NoUser")) isLoggedIn = false;

           //await _appState.Login(isLoggedIn, user);

            if (isLoggedIn)
            {
                login.UserId = user.Id;
                await Http.SendJsonAsync(HttpMethod.Post, "/api/Login/Create", login);

                if (user.UserType.Equals("Normal"))_uriHelper.NavigateTo("/userhome");
                else
                {
                    _uriHelper.NavigateTo("/adminhome");

                }
            }
            else
            {
                ShowLoginFailed = true;
            }
        }
    }
}