using Ex_12.Pages.CountryManager;
using FluentValidation;

namespace Ex_12.Validators;

public class CountryValidator : AbstractValidator<CountryCreate>
{
    public CountryValidator(IValidator<CountryCreate.InputModel> inputValidator)
    {
        RuleForEach(pagina => pagina.Inputs).SetValidator(inputValidator);
    }
}