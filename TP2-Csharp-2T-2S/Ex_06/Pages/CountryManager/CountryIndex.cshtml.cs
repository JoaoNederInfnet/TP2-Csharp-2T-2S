using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_06.Pages.CountryManager;

public class CountryIndex : PageModel
{
    //Para preencher com os dados do formulário
    //1) Nome
    public string CountryName { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //2) Código
    public string CountryCode { get; set; }
    //========================================================
    
    public void OnGet(string nome, string codigo)
    {
        CountryName = nome;
        CountryCode = codigo;
    } 
}