﻿using NerdStore.Vendas.Application.Queries.ViewModels;
using NerdStore.Vendas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Application.Queries
{
    public class PedidoQueries : IPedidoQueries
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoQueries(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<CarrinhoViewModel> ObterCarrinhoClienteAsync(Guid client)
        {
            var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(client);
            if (pedido == null) return null;

            var carrinho = new CarrinhoViewModel
            {
                ClientId = pedido.ClienteId,
                ValorTotal = pedido.ValorTotal,
                PedidoId = pedido.Id,
                ValorDesconto = pedido.Desconto,
                SubTotal = pedido.Desconto + pedido.ValorTotal
            };

            if (pedido.Voucher != null)
            {
                carrinho.VoucherCodigo = pedido.Voucher.Codigo;
            }

            foreach (var item in pedido.PedidoItems)
            {
                carrinho.Items.Add(new CarrinhoItemViewModel
                {
                    ProdutoId = item.ProdutoId,
                    ProdutoNome = item.ProdutoNome,
                    Quantidade = item.Quantidade,
                    ValorUnitario = item.ValorUnitario,
                    ValorTotal = item.ValorUnitario * item.Quantidade
                });
            }

            return carrinho;
        }

        public async Task<IEnumerable<PedidoViewModel>> ObterPedidosClienteAsync(Guid cliente)
        {
            var pedidos = await _pedidoRepository.ObterListaPorClienteId(cliente);

            pedidos = pedidos.Where(p => p.PedidoStatus == PedidoStatus.Pago || p.PedidoStatus == PedidoStatus.Cancelado)
                .OrderByDescending(p => p.Codigo);

            if (!pedidos.Any()) return null;

            var pedidosView = new List<PedidoViewModel>();

            foreach (var pedido in pedidos)
            {
                pedidosView.Add(new PedidoViewModel
                {
                    ValorTotal = pedido.ValorTotal,
                    PedidoStatus = (int)pedido.PedidoStatus,
                    Codigo = pedido.Codigo,
                    DataCadastro = pedido.DataCadastro
                });
            }

            return pedidosView;
        }
    }
}
