namespace Solution.Database.Entities;
[Table("Manufacturer")]
[Index(nameof(Name), IsUnique = true)]
public class ManufacturerEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual IReadOnlyCollection<MotorcycleEntity> Motors { get; set; }

}
