namespace FrameworkProg5.View;

public partial class MainPage : ContentPage
{
	public MainPage(PokemonViewModels viewModels)
	{
		InitializeComponent();
		BindingContext = viewModels;
	}
}

