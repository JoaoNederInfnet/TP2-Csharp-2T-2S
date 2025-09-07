using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_08.Pages.CityManager;

public class CityDetails : PageModel
{
    public string CityName { get; set; }

    public void OnGet(string cityName)
    {
        CityName = cityName;
    }
}