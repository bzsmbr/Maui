namespace Solution.DesktopApp.ViewModels;

public partial class MainPageViewModel: MovieModel
{
    [ObservableProperty]
    private double datePickerWidth;

    public DateTime MaxDateTime => DateTime.Now;

    public IAsyncRelayCommand OnSubmitCommand => new AsyncRelayCommand(OnSubmitAsync);

    private readonly IMovieService movieService;

    public MainPageViewModel(IMovieService movieService)
    {
        this.movieService = movieService;
        this.Release = DateTime.Now;
    }

    private async Task OnSubmitAsync()
    {
        await movieService.CreateAsync(this);
    }
}
