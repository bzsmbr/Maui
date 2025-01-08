
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Movie")]
[Index(nameof(ISBN), IsUnique = true)]
public class BookEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    //ISBN
    [Required]
    public string ISBN { get; set; }

    //Writer/s
    [Required]
    public string Writer { get; set; }

    //Title
    [Required]
    public string Title { get; set; }

    //Release year
    [Required]
    public DateTime ReleaseYear { get; set; }

    //Publisher Name
    [Required]
    public string PublisherName { get; set; }
}