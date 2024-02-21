using System.Collections;
using MDT.Lib.Endpoints;
using MDT.Lib.Models;
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

    public async Task<IEnumerable<CitizenModel>> GetCitizens()
    {
        return await _client.GetFromJsonAsync<IEnumerable<CitizenModel>>($"{Endpoints.GET_CITIZENS}");
    }

    public async Task<IEnumerable<CarModel>> GetCars()
    {
        return await _client.GetFromJsonAsync<IEnumerable<CarModel>>($"{Endpoints.GET_CARS}");
    }

    public async Task<IEnumerable<RecordModel>> GetRecords()
    {
        return await _client.GetFromJsonAsync<IEnumerable<RecordModel>>($"{Endpoints.GET_RECORDS}");
    }

    public async Task<IEnumerable<FineModel>> GetFines()
    {
        return await _client.GetFromJsonAsync<IEnumerable<FineModel>>($"{Endpoints.GET_FINES}");
    }
}