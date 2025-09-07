using System.ComponentModel.DataAnnotations;
using Ex_06.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_06.Pages.CountryManager;

public class CountryCreate : PageModel
{
    /*/ ------------------------------- CLASSE DE ENTRADA ------------------------------- /*/
    public class InputModel
    {
        /*/ ------------------------------- PROPRIEDADES ------------------------------- /*/
        //1) Nome
        //A) Validações com Data Annotations
        //a) Requerido
        [Required(ErrorMessage = "O nome do país é obrigatório!")]
        //-------------------------///-----------------------
        //b) Qnt de caracteres
        [MinLength(3,ErrorMessage = "O nome do país precisa ter mais de 3 caracteres!")]
        
        public string CountryName { get; set; }//--------------------------------------------/------------------------------------------
    
        //2) Código
        //A) Validações com Data Annotations
        //a) Requerido
        [Required(ErrorMessage = "O código do país é obrigatório!")]
        //-------------------------///-----------------------
        //b) Qnt de caracteres
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O nome do país precisa ter 2 letras!")]
        //-------------------------///-----------------------
        //c) Letras Maiúsculas
        [RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "O código do país deve conter apenas 2 letras maiúsculas.")]
        
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