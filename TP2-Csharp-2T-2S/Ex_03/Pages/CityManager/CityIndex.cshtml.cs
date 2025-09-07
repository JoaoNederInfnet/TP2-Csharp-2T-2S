using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_03.Pages.CityManager;

public class CityIndex : PageModel
{
    //Para preencher com os dados do formulário
    public string CityName { get; set; } 
    
    public void OnGet(string nome)
    {
        CityName = nome;
    }  
}