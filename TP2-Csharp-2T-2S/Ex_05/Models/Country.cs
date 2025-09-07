using System.ComponentModel.DataAnnotations;

namespace Ex_05.Models;

public class Country
{
    /*/ ------------------------------- PROPRIEDADES ------------------------------- /*/
    //1) Nome
    [Required(ErrorMessage = "O nome do país é obrigatório!")]
    public string CountryName { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //2) Código
    [Required(ErrorMessage = "O código do país é obrigatório!")]
    public string CountryCode { get; set; }
    //========================================================
    
    /*/ ------------------------------- CONSTRUTORES ------------------------------- /*/
    //1) Cheio
    public Country(string nome, string codigo)
    {
        CountryName = nome;
        CountryCode = codigo;
    }
    //--------------------------------------------/------------------------------------------
    
    //2) Vazio 
    public Country() {}
}