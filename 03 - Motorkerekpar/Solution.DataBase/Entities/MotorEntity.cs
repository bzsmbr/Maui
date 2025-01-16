namespace Solution.Database.Entities;

public class MotorcycleEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [StringLength(128)]
    [Required]
    public string PublicId { get; set; }

    [StringLength(128)]
    [Required]
    public string Model { get; set; }

    [Required]
    public uint Cubic { get; set; }

    [Required]
    public uint Cylinders { get; set; }

    [Required]
    public uint ReleaseYear { get; set; }

    [ForeignKey("Manufacturer")]
    public uint ManufacturerId { get; set; }

    public virtual ManufacturerEntity Manufacturer { get; set; }
}
