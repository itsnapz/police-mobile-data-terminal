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

    public async Task<IEnumerable<WarrantModel>> GetWarrants()
    {
        return await _client.GetFromJsonAsync<IEnumerable<WarrantModel>>($"{Endpoints.GET_WARRANTS}");
    }

    public async Task<CitizenModel> GetCitizen(Guid id)
    {
        return await _client.GetFromJsonAsync<CitizenModel>($"{Endpoints.GET_CITIZEN}?id={id}");
    }

    public async Task<CarModel> GetCar(Guid id)
    {
        return await _client.GetFromJsonAsync<CarModel>($"{Endpoints.GET_CAR}?id={id}");
    }

    public async Task<RecordModel> GetRecord(Guid id)
    {
        return await _client.GetFromJsonAsync<RecordModel>($"{Endpoints.GET_RECORD}?id={id}");
    }

    public async Task<FineModel> GetFine(Guid id)
    {
        return await _client.GetFromJsonAsync<FineModel>($"{Endpoints.GET_FINE}?id={id}");
    }

    public async Task<WarrantModel> GetWarrant(Guid id)
    {
        return await _client.GetFromJsonAsync<WarrantModel>($"{Endpoints.GET_WARRANT}?id={id}");
    }

    public async Task<IEnumerable<CarModel>> GetOwnedCars(Guid id)
    {
        return await _client.GetFromJsonAsync<IEnumerable<CarModel>>($"{Endpoints.GET_OWNED_CARS}?id={id}");
    }

    public async Task<IEnumerable<RecordModel>> GetOwnedRecords(Guid id)
    {
        return await _client.GetFromJsonAsync<IEnumerable<RecordModel>>($"{Endpoints.GET_OWNED_RECORDS}?id={id}");
    }

    public async Task<IEnumerable<FineModel>> GetOwnedFines(Guid id)
    {
        return await _client.GetFromJsonAsync<IEnumerable<FineModel>>($"{Endpoints.GET_OWNED_FINES}?id={id}");
    }

    public async Task<IEnumerable<WarrantModel>> GetOwnedWarrants(Guid id)
    {
        return await _client.GetFromJsonAsync<IEnumerable<WarrantModel>>($"{Endpoints.GET_OWNED_WARRANTS}?id={id}");
    }
}