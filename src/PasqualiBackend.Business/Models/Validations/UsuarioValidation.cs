using FluentValidation;
using PasqualiBackend.Business.Models.Validations.Documentos;

namespace PasqualiBackend.Business.Models.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(f => !string.IsNullOrEmpty(f.Nome), () =>
            {
                RuleFor(f => f.Cpf.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo CPF precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(f => CpfValidacao.Validar(f.Cpf)).Equal(true)
                    .WithMessage("O CPF fornecido é inválido.");
            });

            RuleFor(c => c.DataNascimento)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Renda)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}
