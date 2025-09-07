using System.ComponentModel.DataAnnotations;
using Ex_04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_04.Pages.CityManager;

public class CityCreate : PageModel
{
    /*/ ------------------------------- CLASSE DE ENTRADA ------------------------------- /*/
    public class InputModel
    {
        [Required(ErrorMessage = "O nome da cidade é obrigatório!")]
        [MinLength(3,ErrorMessage = "O nome da cidade precisa ter mais de 3 caracteres!")]
        public string CityName { get; set; }
    }

    [BindProperty] public InputModel Input { get; set; } = new();
    
    
    public IActionResult OnPost()
    {
        //Validando se os dados do formulário foram preenchidos corretamente
        if (!ModelState.IsValid) return Page();
        
        //Instanciando a Classe de Domínio
        City city = new City(Input.CityName);
        
        //Enviando os dados para o Index
        return RedirectToPage("CityIndex", new
            {
                //Anonymous Object para enviar os dados do formulário
                nome = city.CityName
            }
        );
    }
}