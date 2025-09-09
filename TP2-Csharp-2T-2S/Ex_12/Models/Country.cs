using System.ComponentModel.DataAnnotations;
using static Ex_12.Utils.Conversores;

namespace Ex_12.Models;

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
    //========================================================
    
    /*/ ------------------------------- MÉTODOS ------------------------------- /*/
    //1) Para gerar o link
    public string UrlGenerator()
    {
        //Convertendo o nome do país para uma versão url friendly
        string countryNameConvertido = ConverterPalavra(CountryName);

        //Retornando a URL
        return countryNameConvertido;
    }
}