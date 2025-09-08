using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex_11.Pages.FileManager;

public class FileViewer : PageModel
{
    // Lista de arquivos encontrados
    public List<string> Files { get; set; } = new();

    // Arquivo selecionado
    public string SelectedFile { get; set; }

    // Conteúdo do arquivo selecionado
    public string SelectedContent { get; set; }

    public void OnGet(string fileName)
    {
        // Caminho da pasta files
        var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

        // Garantir que a pasta exista
        if (!Directory.Exists(wwwrootPath))
        {
            Directory.CreateDirectory(wwwrootPath);
        }

        // 1) Listar arquivos .txt
        Files = Directory.GetFiles(wwwrootPath, "*.txt")
            .Select(Path.GetFileName)
            .ToList();

        // 2) Se algum arquivo foi clicado, abrir e mostrar
        if (!string.IsNullOrEmpty(fileName))
        {
            var fullPath = Path.Combine(wwwrootPath, fileName);

            if (System.IO.File.Exists(fullPath))
            {
                SelectedFile = fileName;
                SelectedContent = System.IO.File.ReadAllText(fullPath);
            }
        }
    }
}