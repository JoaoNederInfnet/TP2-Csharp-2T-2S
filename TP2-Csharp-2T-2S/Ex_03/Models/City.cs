using System.ComponentModel.DataAnnotations;

namespace Ex_03.Models;

public class City
{
    /*/ ------------------------------- PROPRIEDADES ------------------------------- /*/
    [Required(ErrorMessage = "O nome da cidade é obrigatório!")]
    public string CityName { get; set; } 
    //========================================================
    
    /*/ ------------------------------- CONSTRUTORES ------------------------------- /*/
    //1) Cheio
    public City(string nome)
    {
        CityName = nome;
    }
    //--------------------------------------------/------------------------------------------
    
    //2) Vazio 
    public City() {}
}