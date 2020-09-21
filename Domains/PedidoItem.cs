using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Domains
{
    /// <summary>
    /// Classe PedidoItem que relaciona a classe Pedido com a Produto 
    /// </summary>
    public class PedidoItem : BaseDomain

    //O relacionamento entre classes ocorre utilizando o Data Annotations Schema
    //Guid - código único de incrementação, segurança do ID, é interessante utilizar na Primary Key
    //Domains - "Classes" das coisas
    {
        

        public Guid IdPedido { get; set; }
        [ForeignKey("IdPedido")]

        public Pedido Pedido { get; set; }

        public Guid IdProduto { get; set; }
        [ForeignKey("IdProduto")]

        public Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }

     

    }
}
