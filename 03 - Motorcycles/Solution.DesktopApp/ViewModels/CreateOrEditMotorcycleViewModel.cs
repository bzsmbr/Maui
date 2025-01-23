namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class CreateOrEditMotorcycleViewModel(AppDbContext dbContext) : MotorcycleModel
{
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingkAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);

    public IRelayCommand ManufacturerIndexChangedCommand => new RelayCommand(OnManufacturerIndexChanged);
    public IAsyncRelayCommand SaveCommand => new AsyncRelayCommand(OnSaveAsync);

    [ObservableProperty]
    private ICollection<ManufacturerModel> manufacturers;

    [ObservableProperty]
    private ManufacturerModel manufacturer;

    private async Task OnAppearingkAsync()
    {
        Manufacturers = await dbContext.Manufacturers.AsNoTracking()
                                                     .Select(x => new ManufacturerModel(x))
                                                     .ToListAsync();
    }

    private async Task OnDisappearingAsync()
    { }

    private void OnManufacturerIndexChanged()
    { 
        this.ManufacturerId.Value = Manufacturer.Id;
    }

    private async Task OnSaveAsync()
    {
    }
}
