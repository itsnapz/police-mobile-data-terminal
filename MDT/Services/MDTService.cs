using MDT.Lib.Endpoints;

namespace MDT.Services;

public class MDTService
{
    private readonly HttpClient _client;

    public MDTService()
    {
        _client = new();
        _client.BaseAddress = new Uri(Endpoints.BASE);
    }
}