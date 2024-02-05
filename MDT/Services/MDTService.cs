using MDT.Lib.Endpoints;
using MDT.Models;

namespace MDT.Services;

public class MDTService
{
    private readonly HttpClient _client;

    public MDTService()
    {
        _client = new();
        _client.BaseAddress = new Uri(Endpoints.BASE);
    }
    
    public async Task<IEnumerable<UsersModel>> GetAllUsers()
    {
        return await _client.GetFromJsonAsync<IEnumerable<UsersModel>>($"{Endpoints.GetUsers}");
    }

    public bool LoginCheck(LoginModel login)
    {
        var users = GetAllUsers().GetAwaiter().GetResult();

        var foundUser = users.FirstOrDefault(x => x.Username == login.Username && x.Password == login.Password);

        if (foundUser != null)
        {
            return true;
        }

        return false;
    }
}