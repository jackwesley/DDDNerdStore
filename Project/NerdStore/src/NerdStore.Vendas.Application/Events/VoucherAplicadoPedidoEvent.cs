using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Application.Events
{
    public class VoucherAplicadoPedidoEvent : Event
    {
        public Guid ClientId { get; private set; }

        public Guid PedidoId { get; private set; }

        public Guid VoucherId { get; private set; }

        public VoucherAplicadoPedidoEvent(Guid clientId, Guid pedidoId, Guid voucherId)
        {
            AggregateId = pedidoId;
            ClientId = clientId;
            PedidoId = pedidoId;
            VoucherId = voucherId;
        }
    }
}
