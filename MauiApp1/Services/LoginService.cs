using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<UserInfo> Login(string username, string password)
        {
            try
            {
                if(Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                {
                    var userInfo = new UserInfo();
                    var client = new HttpClient();
                    string url = "http:" + username + "/" + password;
                    client.BaseAddress = new Uri(url);
                    HttpResponseMessage response = await client.GetAsync("");
                    if (response.IsSuccessStatusCode)
                    {
                        //string content = response.Content.ReadAsStringAsync().Result;
                        //userInfo = JsonConvert.DeserializeObject<List<UserInfo>>(content);
                        userInfo = await response.Content.ReadFromJsonAsync<UserInfo>();
                        return await Task.FromResult(userInfo);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            finally
            {
             
            }
        }
    }
}
