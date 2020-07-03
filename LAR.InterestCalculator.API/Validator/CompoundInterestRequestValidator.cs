using FluentValidation;
using LAR.InterestCalculator.API.Request;

namespace LAR.InterestCalculator.API.Validator
{
    public class CompoundInterestRequestValidator : AbstractValidator<CompoundInterestRequest>
    {
        public CompoundInterestRequestValidator()
        {
            RuleFor(x => x.InitialAmount)
                .GreaterThan(0M)
                .WithMessage("O valor do parâmetro 'initialAmount' (montante inicial) deve ser superior a zero.");
            RuleFor(x => x.MonthsAmount)
                .GreaterThan(0)
                .WithMessage("O valor do parâmetro 'monthsAmount' (quantidade de meses) deve ser superior a zero.");
        }
    }
}
