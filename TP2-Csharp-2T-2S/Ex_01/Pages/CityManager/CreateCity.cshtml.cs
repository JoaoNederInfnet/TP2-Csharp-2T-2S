using Ex_01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_01.Pages;

public class CreateCity : PageModel
{
    [BindProperty]
    public City City { get; set; }
    
    public IActionResult OnPost()
    {
        //Validando se os dados do formulário foram preenchidos corretamente
        if (!ModelState.IsValid) return Page();
        
        //Enviando os dados para o Index
        return RedirectToPage("Index", new
            {
                //Anonymous Object para enviar os dados do formulário
                nome = City.CityName
            }
        );
    }
    
}