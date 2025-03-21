﻿namespace Solution.Services;

public class MotorcycleService(AppDbContext dbContext) : IMotorcycleService
{
    private const int ROW_COUNT = 10;

    public async Task<ErrorOr<MotorcycleModel>> CreateAsync(MotorcycleModel model)
    {
        bool exists = await dbContext.Motorcycles.AnyAsync(x => x.ManufacturerId == model.Manufacturer.Value.Id &&
                                                                x.TypeId == model.Type.Value.Id &&
                                                                x.CoolerTypeId == model.CoolerType.Value.Id &&
                                                                x.Model.ToLower() == model.Model.Value.ToLower().Trim() &&
                                                                x.ReleaseYear == model.ReleaseYear.Value);

        if (exists)
        {
            return Error.Conflict(description: "Motorcycle already exists!");
        }

        var motorcycle = model.ToEntity();
        motorcycle.PublicId = Guid.NewGuid().ToString();
        
        await dbContext.Motorcycles.AddAsync(motorcycle);
        await dbContext.SaveChangesAsync();

        return new MotorcycleModel(motorcycle)
        {
            Manufacturer = model.Manufacturer,
            Type = model.Type
        };
    }

    public async Task<ErrorOr<Success>> UpdateAsync(MotorcycleModel model)
    {
        var result = await dbContext.Motorcycles.AsNoTracking()
                                                .Include(x => x.Manufacturer)
                                                .Include(x => x.Type)
                                                .Include(x => x.CoolerType)
                                                .Where(x => x.PublicId == model.Id)
                                                .ExecuteUpdateAsync(x => x.SetProperty(p => p.PublicId, model.Id)
                                                                          .SetProperty(p => p.ManufacturerId, model.Manufacturer.Value.Id)
                                                                          .SetProperty(p => p.TypeId, model.Type.Value.Id)
                                                                          .SetProperty(p => p.CoolerTypeId, model.CoolerType.Value.Id)
                                                                          .SetProperty(p => p.Model, model.Model.Value)
                                                                          .SetProperty(p => p.Cubic, model.Cubic.Value)
                                                                          .SetProperty(p => p.ReleaseYear, model.ReleaseYear.Value)
                                                                          .SetProperty(p => p.Cylinders, model.NumberOfCylinders.Value));
        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<Success>> DeleteAsync(string motorcycleId)
    {
        var result = await dbContext.Motorcycles.AsNoTracking()
                                                .Include(x => x.Manufacturer)
                                                .Include(x => x.Type)
                                                .Include(x => x.CoolerType)
                                                .Where(x => x.PublicId == motorcycleId)
                                                .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<MotorcycleModel>> GetByIdAsync(string motorcycleId)
    {
        var motorcycle = await dbContext.Motorcycles.Include(x => x.Manufacturer)
                                                    .Include(x => x.Type)
                                                    .Include(x => x.CoolerType)
                                                    .FirstOrDefaultAsync(x => x.PublicId == motorcycleId);

        if (motorcycle is null)
        {
            return Error.NotFound(description: "Motorcycle not found.");
        }

        return new MotorcycleModel(motorcycle);
    }

    public async Task<ErrorOr<List<MotorcycleModel>>> GetAllAsync() =>
        await dbContext.Motorcycles.AsNoTracking()
                                   .Include(x => x.Manufacturer)
                                   .Include(x => x.Type)
                                   .Include(x => x.CoolerType)
                                   .Select(x => new MotorcycleModel(x))
                                   .ToListAsync();

    public async Task<ErrorOr<PaginationModel<MotorcycleModel>>> GetPagedAsync(int page = 0)
    {
        page = page < 0 ? 0 : page - 1;

        var motorcycles =  await dbContext.Motorcycles.AsNoTracking()
                                                      .Include(x => x.Manufacturer)
                                                      .Include(x => x.Type)
                                                      .Include(x => x.CoolerType)
                                                      .Skip(page * ROW_COUNT)
                                                      .Take(ROW_COUNT)
                                                      .Select(x => new MotorcycleModel(x))
                                                      .ToListAsync();

        var paginationModel = new PaginationModel<MotorcycleModel>
        {
            Items = motorcycles,
            Count = await dbContext.Motorcycles.CountAsync()
        };

        return paginationModel;
    }
}
