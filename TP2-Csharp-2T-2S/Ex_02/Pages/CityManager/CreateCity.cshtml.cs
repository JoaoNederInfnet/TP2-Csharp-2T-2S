using Ex_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_02.Pages.CityManager;

public class CreateCity : PageModel
{
   public IActionResult OnPost(string cityName)
   {
      //Validando se os dados do formulário foram preenchidos corretamente
      if (string.IsNullOrEmpty(cityName)) return Page();
      
      //Enviando os dados para o Index
      return RedirectToPage("Index", new
         {
            //Anonymous Object para enviar os dados do formulário
            CityName = cityName
         }
      );
   }
}