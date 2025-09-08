using System.Text.Json;
using Ex_09.Models;
using static Ex_09.Utils.Conversores;
using static Ex_09.Pages.CountryManager.CountryDataKeys;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_09.Pages.CountryManager;

public class CountryDetails : PageModel
{
    public Country Country { get; set; }

    public void OnGet(string countryNameUrl)
    {
        var countriesJsonString = HttpContext.Session.GetString(countriesJson);
        
        //Verificando a string JSON recebida
        if (!string.IsNullOrEmpty(countriesJsonString))
        {
            //Transformando a string JSON em uma lista de objetos
            var countries = JsonSerializer.Deserialize<List<Country>>(countriesJsonString);
            
            //Econtrando o objeto país correspondente a URL
            Country = countries.FirstOrDefault(country => 
                ConverterPalavra(country.CountryName).Equals(countryNameUrl, StringComparison.OrdinalIgnoreCase));
            
        }
    }
}