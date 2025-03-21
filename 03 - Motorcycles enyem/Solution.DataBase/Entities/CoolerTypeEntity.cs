﻿namespace Solution.Database.Entities;

[Table("CoolerType")]
[Index(nameof(Name), IsUnique = true)]
public class CoolerTypeEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [StringLength(64)]
    [Required]
    public string Name { get; set; }

    public virtual ICollection<MotorcycleEntity> Motorcycles { get; set; }
}