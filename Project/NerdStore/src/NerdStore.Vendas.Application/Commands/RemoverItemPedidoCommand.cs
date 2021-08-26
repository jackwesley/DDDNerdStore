﻿using FluentValidation;
using NerdStore.Core.Messages;
using System;

namespace NerdStore.Vendas.Application.Commands
{
    public class RemoverItemPedidoCommand : Command
    {
        public Guid ClientId { get; private set; }
        public Guid ProdutoId { get; private set; }

        public RemoverItemPedidoCommand(Guid clientId, Guid produtoId)
        {
            ClientId = clientId;
            ProdutoId = produtoId;
        }

        public override bool EhValido()
        {
            ValidationResult = new RemoverItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RemoverItemPedidoValidation : AbstractValidator<RemoverItemPedidoCommand>
    {
        public RemoverItemPedidoValidation()
        {
            RuleFor(c => c.ClientId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");
        }
    }
}
