using FluentValidation;
using NerdStore.Core.Messages;
using System;

namespace NerdStore.Vendas.Application.Commands
{
    public class AtualizarItemPedidoCommand : Command
    {
        public Guid ClientId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public int Quantidade { get; private set; }

        public AtualizarItemPedidoCommand(Guid clientId, Guid produtoId, int quantidade)
        {
            ClientId = clientId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }


        public override bool EhValido()
        {
            ValidationResult = new AtualizarItemPedidoValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }

    public class AtualizarItemPedidoValidation : AbstractValidator<AtualizarItemPedidoCommand>
    {
        public AtualizarItemPedidoValidation()
        {
            RuleFor(c => c.ClientId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage("Quantidade mínima deve ser 1 item");

            RuleFor(c => c.Quantidade)
                .LessThan(15)
                .WithMessage("Quantidade máxima de um item é 15");
        }
    }
}
