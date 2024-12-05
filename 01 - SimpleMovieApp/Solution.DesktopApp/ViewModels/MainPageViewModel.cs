using CommunityToolkit.Mvvm.Input;
using Solution.Database.Entities;

namespace Solution.DesktopApp.ViewModels;

public class MainPageViewModel : MovieModel
{
    public DateTime MaxDateTime => DateTime.Now;

    public IAsyncRelayCommand OnSubmitCommand => new AsyncRelayCommand(OnSubmitAsync);

    private async Task OnSubmitAsync()
    { }

    public MainPageViewModel()
    {
        this.Release = DateTime.Now;
    }
}
