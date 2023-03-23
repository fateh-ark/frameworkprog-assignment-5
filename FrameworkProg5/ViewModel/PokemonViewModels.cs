using FrameworkProg5.Services;
namespace FrameworkProg5.ViewModel;
public partial class PokemonViewModels :BaseViewModel
{
    PokemonService pokemonService;
    public ObservableCollection<Pokemon> Pokemons { get; } = new();

    IConnectivity connectivity;

    public PokemonViewModels(PokemonService pokemonService, IConnectivity connectivity)
    {
        Title = "Pokédex";
        this.pokemonService = pokemonService;
        this.connectivity = connectivity;
    }

    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
    async Task GoToDetailsAsync(Pokemon pokemon)
    {
        if (pokemon == null)
            return;

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}",true,
            new Dictionary<string, object>
            {
                {"Pokemon",pokemon}
            });
    }

    [RelayCommand]
    async Task GetPokemonAsync()
    {
        if (IsBusy)
            return;

        try
        {
            if(connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Error!", $"Cant seem to reach the internet. Check your internet connection and try again.", "OK");
                return;
            }

            IsBusy = true;
            var pokemons = await pokemonService.GetPokemons();

            if (Pokemons.Count != 0)
                Pokemons.Clear();

            foreach (var pokemon in pokemons)
                Pokemons.Add(pokemon);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", $"Unable to get Pokemons: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;   
        }
    }
}

