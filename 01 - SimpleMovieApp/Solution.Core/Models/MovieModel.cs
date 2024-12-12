

namespace Solution.Core.Models;

public partial class MovieModel : ObservableObject
{
    [ObservableProperty]
    private ValidatableObject<string> id;

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private uint? length;

    [ObservableProperty]
    private DateTime release;

    public MovieModel()
    {
    }

    public MovieModel(MovieEntity entity)
    {
        Id = entity.PublicId;
        Title = entity.Title;
        Length = entity.Length;
        Release = entity.Release;
    }

    public MovieEntity ToEntity()
    {
        return new MovieEntity()
        {
            PublicId = Id,
            Title = Title,
            Length = Length.HasValue ? Length.Value : 0,
            Release = Release
        };
    }

    public void ToEntity(MovieEntity entity)
    {
        entity.PublicId = Id;
        entity.Title = Title;
        entity.Length = Length.HasValue ? Length.Value : 0;
        entity.Release = Release;


    }
}
