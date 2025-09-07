using System.Text.Json;
using Ex_07.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_07.Pages.CountryManager;

public class CountryIndex : PageModel
{
    public List<Country> Countries { get; set; }
    
    public void OnGet(string countriesJsonString)
    {
        //Verificando a string JSON recebida
        if (string.IsNullOrEmpty(countriesJsonString))
        {
            Countries = new List<Country>();
        }
        else
        {
            //Transformando a string JSON em uma lista de objetos
            var countries = JsonSerializer.Deserialize<List<Country>>(countriesJsonString);

            Countries = countries;
        }
    } 
}