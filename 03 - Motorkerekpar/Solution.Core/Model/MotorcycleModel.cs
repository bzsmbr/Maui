using Solution.ValidationLibrary.ValidationRules;
using Solution.ValidationLibrary;
using Solution.Database.Entities;

namespace Solution.Core.Model;

public class MotorcycleModel
{
    public string Id { get; set; }

    public ValidatableObject<uint> ManufacturerId { get; set; }

    public ValidatableObject<string> Model { get; protected set; }

    public ValidatableObject<uint?> Cubic { get; protected set; }

    public ValidatableObject<uint?> ReleaseYear { get; protected set; }

    public ValidatableObject<uint?> Cylinders { get; protected set; }

    public MotorcycleModel()
    {
        this.ManufacturerId = new ValidatableObject<uint>();
        this.Model = new ValidatableObject<string>();
        this.Cubic = new ValidatableObject<uint?>();
        this.ReleaseYear = new ValidatableObject<uint?>();
        this.Cylinders = new ValidatableObject<uint?>();

        AddValidators();
    }

    public MotorcycleModel(MotorcycleEntity entity) : this()
    {
        this.Id = entity.PublicId;
        this.ManufacturerId.Value = entity.ManufacturerId;
        this.Model.Value = entity.Model;
        this.Cubic.Value = entity.Cubic;
        this.ReleaseYear.Value = entity.ReleaseYear;
        this.Cylinders.Value = entity.Cylinders;
    }

    public MotorcycleEntity ToEntity()
    {
        return new MotorcycleEntity
        {
            PublicId = Id,
            ManufacturerId = this.ManufacturerId.Value,
            Model = this.Model.Value,
            Cubic = this.Cubic.Value ?? 0,
            ReleaseYear = this.ReleaseYear.Value ?? 0,
            Cylinders = this.Cylinders.Value ?? 0
        };
    }

    public void ToEntity(MotorcycleEntity entity)
    {
        entity.PublicId = Id;
        entity.ManufacturerId = this.ManufacturerId.Value;
        entity.Model = this.Model.Value;
        entity.Cubic = this.Cubic.Value ?? 0;
        entity.ReleaseYear = this.ReleaseYear.Value ?? 0;
        entity.Cylinders = this.Cylinders.Value ?? 0;
    };


    private void AddValidators()
    {
        this.ManufacturerId.Validations.Add(new MinValueRule<uint>(1)
        {
            ValidationMessage = "Manufacturer must be selected."
        });

        this.Model.Validations.Add(new IsNotNullOrEmptyRule<string> 
        { 
            ValidationMessage = "Model is required." 
        });

        this.Cubic.Validations.AddRange(
        [
            new IsNotNullOrEmptyRule<uint?>
            {
                ValidationMessage = "Cubic field is required."
            },
            new MinValueRule<uint?>(1)
            {
                ValidationMessage = "Cubic field must be greater than 0"
            }

        ]);

        this.ReleaseYear.Validations.AddRange(
        [
            new IsNotNullOrEmptyRule<uint?>
            {
                ValidationMessage = "Release year field is required."
            },
            new MaxValueRule<uint?>(DateTime.Now.Year)
            {
                ValidationMessage = $"Release year field cant exceed {(DateTime.Now.Year)}"
            }
        ]);

        this.Cylinders.Validations.AddRange(
        [
            new IsNotNullOrEmptyRule<uint?>
            {
                ValidationMessage = "Cylinders field is required."
            }
        ]);


    }
}
