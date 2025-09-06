using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_01.Pages;

public class Index : PageModel
{
    //Para preencher com os dados do formulário
    public string Nome { get; set; }
    
    public void OnGet(string nome)
    {
        Nome = nome;
    }
}