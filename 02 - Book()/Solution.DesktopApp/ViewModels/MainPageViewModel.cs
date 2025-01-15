using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErrorOr;
using Solution.Core.Interfaces;
using Solution.Core.Models;

namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class MainPageViewModel : BookModel
{
    public DateTime MaxDateTime => DateTime.Now;

    [ObservableProperty]
    private double datePickerWidth;

    public IAsyncRelayCommand OnSubmitCommand => new AsyncRelayCommand(OnSubmitAsync);

    public IRelayCommand ISBNValidationCommand => new RelayCommand(() => ISBN.Validate());



    private readonly IBookService bookService;

    public MainPageViewModel(IBookService bookService) : base()
    {
        this.bookService = bookService;
        this.ReleaseYear.Value = DateTime.Now.Year;
    }

    private async Task OnSubmitAsync()
    {
        if (!IsFormValid)
        {
            return;
        }

        ErrorOr<BookModel> serviceResponse = await bookService.CreateAsync(this);

        string alertMessage = serviceResponse.IsError ? serviceResponse.FirstError.Description : "Movie saved!";
        await Application.Current!.MainPage!.DisplayAlert("Alert", alertMessage, "OK");
    }

    private bool IsFormValid => ISBN.IsValid &&
                                Writer.IsValid &&
                                Title.IsValid &&
                                PublisherName.IsValid;


}
