using System.Text.Json;
using Ex_12.Models;
using Microsoft.AspNetCore.Mvc;
using static Ex_12.Utils.Conversores;
using static Ex_12.Pages.CountryManager.CountryDataKeys;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_12.Pages.CountryManager;

public class CountryDetails : PageModel
{
    /* ------------------------------- PROPRIEDADES ------------------------------- */
    //1) Definindo a propriedade que irá armazenar os dados do país a ser exibido na página
    public Country Country { get; set; } = new();
    //========================================================
    
    /* ------------------------------- HANDLERS DE REQUISIÇÃO ------------------------------- */
    //# GET -> Preparação para primeira exibição da página
    // Recebe
    public void OnGet(string countryNameUrl)
    {
        //Recebendo a string JSON com os países
        var countriesJsonString = HttpContext.Session.GetString(countriesJson);
        
        //Verificando a string JSON recebida
        if (!string.IsNullOrEmpty(countriesJsonString))
        {
            //Transformando a string JSON em uma lista de objetos
            var countries = JsonSerializer.Deserialize<List<Country>>(countriesJsonString);
            
            //Econtrando o objeto país correspondente à URL e associando-o à propriedade da PageModel
            Country = countries?.FirstOrDefault(country => 
                ConverterPalavra(country.CountryName).Equals(countryNameUrl, StringComparison.OrdinalIgnoreCase));
        }
    }
}