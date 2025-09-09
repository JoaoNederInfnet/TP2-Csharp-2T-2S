using System.Text.Json;
using Ex_12.Models;
using Microsoft.AspNetCore.Mvc;
using static Ex_12.Pages.CountryManager.CountryDataKeys;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FluentValidation;
using FluentValidation.Results;

namespace Ex_12.Pages.CountryManager;

public class CountryCreate : PageModel
{
    /* ------------------------------- CLASSE DE ENTRADA ------------------------------- */
    public class InputModel
    {
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }
    }
    //========================================================
    
    /* ------------------------------- PROPRIEDADES ------------------------------- */
    //1) Definindo a propriedade que será ligada aos dados do formulário no HTML
    [BindProperty]  
    public List<InputModel> Inputs { get; set; } = new(); //========================================================
    
    /* ------------------------------- PREPARAÇÕES ------------------------------- */
    //1) Para conseguir usar minhas classes FluentValidation
    //A) Criando um campo que usarei para injetar o validador dentro da PageModel
    private readonly IValidator<InputModel> _validator; //readonly para definir esse campo apenas no construtor
    //----------------------------------//--------------------------------
    //B) Criando um construtor para injetar o validador registrado no Program.cs (linha 13)
    public CountryCreate(IValidator<InputModel> validator)
    {
        _validator = validator;
    }
    //========================================================
    
    /* ------------------------------- HANDLERS DE REQUISIÇÃO ------------------------------- */
    //# GET -> Preparação para primeira exibição da página
    //Inicializando a lista Inputs com 5 itens vazios, para gerar o HTML correto com 5 objetos a serem preenchidos
    public void OnGet() 
    {
        for (int i = 0; i < 5; i++)
        {
            Inputs.Add(new InputModel());
        }
    }
    //========================================================
    
    //# POST -> Processamento dos dados enviados pelo formulário
    public IActionResult OnPost()
    {
        /* Fazendo a validação manual com FluentValidation */
        //1) Laço for para validar cada objeto input do formulário
        for (int i = 0; i < Inputs.Count; i++)
        {
            //2) Instanciando um objeto ValidationResult, que devolve o resultado da validação de um Input com minhas validações no pacote Validators
            ValidationResult result = _validator.Validate(Inputs[i]);

            //3) Conferindo o objeto ValidationResult para registrar os erros no ModelState 
            if (!result.IsValid)
            {
                //4) foreach para usar cada erro encontrado no Input
                foreach (var error in result.Errors)
                {
                    //5) Adicionando o erro dentro do ModelState, para a propriedade específica
                    ModelState.AddModelError($"{nameof(Inputs)}[{i}].{error.PropertyName}", error.ErrorMessage);
                }
            }
        }
        
        //6)Carregando o formulário de novo com as mensagens de erro 
        if (!ModelState.IsValid)
        {
            return Page();
        }
        //========================================================
        
        
        /* Para formulário preenchido corretamente */
        //# Preparando os dados para o armazenamento na sessão HTTP
        //1) Instanciando a Classe de Domínio
        var countries = Inputs
            .Where(input => !string.IsNullOrEmpty(input.CountryName))
            .Select(input => new Country(input.CountryName!, input.CountryCode!))
            .ToList();

        //2) Transformando a lista de objetos em uma string JSON
        if (countries.Any())
        {
            var jsonString = JsonSerializer.Serialize(countries);
            HttpContext.Session.SetString(countriesJson, jsonString);
        }
        
        // Redirecionando para o index
        return RedirectToPage("CountryIndex");
    }
}