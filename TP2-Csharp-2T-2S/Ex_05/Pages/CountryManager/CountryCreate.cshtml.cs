using System.ComponentModel.DataAnnotations;
using Ex_05.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_05.Pages.CountryManager;

public class CountryCreate : PageModel
{
    /*/ ------------------------------- CLASSE DE ENTRADA ------------------------------- /*/
    public class InputModel
    {
        /*/ ------------------------------- PROPRIEDADES ------------------------------- /*/
        //1) Nome
        [Required(ErrorMessage = "O nome do país é obrigatório!")]
        [MinLength(3,ErrorMessage = "O nome do país precisa ter mais de 3 caracteres!")]
        public string CountryName { get; set; }//--------------------------------------------/------------------------------------------
    
        //2) Código
        [Required(ErrorMessage = "O código do país é obrigatório!")]
        public string CountryCode { get; set; }
    }

    [BindProperty] public InputModel Input { get; set; } = new();
    
    
    public IActionResult OnPost()
    {
        //Validando se os dados do formulário foram preenchidos corretamente
        if (!ModelState.IsValid) return Page();
        
        //Instanciando a Classe de Domínio
        Country country = new Country(Input.CountryName, Input.CountryCode);
        
        //Enviando os dados para o Index
        return RedirectToPage("CountryIndex", new
            {
                //Anonymous Object para enviar os dados do formulário
                nome = country.CountryName,
                codigo = country.CountryCode
            }
        );
    }
}