using System.ComponentModel.DataAnnotations;

namespace Ex_01.Models;

public class City
{
    [Required(ErrorMessage = "O título é obrigatório")]
    public string CityName { get; set; }
}