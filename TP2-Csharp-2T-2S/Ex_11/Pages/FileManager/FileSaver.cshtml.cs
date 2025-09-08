using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_11.Pages.FileManager;

public class FileSaver : PageModel
{
    // ------------------- Classe de Entrada -------------------
    public class InputModel
    {
        [Required(ErrorMessage = "O conteúdo da nota é obrigatório!")]
        public string Content { get; set; }
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public string SavedFileName { get; set; }

    // ------------------- Métodos -------------------
    //1) 
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // 1) Garantir que a pasta files existe
        var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");
        if (!Directory.Exists(wwwrootPath))
        {
            Directory.CreateDirectory(wwwrootPath);
        }

        // 2) Gerar nome único do arquivo
        var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        SavedFileName = $"note-{timestamp}.txt";
        var filePath = Path.Combine(wwwrootPath, SavedFileName);

        // 3) Escrever o conteúdo no arquivo
        System.IO.File.WriteAllText(filePath, Input.Content);

        // 4) Voltar para a mesma página exibindo confirmação
        return Page();
    }
}