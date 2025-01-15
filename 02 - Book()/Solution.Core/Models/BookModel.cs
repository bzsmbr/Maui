using MauiValidationLibrary;
using MauiValidationLibrary.ValidationRules;

namespace Solution.Core.Models;


//Id, ISBN, Writer, Title, ReleaseYear, PublisherName

public partial class BookModel
{
    public string Id { get; set; }

    public ValidatableObject<string> ISBN { get; protected set; }

    public ValidatableObject<string> Writer { get; protected set; }

    public ValidatableObject<string> Title { get; protected set; }

    public ValidatableObject<int> ReleaseYear { get; protected set; }

    public ValidatableObject<string> PublisherName { get; protected set; }

    public BookModel()
    {
        this.ISBN = new ValidatableObject<string>();
        this.Writer = new ValidatableObject<string>();
        this.Title = new ValidatableObject<string>();
        this.ReleaseYear = new ValidatableObject<int>();
        this.PublisherName = new ValidatableObject<string>();


        AddValidators();
    }

    public BookModel(BookEntity entity) : this()
    {
        Id = entity.PublicId;
        ISBN.Value = entity.ISBN;
        Writer.Value = entity.Writer;
        Title.Value = entity.Title;
        ReleaseYear.Value = entity.ReleaseYear;
        PublisherName.Value = entity.PublisherName;
    }

    public BookEntity ToEntity()
    {
        return new BookEntity
        {
            PublicId = Id,
            ISBN = ISBN.Value,
            Writer = Writer.Value,
            Title = Title.Value,
            ReleaseYear = ReleaseYear.Value,
            PublisherName = PublisherName.Value
        };
    }

    public void ToEntity(BookEntity entity)
    {
        entity.PublicId = Id;
        entity.ISBN = ISBN.Value;
        entity.Writer = Writer.Value;
        entity.Title = Title.Value;
        entity.ReleaseYear = ReleaseYear.Value;
        entity.PublisherName = PublisherName.Value;
    }

    private void AddValidators()
    {

        this.Title.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Title is required field." });

    }
}
