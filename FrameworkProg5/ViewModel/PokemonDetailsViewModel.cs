namespace FrameworkProg5.ViewModel;

[QueryProperty("Pokemon","Pokemon")]
public partial class PokemonDetailsViewModel : BaseViewModel
{
    public PokemonDetailsViewModel()
    {
    }

    [ObservableProperty]
    Pokemon pokemon;
}
