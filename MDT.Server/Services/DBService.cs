using System.Collections;
using Mapster;
using MDT.Lib.Models;
using MDT.Server.Data;
using MDT.Server.Data.Migrations;
using Microsoft.EntityFrameworkCore;

namespace MDT.Server.Services;

public class DBService
{
    private readonly ApplicationDbContext _db;

    public DBService(ApplicationDbContext db)
    {
        _db = db;
    }

    public Task<IEnumerable<CitizenModel>> GetCitizens()
    {
        var citizens = _db.Citizens.ProjectToType<CitizenModel>();

        return Task.FromResult<IEnumerable<CitizenModel>>(citizens);
    }

    public Task<IEnumerable<CarModel>> GetCars()
    {
        var cars = _db.Cars.ProjectToType<CarModel>();

        return Task.FromResult<IEnumerable<CarModel>>(cars);
    }

    public Task<IEnumerable<RecordModel>> GetRecords()
    {
        var records = _db.Records.ProjectToType<RecordModel>();

        return Task.FromResult<IEnumerable<RecordModel>>(records);
    }

    public Task<IEnumerable<FineModel>> GetFines()
    {
        var fines = _db.Fines.ProjectToType<FineModel>();

        return Task.FromResult<IEnumerable<FineModel>>(fines);
    }

    public Task<IEnumerable<WarrantModel>> GetWarrants()
    {
        var warrants = _db.Warrants.ProjectToType<WarrantModel>();

        return Task.FromResult<IEnumerable<WarrantModel>>(warrants);
    }

    public Task<CitizenModel> GetCitizenById(Guid id)
    {
        var querry = _db.Citizens.ProjectToType<CitizenModel>();

        foreach (var citizen in querry)    
        {
            if (citizen.Id == id)
            {
                return Task.FromResult(citizen);
            }
        }

        return null;
    }

    public Task<CarModel> GetCarById(Guid id)
    {
        var querry = _db.Cars.ProjectToType<CarModel>();

        foreach (var car in querry)
        {
            if (car.Id == id)
            {
                return Task.FromResult(car); 
            }
        }

        return null;
    }

    public Task<RecordModel> GetRecordById(Guid id)
    {
        var querry = _db.Records.ProjectToType<RecordModel>();

        foreach (var record in querry)
        {
            if (record.Id == id)
            {
                return Task.FromResult(record);
            }
        }

        return null;
    }

    public Task<FineModel> GetFineById(Guid id)
    {
        var querry = _db.Fines.ProjectToType<FineModel>();

        foreach (var fine in querry)    
        {
            if (fine.Id == id)
            {
                return Task.FromResult(fine);
            }
        }

        return null;
    }

    public Task<WarrantModel> GetWarrantById(Guid id)
    {
        var querry = _db.Warrants.ProjectToType<WarrantModel>();

        foreach (var warrant in querry)
        {
            if (warrant.Id == id)
            {
                return Task.FromResult(warrant);
            }
        }

        return null;
    }

    public Task<IEnumerable<CarModel>> GetOwnedCars(Guid id)
    {
        var querry = _db.Cars.ProjectToType<CarModel>();
        List<CarModel> cars = new();

        foreach (var car in querry)
        {
            if (car.CitizenId == id)
            {
                cars.Add(car);
            }
        }

        return Task.FromResult<IEnumerable<CarModel>>(cars);
    }

    public Task<IEnumerable<RecordModel>> GetOwnedRecords(Guid id)
    {
        var querry = _db.Records.ProjectToType<RecordModel>();
        List<RecordModel> records = new();

        foreach (var record in querry)
        {
            if (record.CitizenId == id)
            {
                records.Add(record);
            }
        }

        return Task.FromResult<IEnumerable<RecordModel>>(records);
    }

    public Task<IEnumerable<FineModel>> GetOwnedFines(Guid id)
    {
        var querry = _db.Fines.ProjectToType<FineModel>();
        List<FineModel> fines = new();

        foreach (var fine in querry)
        {
            if (fine.CitizenId == id)
            {
                fines.Add(fine);
            }
        }

        return Task.FromResult<IEnumerable<FineModel>>(fines);
    }

    public Task<IEnumerable<WarrantModel>> GetOwnedWarrants(Guid id)
    {
        var querry = _db.Warrants.ProjectToType<WarrantModel>();
        List<WarrantModel> warrants = new();

        foreach (var warrant in querry)
        {
            if (warrant.CitizenId == id)
            {
                warrants.Add(warrant);
            }
        }

        return Task.FromResult<IEnumerable<WarrantModel>>(warrants);
    }

    public void CreateWarrant(WarrantModel warrant)
    {
        var dto = warrant.Adapt<Warrant>();
        _db.Warrants.Add(dto);
        _db.SaveChanges();
    }

    public void CreateRecord(RecordModel record)
    {
        var dto = record.Adapt<Record>();
        _db.Records.Add(dto);
        _db.SaveChanges();
    }

    public void CreateFine(FineModel fine)
    {
        var dto = fine.Adapt<Fine>();
        _db.Fines.Add(dto);
        _db.SaveChanges();
    }

    public void CreateCar(CarModel car)
    {
        var dto = car.Adapt<Car>();
        _db.Cars.Add(dto);
        _db.SaveChanges();
    }

    public void DeleteWarrant(Guid id)
    {
        var warrant = _db.Warrants.FirstOrDefault(x => x.Id == id);

        _db.Warrants.Remove(warrant);
        _db.SaveChanges();
    }

    public void DeleteRecord(Guid id)
    {
        var record = _db.Records.FirstOrDefault(x => x.Id == id);

        _db.Records.Remove(record);
        _db.SaveChanges();
    }

    public void DeleteFine(Guid id)
    {
        var fine = _db.Fines.FirstOrDefault(x => x.Id == id);

        _db.Fines.Remove(fine);
        _db.SaveChanges();
    }

    public void DeleteCar(Guid id)
    {
        var car = _db.Cars.FirstOrDefault(x => x.Id == id);

        _db.Cars.Remove(car);
        _db.SaveChanges();
    }

    public void EditWarrant(WarrantModel model)
    {
        var dto = model.Adapt<Warrant>();
        var warrant = _db.Warrants.FirstOrDefault(x => x.Id == dto.Id);

        warrant.Reason = dto.Reason;
        
        _db.SaveChanges();
    }

    public void EditRecord(RecordModel model)
    {
        var dto = model.Adapt<Record>();
        var record = _db.Records.FirstOrDefault(x => x.Id == dto.Id);

        record.Name = dto.Name;
        record.Description = dto.Description;
        record.YearsInJail = dto.YearsInJail;
        
        _db.SaveChanges();
    }

    public void EditFine(FineModel model)
    {
        var dto = model.Adapt<Fine>();
        var fine = _db.Fines.FirstOrDefault(x => x.Id == dto.Id);
        

        fine.Name = dto.Name;
        fine.Description = dto.Description;
        fine.Price = dto.Price;
        
        _db.SaveChanges();
    }

    public void EditCar(CarModel model)
    {
        var dto = model.Adapt<Car>();
        var car = _db.Cars.FirstOrDefault(x => x.Id == dto.Id);

        car.Model = dto.Model;
        car.Plate = dto.Plate;
        
        _db.SaveChanges();
    }
}