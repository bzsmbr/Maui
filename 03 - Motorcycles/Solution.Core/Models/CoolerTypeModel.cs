namespace Solution.Core.Models;

public class CoolerTypeModel : IObjectValidator<uint>
{
    public uint Id { get; set; }

    public string Name { get; set; }

    public CoolerTypeModel()
    {
    }

    public CoolerTypeModel(uint id, string name)
    {
        Id = id;
        Name = name;
    }

    public CoolerTypeModel(CoolerTypeEntity entity)
    {
        if (entity is null)
        {
            return;
        }

        Id = entity.Id;
        Name = entity.Name;
    }

    public override bool Equals(object? obj)
    {
        return obj is CoolerTypeModel model &&
               this.Id == model.Id &&
               this.Name == model.Name;
    }
}
