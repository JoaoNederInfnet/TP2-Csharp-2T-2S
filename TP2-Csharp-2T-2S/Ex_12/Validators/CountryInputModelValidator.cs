using Ex_12.Pages.CountryManager;
using FluentValidation;

namespace Ex_12.Validators;

public class CountryInputModelValidator : AbstractValidator<CountryCreate.InputModel>
{
    /*/ ------------------------------- REGRAS ------------------------------- /*/ 
    //# Auxiliares das condições .Must()
    //1) Para iniciais iguais das propriedades CountryName e CountryCode
    private bool DevemTerIniciaisIguais(CountryCreate.InputModel input)
    {
        if(!string.IsNullOrEmpty(input.CountryName) &&
           !string.IsNullOrEmpty(input.CountryCode) &&
           char.ToUpper(input.CountryName[0]) == char.ToUpper(input.CountryCode[0]))
        {
            return true;
        }
        return false;
    }
    //-----------------------------#---------------------------
    
    //# Auxiliares da condição .When()
    //2) Para campos preenchidos
    private bool ItemDeveSerPreenchido(CountryCreate.InputModel input)
    {
        if (!string.IsNullOrEmpty(input.CountryName) || !string.IsNullOrEmpty(input.CountryCode))
        {
            return true;
        }
        return false;
    }
    //========================================================
    
    /*/ ------------------------------- VALIDAÇÃO ------------------------------- /*/
    public CountryInputModelValidator()
    {
        //Só executa as validações se a (Regra 2) for atendida
        When(ItemDeveSerPreenchido, () =>
        {
            /*VALIDANDO*/
            //1) Se as propriedades CountryName e CountryCode possuem a mesma inicial
            //a) Código
            RuleFor(input => input.CountryCode)
                .Must((input, code) => DevemTerIniciaisIguais(input))
                .WithMessage("O nome e o código do país precisam ter a mesma inicial!");
            //-------------------------///-----------------------
            //b) Nome
            RuleFor(input => input.CountryName)
                .Must((input, name) => DevemTerIniciaisIguais(input))
                .WithMessage("O nome e o código do país precisam ter a mesma inicial!");
            //--------------------------------------------/------------------------------------------
          
            //2) Se a propriedade CountryName foi preenchida com mais de 3 caracteres 
            RuleFor(input => input.CountryName)
                .NotEmpty().WithMessage("O nome do país é obrigatório!")
                .MinimumLength(3).WithMessage("O nome do país precisa ter mais de 3 caracteres!");
            //--------------------------------------------/------------------------------------------
          
            //3) Se a propriedade CountryCode foi preenchida com 2 letras maiúsculas
            RuleFor(input => input.CountryCode)
                .NotEmpty().WithMessage("O código do país é obrigatório!")
                .Length(2).WithMessage("O código do país precisa ter exatamente 2 letras!")
                .Matches(@"^[A-Z]{2}$").WithMessage("O código do país deve conter apenas 2 letras maiúsculas.");
        });
    }
}