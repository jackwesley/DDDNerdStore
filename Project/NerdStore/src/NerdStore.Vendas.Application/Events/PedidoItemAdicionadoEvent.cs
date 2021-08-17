using NerdStore.Core.Messages;
using System;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoItemAdicionadoEvent : Event
    {
        public Guid ClientId { get; private set; }
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public decimal Valor { get; private set; }
        public int Quantidade { get; private set; }

        public PedidoItemAdicionadoEvent(Guid clientId, Guid pedidoId, Guid produtoId, string produtoNome, decimal valor, int quantidade)
        {
            AggregateId = pedidoId;
            ClientId = clientId;
            PedidoId = pedidoId;
            ProdutoNome = produtoNome;
            ProdutoId = produtoId;
            Valor = valor;
            Quantidade = quantidade;
        }
    }
}
