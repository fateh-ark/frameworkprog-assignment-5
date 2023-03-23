namespace FrameworkProg5;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(PokemonDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
    }
}