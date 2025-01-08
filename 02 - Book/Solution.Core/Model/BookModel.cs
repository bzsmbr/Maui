using MauiValidationLibrary;
using MauiValidationLibrary.ValidationRules;

namespace Solution.Core.Models;


//Id, ISBN, Writer, Title, ReleaseYear, PublisherName

public partial class BookModel
{
    public string Id { get; set; }

    public ValidatableObject<string> Writer { get; protected set; }

    public ValidatableObject<string> Title { get; protected set; }

    public ValidatableObject<DateTime> ReleaseYear { get; protected set; }

    public ValidatableObject<string> PublisherName { get; protected set; }

    public BookModel()
    {
        

        AddValidators();
    }

    public BookModel(BookEntity entity) : this()
    {
        
    }

    public BookEntity ToEntity()
    {
        return new BookEntity
        {
            
        };
    }

    public void ToEntity(BookEntity entity)
    {
        
    }

    private void AddValidators()
    {
        this.Title.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Title is required field." });

        this.Length.Validations.Add(new NullableIntegerRule<uint?> { ValidationMessage = "Length is required field." });
        this.Length.Validations.Add(new MinValueRule<uint?>(1) { ValidationMessage = "Length can't bee less then 1." });
    }
}
