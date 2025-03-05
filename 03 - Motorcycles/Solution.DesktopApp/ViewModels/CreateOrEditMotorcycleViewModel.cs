using ErrorOr;

namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class CreateOrEditMotorcycleViewModel(
    AppDbContext dbContext,
    IMotorcycleService motorcycleService,
    IGoogleDriveService googleDriveService) : MotorcycleModel(), IQueryAttributable
{
    #region life cycle commands
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingkAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);
    #endregion

    #region validation commands
    public IRelayCommand ManufacturerIndexChangedCommand => new RelayCommand(() => this.Manufacturer.Validate());

    public IRelayCommand TypeIndexChangedCommand => new RelayCommand(() => this.Type.Validate());

    public IRelayCommand CoolerTypeIndexChangedCommand => new RelayCommand(() => this.Type.Validate());

    public IRelayCommand CylindersIndexChangedCommand => new RelayCommand(() => this.NumberOfCylinders.Validate());
    public IRelayCommand ModelValidationCommand => new RelayCommand(() => this.Model.Validate());
    public IRelayCommand CubicValidationCommand => new RelayCommand(() => this.Cubic.Validate());
    public IRelayCommand ReleaseYearValidationCommand => new RelayCommand(() => this.ReleaseYear.Validate());
    #endregion

    #region event commands
    public IAsyncRelayCommand SubmitCommand => new AsyncRelayCommand(OnSubmitAsync);

    public IAsyncRelayCommand ImageSelectCommand => new AsyncRelayCommand(OnImageSelectAsync);
    #endregion

    private delegate Task ButtonActionDelegate(); // fuggveny ertekeket tudunk neki adni ami taskokat ad vissza es nincs parametere
    private ButtonActionDelegate asyncButtonAction;

    [ObservableProperty] 
    private string title;

    [ObservableProperty]
    private IList<ManufacturerModel> manufacturers = [];

    [ObservableProperty]
    private IList<TypeModel> types = [];

    [ObservableProperty]
    private IList<CoolerTypeModel> coolerTypes = [];

    [ObservableProperty]
    private IList<uint> cylinders = [1, 2, 3, 4, 6, 8];

    [ObservableProperty]
    private ImageSource image;

    private FileResult selectedFile = null;

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        await Task.Run(() => LoadManufacturers());

        await Task.Run(() => LoadTypes());

        await Task.Run(() => LoadCoolerTypes());

        bool hasValue = query.TryGetValue("Motorcycle", out object result);

        if(!hasValue)
        {
            asyncButtonAction = OnSaveAsync;
            return;
        }

        MotorcycleModel motorcycle = result as MotorcycleModel;

        this.Id = motorcycle.Id;
        this.Manufacturer.Value = motorcycle.Manufacturer.Value;
        this.Type.Value = motorcycle.Type.Value;
        this.CoolerType.Value = motorcycle.CoolerType.Value;
        this.Model.Value = motorcycle.Model.Value;
        this.ReleaseYear.Value = motorcycle.ReleaseYear.Value;
        this.Cubic.Value = motorcycle.Cubic.Value;
        this.NumberOfCylinders.Value = motorcycle.NumberOfCylinders.Value;

        asyncButtonAction = OnUpdateAsync;
        Title = "Update motorcycle";
        return;
    }

    private async Task OnAppearingkAsync()
    {
    }

    private async Task OnDisappearingAsync()
    { 
    }
    private async Task OnSubmitAsync() => await asyncButtonAction();

    private async Task OnSaveAsync()
    {
        if (!IsFormValid())
        {
            return;
        }

        await UploadImageAsync();

        var result = await motorcycleService.CreateAsync(this);

        var message = result.IsError ? result.FirstError.Description : "Motorcycle saved.";
        var title = result.IsError ? "Error" : "Information";

        if(!result.IsError)
        {
            ClearForm();
        }

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private async Task OnUpdateAsync() 
    {
        if (!IsFormValid())
        {
            return;
        }

        await UploadImageAsync();

        var result = await motorcycleService.UpdateAsync(this);

        var message = result.IsError ? result.FirstError.Description : "Motorcycle updated.";

        var title = result.IsError ? "Error" : "Information";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private async Task OnImageSelectAsync()
    {
        selectedFile = await FilePicker.PickAsync(new PickOptions
        { 
            FileTypes = FilePickerFileType.Images,
            PickerTitle = "Please select the motorcycle image"
        });

        if (selectedFile is null)
        {
            return;
        }

        var stream = await selectedFile.OpenReadAsync();
        this.Image = ImageSource.FromStream(() => stream);
    }

    private async Task UploadImageAsync()
    {
        if (selectedFile is null)
        {
            return;
        }

        var imageUploadResult = await googleDriveService.UploadFileAsync(selectedFile);

        var message = imageUploadResult.IsError ? imageUploadResult.FirstError.Description : "Motorcycle image uploaded.";
        var title = imageUploadResult.IsError ? "Error" : "Information";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");

        this.ImageId = imageUploadResult.IsError ? null : imageUploadResult.Value.Id;
        this.WebContentLink = imageUploadResult.IsError ? null : imageUploadResult.Value.WebContentLink;
    }

    private async Task LoadManufacturers()
    {
        Manufacturers = await dbContext.Manufacturers.AsNoTracking()
                                                        .OrderBy(x => x.Name)
                                                        .Select(x => new ManufacturerModel(x))
                                                        .ToListAsync();
    }

    private async Task LoadTypes()
    {
        Types = await dbContext.Types.AsNoTracking()
                                     .OrderBy(x => x.Name)
                                     .Select(x => new TypeModel(x))
                                     .ToListAsync();
    }

    private async Task LoadCoolerTypes()
    {
        CoolerTypes = await dbContext.CoolerTypes.AsNoTracking()
                                     .OrderBy(x => x.Name)
                                     .Select(x => new CoolerTypeModel(x))
                                     .ToListAsync();
    }

    private void ClearForm()
    {
        this.Manufacturer.Value = null;
        this.Type.Value = null;
        this.CoolerType.Value = null;
        this.Model.Value = null;
        this.Cubic.Value = null;
        this.ReleaseYear.Value = null;
        this.NumberOfCylinders.Value = null;
    }

    private bool IsFormValid()
    {
        this.Manufacturer.Validate();
        this.Type.Validate();
        this.CoolerType.Validate();
        this.Model.Validate();
        this.Cubic.Validate();
        this.ReleaseYear.Validate();
        this.NumberOfCylinders.Validate();


        return (this.Manufacturer?.IsValid ?? false) &&
               (this.Type?.IsValid ?? false) &&
               (this.CoolerType?.IsValid ?? false) &&
               this.Model.IsValid &&
               this.Cubic.IsValid &&
               this.ReleaseYear.IsValid &&
               (this.NumberOfCylinders.IsValid);
    }
}
