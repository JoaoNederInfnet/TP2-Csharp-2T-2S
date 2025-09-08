using System.Text.Json;
using Ex_09.Models;
using static Ex_09.Pages.CountryManager.CountryDataKeys;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_09.Pages.CountryManager;

public class CountryIndex : PageModel
{
    public List<Country> Countries { get; set; }
    
    public void OnGet()
    {
        //Pegando a string json da sessão Http
        var countriesJsonString = HttpContext.Session.GetString(countriesJson);
        
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
            
            //Usando o TempData para armazenar a string JSON para a próxima requisição (clicada no link para o country details)
            TempData[countriesJson] = countriesJsonString;
            
        }
    } 
}