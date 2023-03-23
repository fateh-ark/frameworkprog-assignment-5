using System.Net.Http.Json;

namespace FrameworkProg5.Services;
public class PokemonService
{
    HttpClient httClient;
    public PokemonService()
    {
        httClient = new HttpClient();
    }

    List<Pokemon> pokemonList;
    public async Task<List<Pokemon>> GetPokemons()
    {
        if(pokemonList?.Count > 0)
            return pokemonList;

        var url = "https://raw.githubusercontent.com/fateh-ark/frameworkprog-assignment-5/main/pokedex.json";

        var response = await httClient.GetAsync(url);

        if(response.IsSuccessStatusCode)
        {
            pokemonList = await response.Content.ReadFromJsonAsync<List<Pokemon>>();
        }

        return pokemonList;
    }
}
