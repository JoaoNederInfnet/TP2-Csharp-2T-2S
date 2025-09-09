using System.Text.Json;
using Ex_12.Models;
using static Ex_12.Pages.CountryManager.CountryDataKeys;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_12.Pages.CountryManager;

public class CountryIndex : PageModel
{
    /* ------------------------------- PROPRIEDADES ------------------------------- */
    //1) Definindo a propriedade que irá armazenar os dados do país a ser exibido na página
    public List<Country> Countries { get; set; } = new();
    
    /* ------------------------------- HANDLERS DE REQUISIÇÃO ------------------------------- */
    //# GET -> Preparação para primeira exibição da página
    // Acessa a session usa os dados para extrair uma lista de países e armazenar na sua propriedade
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
            //Transformando a string JSON em uma lista de objetos e associando à sua propriedade
            Countries = JsonSerializer.Deserialize<List<Country>>(countriesJsonString) ?? new List<Country>();
        }
    } 
}