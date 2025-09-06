namespace Ex_02.Models;

using System.ComponentModel.DataAnnotations;

public class City
{
    [Required(ErrorMessage = "O título é obrigatório")]
    public string CityName { get; set; }
}