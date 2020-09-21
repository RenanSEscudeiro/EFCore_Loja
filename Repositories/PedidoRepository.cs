
using EFCore.Context;
using EFCore.Domains;
using EFCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }

        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
            try
            {
                //Criando o objeto pedido com seus respectivos valores
                Pedido pedido = new Pedido
                {
                    Status = "Pedido Efetuado",
                    OrderDate = DateTime.Now,
                    
                };


                //Percorre a lista de pedidos itens (foreach) e adiciona a lista de pedidosItens
                foreach (var item in pedidosItens)
                {
                    //Adiciona um pedidoitem a lista com seus respectivos valores
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id, //Id do objeto pedido que foi criado
                        IdProduto = item.IdProduto,
                        Quantidade = item.Quantidade
                    });
                }

                //Adicionando o pedido ao contexto
                _ctx.Pedidos.Add(pedido);
                //Salva as alterações do contexto no db
                _ctx.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Pedidos
                    .Include(c => c.PedidosItens)
                    .ThenInclude(c => c.Produto)
                    .FirstOrDefault(p => p.Id == id); //Inner Join
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}