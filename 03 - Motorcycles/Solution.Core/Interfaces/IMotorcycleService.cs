namespace Solution.Core.Interfaces;

public interface IMotorcycleService
{
    Task<ErrorOr<MotorcycleModel>> CreateAsync(MotorcycleModel model);
    Task<ErrorOr<Success>> DeleteAsync(string motorcycleId);
    Task<ErrorOr<List<MotorcycleModel>>> GetAllAsync();
    Task<ErrorOr<MotorcycleModel>> GetByIdAsync(string motorcycleId);
    Task<ErrorOr<List<MotorcycleModel>>> GetPagedAsync(int page = 0);
    Task<ErrorOr<MotorcycleModel>> UpdateAsync(MotorcycleModel model);
}
