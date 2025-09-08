using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Ex_09.Models;
using Microsoft.AspNetCore.Mvc;
using static Ex_09.Pages.CountryManager.CountryDataKeys;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_09.Pages.CountryManager;

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
        
        public string CountryName { get; set; }
        //--------------------------------------------/------------------------------------------
    
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

    [BindProperty] 
    public List<InputModel> Inputs { get; set; } = new();
    
    //Inicializando a lista Inputs com 5 itens vazios, para gerar o HTML correto
    public void OnGet()
    {
        for (int i = 0; i < 5; i++)
        {
          Inputs.Add(new InputModel());
        }
    }
    
    public IActionResult OnPost()
    {
        //Validando se os dados do formulário foram preenchidos corretamente
        if (!ModelState.IsValid) return Page();
        
        
        /*Preparando os dados para o armazenamento na sessaão HTTP*/
        //1) Instanciando a Classe de Domínio
        var countries = Inputs.Select(input => new Country(input.CountryName, input.CountryCode)).ToList();
        //--------------------------------------------/------------------------------------------
        
        //2) Transformando a lista de objetos em uma string JSON para passar ao index
        var jsonString = JsonSerializer.Serialize(countries);
        //A String fica no formato "[{\"CountryName\":\"Brasil\",\"CountryCode\":\"BR\"},{\"CountryName\":\"Portugal\",\"CountryCode\":\"PT\"}]"
        //--------------------------------------------/------------------------------------------
        
       //3) Armazenando na sessaão HTTP
       HttpContext.Session.SetString(countriesJson, jsonString);
       //========================================================
        
        //Redirecionando para o index
        return RedirectToPage("CountryIndex");
    }
}