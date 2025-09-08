using System.Text;
using System.Text.RegularExpressions;

namespace Ex_09.Utils;

public class Conversores
{
    /*/ ------------------------------- MÉTODOS ------------------------------- /*/
    //1) Para converter as letras de uma palavra para a versão minúscula sem acento
    public static char ConverterLetra(char elemento)
    {
        //Convertendo char para string e deixando em letras minúsculas para conseguir manipular
        string letra = elemento.ToString().ToLower();
        
        //Separando a letra do acento
        string letraSemAcento = letra.Normalize(NormalizationForm.FormD);
        
        //Colocando a letra sozinha e mínuscula na variável de retorno
        elemento = letraSemAcento[0];
        
        //Retornando 
        return elemento;
    }
    //--------------------------------------------/------------------------------------------
    
    //2) Para converter uma string para uma string sem acento e em lower case
    public static string ConverterPalavra(string nome)
    {
        //Convertendo os espaços na string para hífens
        string nomeCompacto = Regex.Replace(nome.Trim(),@"[.,\s]", "-");
        
        //Criando um array que irá armazenar cada caractere da string
        char[] nomeSeparado = nomeCompacto.ToCharArray();
        
        //Modificando os caracteres e retornando um array de chars
        char[] caracteres = nomeSeparado.Select(elemento =>
        {
          return ConverterLetra(elemento);
        }
         ).ToArray();
        
        //Transformando o array de caracteres em uma nova string e retornando
        return string.Join("", caracteres);
    }
}